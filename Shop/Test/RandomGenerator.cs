using Data.API;
using Data.Implementation;

namespace Shop.Test
{
    public class RandomGenerator : IGenerator
    {
        public void Generate(IDataContext context) 
        {
            for (int i = 0; i < 20; i++) 
            {
                Game game = new Game(null, RandomString(7), RandomNumber<double>(4), RandomDate(), RandomPEGI());
                context.Products.Add(game);

                User user = new User(null, RandomString(10), RandomString(10), RandomEmail(),
                    (RandomNumber<double>(4) + game.Price), RandomDateOfBirth(game.PEGI), RandomNumber<int>(9), null);
                context.Users.Add(user); 

                State state = new State(null, game, RandomNumber<int>(2));
                context.States.Add(state);

                PurchaseEvent buyEvent = new PurchaseEvent(null, state, user);
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

            List<int> pegiRange = new List<int>() { 3, 7, 12, 16, 18};

            return random.Next(pegiRange.Count);
        }

        public static DateTime RandomDateOfBirth(int pegi)
        {
            Random random = new Random();

            DateTime date = new DateTime(1900, 1, 1);

            int range = (DateTime.Today - date).Days;

            int age = pegi * 365;

            return date.AddDays(random.Next(age, range))
                .AddHours(random.Next(24))
                .AddMinutes(random.Next(60))
                .AddSeconds(random.Next(60));
        }

    }
}
