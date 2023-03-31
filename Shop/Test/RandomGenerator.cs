using Shop.Data;

namespace Shop.Test
{
    public class RandomGenerator : IGenerator
    {
        public void Generate(IDataContext Context) {
            for (int i = 0; i < 20; i++) {
                User user = new User(null, RandomString(10), RandomString(10), RandomEmail(),
                    RandomNumber<double>(4), RandomDate(), RandomNumber<int>(9));

                Context.Users.Add(user.Guid, user);
            }
        }

        public static string RandomString(int length) {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; 

            var randomText = new char[length];

            Random random = new Random();

            for (int i = 0; i < length; i++) {
                randomText[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomText);
        }

        public static string RandomStringWithNumber(int length) {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var randomText = new char[length];

            Random random = new Random();

            for (int i = 0; i < length; i++) {
                randomText[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomText);
        }

        public static string RandomEmail() {
            return string.Format("{0}@{1}.com", RandomStringWithNumber(10), RandomString(5));
        }

        public static T RandomNumber<T>(int length) where T : struct, IComparable {
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

        public static DateTime RandomDate() {
            Random random = new Random();

            DateTime date = new DateTime(1900, 1, 1);

            int range = (DateTime.Today - date).Days;

            return date.AddDays(random.Next(range))
                .AddHours(random.Next(24))
                .AddMinutes(random.Next(60))
                .AddSeconds(random.Next(60));
        }

    }
}
