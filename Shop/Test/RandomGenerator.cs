using Data.API;
using Data.Implementation;
using System.Reflection.Metadata;

namespace Shop.Test
{
    public class RandomGenerator : IGenerator
    {
        public void Generate(IDataContext context) 
        {
            for (int i = 0; i < 20; i++)
            {
                User user = new User(null, RandomString(10), RandomString(10), RandomEmail(),
                    (RandomNumber<double>(4)), RandomDate(), RandomNumber<int>(9), null);
                context.Users.Add(user);

                Game game = new Game(null, RandomString(7), RandomNumber<double>(4), RandomDate(), RandomPEGI());
                context.Products.Add(game);

                State state = new State(null, game, RandomNumber<int>(2));
                context.States.Add(state);
            }

            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {                
                User user = (User)context.Users[i];

                List<IState> availableGamesStates = context.States.FindAll(element => (element.Product.Price < user.Balance && 
                                                    (((Game)element.Product).PEGI * 365) < (DateTime.Today - user.DateOfBirth).Days) &&
                                                    !user.ProductLibrary.ContainsKey(element.Product.Guid) &&
                                                    (element.ProductQuantity > 0));

                if (availableGamesStates is not null && availableGamesStates.Count > 0)
                    switch (availableGamesStates.Count)
                    {
                        case 1:
                            PurchaseEvent eventPurchase0 = new PurchaseEvent(null, (State)availableGamesStates[0], user);
                            context.Events.Add(eventPurchase0);
                            break;
                        default:
                            State randomGameToPurchaseState = (State)availableGamesStates[random.Next(0, availableGamesStates.Count - 1)];
                            PurchaseEvent eventPurchase1 = new PurchaseEvent(null, randomGameToPurchaseState, user);
                            context.Events.Add(eventPurchase1);
                            break;
                    }
            }

            for (int i = 0; i < random.Next(5, 10); i++)
            {
                User randomUser = (User)context.Users[random.Next(context.Users.Count - 1)];

                if (randomUser.ProductLibrary.Count > 0)
                {
                    Game purchasedGame = (Game)randomUser.ProductLibrary.First().Value;
                    State purchasedGameState = (State)context.States.Find(element => element.Product.Guid == purchasedGame.Guid);
                    ReturnEvent eventReturn = new ReturnEvent(null, purchasedGameState, randomUser);
                    context.Events.Add(eventReturn);
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
