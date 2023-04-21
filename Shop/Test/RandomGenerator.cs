using Data.API;

namespace Test
{
    public class RandomGenerator : IGenerator
    {
        public void Generate(IDataRepository dataRepository) 
        {
            Random random = new Random();

            for (int i = 0; i < random.Next(20, 30); i++)
            {
                string productUuid = System.Guid.NewGuid().ToString();
                string stateUuid = System.Guid.NewGuid().ToString();

                dataRepository.AddUser(null, RandomString(10), RandomEmail(), RandomNumber<double>(4), RandomDate());
                dataRepository.AddProduct(productUuid, RandomString(7), RandomNumber<double>(4), RandomPEGI());
                dataRepository.AddState(stateUuid, productUuid, RandomNumber<int>(2));

                if (random.Next() < 0.85) // 15% chance of supplying
                    continue;

                dataRepository.AddEvent(null, stateUuid, productUuid, "SupplyEvent", random.Next(5,10));
            }

            foreach (IUser user in dataRepository.GetAllUsers().Values)
            {
                int age = (DateTime.Today - user.dateOfBirth).Days;

                Func<string, bool> IsProductOwned = (guid) => !user.productLibrary.ContainsKey(guid);

                Dictionary<string, IState> availableGamesStates = dataRepository.GetAllStates().Where(
                    (state) => (
                        dataRepository.GetProduct(state.Value.productGuid).price < user.balance &&
                        dataRepository.GetProduct(state.Value.productGuid).pegi * 365 < age &&
                        IsProductOwned(state.Value.productGuid) &&
                        state.Value.productQuantity > 0
                    )    
                ).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                foreach (IState availableGameState in availableGamesStates.Values)
                {
                    if (dataRepository.GetProduct(availableGameState.productGuid).price > user.balance)
                        continue;

                    if (random.NextDouble() < 0.15) // 85% chance of purchasing
                        continue;

                    dataRepository.AddEvent(null, availableGameState.guid, availableGameState.productGuid, "PurchaseEvent");

                    if (random.NextDouble() < 0.65) // 35% chance of returning
                        continue;

                    dataRepository.AddEvent(null, availableGameState.guid, availableGameState.productGuid, "ReturnEvent");
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
