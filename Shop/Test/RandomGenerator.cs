using Data.API;
using Data.Implementation;

namespace Test
{
    public class RandomGenerator : IGenerator
    {
        public void Generate(IDataContext context) 
        {
            Random random = new Random();

            for (int i = 0; i < random.Next(20, 30); i++)
            {
                User user = new User(null, RandomString(10), RandomString(10), RandomEmail(), RandomNumber<double>(4),
                    RandomDate(), RandomNumber<int>(9), null);
                Game game = new Game(null, RandomString(7), RandomNumber<double>(4), RandomDate(), RandomPEGI());
                State state = new State(null, game, RandomNumber<int>(2));

                context.users.Add(user);
                context.products.Add(game);
                context.states.Add(state);

                if (random.Next() < 0.85) // 15% chance of supplying
                    continue;

                SupplyEvent supplyEvent = new SupplyEvent(null, state, user, random.Next(5,10));
                context.events.Add(supplyEvent);
            }

            foreach (IUser user in context.users)
            {
                int age = (DateTime.Today - user.dateOfBirth).Days;

                Func<string, bool> IsProductOwned = (guid) => !user.productLibrary.ContainsKey(guid);

                List<IState> availableGamesStates = context.states.FindAll(
                    (state) => (
                        state.product.price < user.balance &&
                        ((Game)state.product).pegi * 365 < age &&
                        IsProductOwned(state.product.guid) &&
                        state.productQuantity > 0
                    )    
                );

                foreach (IState availableGameState in availableGamesStates)
                {
                    if (availableGameState.product.price > user.balance)
                        continue;

                    if (random.NextDouble() < 0.15) // 85% chance of purchasing
                        continue;

                    PurchaseEvent purchaseEvent = new PurchaseEvent(null, availableGameState, user);
                    context.events.Add(purchaseEvent);

                    if (random.NextDouble() < 0.65) // 35% chance of returning
                        continue;

                    ReturnEvent eventReturn = new ReturnEvent(null, availableGameState, user);
                    context.events.Add(eventReturn);
                }
            }
        }

        public static string RandomString(int length) 
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; 

            var randomText = new char[length];

            Random random = new Random();

            for (int i = 0; i < length; i++) 
            {
                randomText[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomText);
        }

        public static string RandomStringWithNumber(int length) 
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var randomText = new char[length];

            Random random = new Random();

            for (int i = 0; i < length; i++) 
            {
                randomText[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomText);
        }

        public static string RandomEmail() 
        {
            return string.Format("{0}@{1}.com", RandomStringWithNumber(10), RandomString(5));
        }

        public static T RandomNumber<T>(int length) where T : struct, IComparable 
        {
            if (length <= 0)
                throw new ArgumentException("Number of digits must be positive.");

            Random random = new Random();

            T maxNumber = (T)Convert.ChangeType(Math.Pow(10, length), typeof(T));

            T randomNumber = (T)Convert.ChangeType(
                random.Next(
                    Convert.ToInt32(Math.Pow(10, length - 1)),
                    Convert.ToInt32(maxNumber)
                ), typeof(T)
            );

            return randomNumber;
        }

        public static DateTime RandomDate() 
        {
            Random random = new Random();

            DateTime date = new DateTime(1900, 1, 1);

            int range = (DateTime.Today - date).Days;

            return date.AddDays(random.Next(range))
                .AddHours(random.Next(24))
                .AddMinutes(random.Next(60))
                .AddSeconds(random.Next(60));
        }

        public static int RandomPEGI()
        {
            Random random = new Random();

            List<int> pegiRange = new List<int>() { 3, 7, 12, 16, 18 };

            return random.Next(pegiRange.Count);
        }
    }
}
