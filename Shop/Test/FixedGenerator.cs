using Data.API;
using Data.Implementation;

namespace Test
{
    public class FixedGenerator : IGenerator
    {
        public void Generate(IDataContext context) {
            User user1 = new User("81c14d82-528e-4933-b64b-a602499b17e7", "Mateusz", "Kowalski", "m_kowalski@gmail.com", 353,
                new DateTime(2013, 5, 21), 543234567, null);
            User user2 = new User("dc295f09-53ed-4293-876d-c91668fe9f67", "Kamil", "Miglanc", "k_miglanc@gmail.com", 222,
                new DateTime(2011, 11, 22), 123908765, null);
            User user3 = new User("02c69ccc-e68a-4842-9f90-c086e3ba2555", "Wladyslaw", "Tomislawowski", "w_tomislawowski@gmail.com", 1205,
                new DateTime(2006, 4, 12), 578965335, null);
            User user4 = new User("39ee2c48-3879-4ef2-b980-a7536517c0c8", "Joanna", "Dzoanna", "j_dzoanna@gmail.com", 332,
                new DateTime(2001, 10, 1), 236879098, null);
            User user5 = new User("5d82a11a-2d3c-4061-994b-aa857a62afab", "Michal", "Zahenkos", "m_Zahenkos@gmail.com", 1245,
                new DateTime(1999, 12, 2), 422344789, null);
            User user6 = new User("4e6ea13b-a3f7-433c-bafc-0303ef70495c", "Andrzej", "Tomislawowski", "a_Tomislawowski@gmail.com", 333, 
                new DateTime(2003, 1, 22), 168332885, null);    // employee
            User user7 = new User("979861af-d81f-4217-b465-9eb7bea24077", "Eivor", "Ravensthrope", "e_ravensthrope@ac.no", 500,
                new DateTime(1996, 11, 10), 849529364, null);
            User user8 = new User("d808b909-c9de-4352-9f07-ed3a76ed8dfb", "Seokjin", "Kim", "s_kim@naver.kr", 100000, 
                new DateTime(2005, 7, 8), 839049333, null);
            User user9 = new User("bd7a5ac6-eb2a-46a0-86d2-61b6bc4c4b5b", "Hermenegilda", "Bauenhaupt", "h_bauenhaupt@outlook.com", 5750, 
                new DateTime(1998, 4, 19), 859302198, null);
            User user10 = new User("9f7005aa-7d18-4a20-bb58-a8f021a12168", "Stefan", "Zapominalski", "s_zapominalski@gmail.com", 68,
                new DateTime(2003, 11, 8), 938575039, null);

            context.users.Add(user1);
            context.users.Add(user2);
            context.users.Add(user3);
            context.users.Add(user4);
            context.users.Add(user5);
            context.users.Add(user6);
            context.users.Add(user7);
            context.users.Add(user8);
            context.users.Add(user9);
            context.users.Add(user10);

            Game game1 = new Game("2f2b5a86-0feb-4ffc-aad2-1ecdae82aa92", "Starcraft", 61.99, new DateTime(1998, 3, 28), 16);
            Game game2 = new Game("7e4d8099-892b-448d-aea7-73ac1df828a3", "Assassin's Creed Valhalla", 239.99, new DateTime(2020, 11, 10), 18);
            Game game3 = new Game("e60f4aa3-c545-47a7-8360-46d193ee0060", "Cyberpunk 2077", 299.99, new DateTime(2020, 12, 10), 18);
            Game game4 = new Game("d9dbc156-dca2-4d81-ad88-29f1230a4dcb", "The Sims 3", 109.99, new DateTime(2009, 6, 12), 7);
            Game game5 = new Game("07ddb96c-3626-4d0c-82dd-68c51721bbef", "Witcher 3", 129.99, new DateTime(2015, 5, 18), 18);
            Game game6 = new Game("2511c7f3-9bb1-47d5-850b-e34a5d8e8f15", "Diablo 3", 339.99, new DateTime(2012, 5, 15), 18);

            context.products.Add(game1);
            context.products.Add(game2);
            context.products.Add(game3);
            context.products.Add(game4);
            context.products.Add(game5);
            context.products.Add(game6);

            State state1 = new State("e96eba92-47f0-41dc-9c77-d8929e08691b", game1, 3);
            State state2 = new State("e5a18edc-5cbb-4739-8d81-75d2f69de7da", game2, 10);
            State state3 = new State("7aeded14-a6cf-4a4c-9f54-03ef98d48d58", game3, 5);
            State state4 = new State("221435ce-9fcc-46b3-85ab-cf51f0524f9b", game4, 8);
            State state5 = new State("ff7878ad-6c56-4c7a-8e40-9f560f7deaa2", game5, 6);
            State state6 = new State("41aaece7-a579-464c-8474-dd576834a5e6", game6, 9);

            context.states.Add(state1);
            context.states.Add(state2);
            context.states.Add(state3);
            context.states.Add(state4);
            context.states.Add(state5);
            context.states.Add(state6);

            PurchaseEvent purchaseEvent1 = new PurchaseEvent("4a93b8f8-a52d-43d6-90fa-3cf4e41c398e", state4, user1);
            PurchaseEvent purchaseEvent2 = new PurchaseEvent("5c362e6f-a3c1-417a-a5de-b077b85e3f44", state4, user2);
            PurchaseEvent purchaseEvent3 = new PurchaseEvent("8f38e47d-4fb1-4b82-be29-b1544e95adc9", state1, user3);
            PurchaseEvent purchaseEvent4 = new PurchaseEvent("d260624e-81e5-474f-80ba-dcea4d781416", state2, user4);
            PurchaseEvent purchaseEvent5 = new PurchaseEvent("1c4ce5ac-d2be-44c1-83b1-06f30254b925", state3, user5);
            PurchaseEvent purchaseEvent6 = new PurchaseEvent("c05cd328-7f9d-4b0b-8f4b-7ae76943a239", state6, user5);
            PurchaseEvent purchaseEvent7 = new PurchaseEvent("5552a672-9981-42a2-b0e6-52f493beb75d", state2, user7);
            PurchaseEvent purchaseEvent8 = new PurchaseEvent("14a31059-c4b8-46b3-9d34-aecf673226c2", state5, user8);
            PurchaseEvent purchaseEvent9 = new PurchaseEvent("22b919c1-5b32-4dd5-ba0e-9409f56eb664", state2, user9);
            PurchaseEvent purchaseEvent10 = new PurchaseEvent("2260378f-05f2-4d6b-b47b-3b7924ab6cb1", state1, user10);
            ReturnEvent returnEvent1 = new ReturnEvent("5ae736a7-793e-4e2c-84c3-dc8b7d9ff648", state3, user5);
            ReturnEvent returnEvent2 = new ReturnEvent("7bad89f8-6cbe-4e47-aa3d-3e1e44a370e2", state4, user2);
            ReturnEvent returnEvent3 = new ReturnEvent("fa8b45ba-0589-4e50-b77f-e9774852762b", state1, user10);
            ReturnEvent returnEvent4 = new ReturnEvent("4c47667f-08f3-46da-a4a4-6541d9fc7650", state2, user7);

            context.events.Add(purchaseEvent1);
            context.events.Add(purchaseEvent2);
            context.events.Add(purchaseEvent3);
            context.events.Add(purchaseEvent4);
            context.events.Add(purchaseEvent5);
            context.events.Add(purchaseEvent6);
            context.events.Add(purchaseEvent7);
            context.events.Add(purchaseEvent8);
            context.events.Add(purchaseEvent9);
            context.events.Add(purchaseEvent10);
            context.events.Add(returnEvent1);
            context.events.Add(returnEvent2);
            context.events.Add(returnEvent3);
            context.events.Add(returnEvent4);

            SupplyEvent supplyEvent1 = new SupplyEvent("a12f6a91-e8e1-4e3a-bf0d-8bce65aa4ea9", state1, user6, 10);
            SupplyEvent supplyEvent2 = new SupplyEvent("a3324ac5-7321-48f1-86b6-72153bf46871", state2, user6, 12);
            SupplyEvent supplyEvent3 = new SupplyEvent("ab733a46-c282-499f-b99a-6dc757882ac7", state3, user6, 20);
            SupplyEvent supplyEvent4 = new SupplyEvent("5684415a-5e25-4412-8d5a-cfc3b691dd9b", state4, user6, 7);
            SupplyEvent supplyEvent5 = new SupplyEvent("edb84553-f700-460f-90d0-fb02610b0d61", state5, user6, 5);
            SupplyEvent supplyEvent6 = new SupplyEvent("e71f51ed-21cb-41f3-9d40-b21cb46506bd", state6, user6, 9);

            context.events.Add(supplyEvent1);
            context.events.Add(supplyEvent2);
            context.events.Add(supplyEvent3);
            context.events.Add(supplyEvent4);
            context.events.Add(supplyEvent5);
            context.events.Add(supplyEvent6);
        }
    }
}
