//using Data.API;

//namespace Test
//{
//    public class FixedGenerator : IGenerator
//    {
//        public void Generate(IDataRepository dataRepository) {
//            dataRepository.AddUser("81c14d82-528e-4933-b64b-a602499b17e7", "Mateusz", "m_kowalski@gmail.com", 353,
//                new DateTime(2013, 5, 21));
//            dataRepository.AddUser("dc295f09-53ed-4293-876d-c91668fe9f67", "Kamil", "k_miglanc@gmail.com", 222,
//                new DateTime(2011, 11, 22));
//            dataRepository.AddUser("02c69ccc-e68a-4842-9f90-c086e3ba2555", "Wladyslaw", "w_tomislawowski@gmail.com", 1205,
//                new DateTime(2006, 4, 12));
//            dataRepository.AddUser("39ee2c48-3879-4ef2-b980-a7536517c0c8", "Joanna", "j_dzoanna@gmail.com", 332,
//                new DateTime(2001, 10, 1));
//            dataRepository.AddUser("5d82a11a-2d3c-4061-994b-aa857a62afab", "Michal", "m_Zahenkos@gmail.com", 1245,
//                new DateTime(1999, 12, 2));
//            dataRepository.AddUser("4e6ea13b-a3f7-433c-bafc-0303ef70495c", "Andrzej", "a_Tomislawowski@gmail.com", 333, 
//                new DateTime(2003, 1, 22));    // employee
//            dataRepository.AddUser("979861af-d81f-4217-b465-9eb7bea24077", "Eivor", "e_ravensthrope@ac.no", 500,
//                new DateTime(1996, 11, 10));
//            dataRepository.AddUser("d808b909-c9de-4352-9f07-ed3a76ed8dfb", "Seokjin", "s_kim@naver.kr", 100000, 
//                new DateTime(2005, 7, 8));
//            dataRepository.AddUser("bd7a5ac6-eb2a-46a0-86d2-61b6bc4c4b5b", "Hermenegilda", "h_bauenhaupt@outlook.com", 5750, 
//                new DateTime(1998, 4, 19));
//            dataRepository.AddUser("9f7005aa-7d18-4a20-bb58-a8f021a12168", "Stefan", "s_zapominalski@gmail.com", 68,
//                new DateTime(2003, 11, 8));
            
//            dataRepository.AddProduct("2f2b5a86-0feb-4ffc-aad2-1ecdae82aa92", "Starcraft", 61.99, 16);
//            dataRepository.AddProduct("7e4d8099-892b-448d-aea7-73ac1df828a3", "Assassin's Creed Valhalla", 239.99, 18);
//            dataRepository.AddProduct("e60f4aa3-c545-47a7-8360-46d193ee0060", "Cyberpunk 2077", 299.99, 18);
//            dataRepository.AddProduct("d9dbc156-dca2-4d81-ad88-29f1230a4dcb", "The Sims 3", 109.99, 7);
//            dataRepository.AddProduct("07ddb96c-3626-4d0c-82dd-68c51721bbef", "Witcher 3", 129.99, 18);
//            dataRepository.AddProduct("2511c7f3-9bb1-47d5-850b-e34a5d8e8f15", "Diablo 3", 339.99, 18);

//            dataRepository.AddState("e96eba92-47f0-41dc-9c77-d8929e08691b", "2f2b5a86-0feb-4ffc-aad2-1ecdae82aa92", 3);
//            dataRepository.AddState("e5a18edc-5cbb-4739-8d81-75d2f69de7da", "7e4d8099-892b-448d-aea7-73ac1df828a3", 10);
//            dataRepository.AddState("7aeded14-a6cf-4a4c-9f54-03ef98d48d58", "e60f4aa3-c545-47a7-8360-46d193ee0060", 5);
//            dataRepository.AddState("221435ce-9fcc-46b3-85ab-cf51f0524f9b", "d9dbc156-dca2-4d81-ad88-29f1230a4dcb", 8);
//            dataRepository.AddState("ff7878ad-6c56-4c7a-8e40-9f560f7deaa2", "07ddb96c-3626-4d0c-82dd-68c51721bbef", 6);
//            dataRepository.AddState("41aaece7-a579-464c-8474-dd576834a5e6", "2511c7f3-9bb1-47d5-850b-e34a5d8e8f15", 9);

//            dataRepository.AddEvent("4a93b8f8-a52d-43d6-90fa-3cf4e41c398e", "221435ce-9fcc-46b3-85ab-cf51f0524f9b", "81c14d82-528e-4933-b64b-a602499b17e7", "PurchaseEvent");
//            dataRepository.AddEvent("5c362e6f-a3c1-417a-a5de-b077b85e3f44", "221435ce-9fcc-46b3-85ab-cf51f0524f9b", "dc295f09-53ed-4293-876d-c91668fe9f67", "PurchaseEvent");
//            dataRepository.AddEvent("8f38e47d-4fb1-4b82-be29-b1544e95adc9", "e96eba92-47f0-41dc-9c77-d8929e08691b", "02c69ccc-e68a-4842-9f90-c086e3ba2555", "PurchaseEvent");
//            dataRepository.AddEvent("d260624e-81e5-474f-80ba-dcea4d781416", "e5a18edc-5cbb-4739-8d81-75d2f69de7da", "39ee2c48-3879-4ef2-b980-a7536517c0c8", "PurchaseEvent");
//            dataRepository.AddEvent("1c4ce5ac-d2be-44c1-83b1-06f30254b925", "7aeded14-a6cf-4a4c-9f54-03ef98d48d58", "5d82a11a-2d3c-4061-994b-aa857a62afab", "PurchaseEvent");
//            dataRepository.AddEvent("c05cd328-7f9d-4b0b-8f4b-7ae76943a239", "41aaece7-a579-464c-8474-dd576834a5e6", "5d82a11a-2d3c-4061-994b-aa857a62afab", "PurchaseEvent");
//            dataRepository.AddEvent("5552a672-9981-42a2-b0e6-52f493beb75d", "e5a18edc-5cbb-4739-8d81-75d2f69de7da", "979861af-d81f-4217-b465-9eb7bea24077", "PurchaseEvent");
//            dataRepository.AddEvent("14a31059-c4b8-46b3-9d34-aecf673226c2", "ff7878ad-6c56-4c7a-8e40-9f560f7deaa2", "d808b909-c9de-4352-9f07-ed3a76ed8dfb", "PurchaseEvent");
//            dataRepository.AddEvent("22b919c1-5b32-4dd5-ba0e-9409f56eb664", "e5a18edc-5cbb-4739-8d81-75d2f69de7da", "bd7a5ac6-eb2a-46a0-86d2-61b6bc4c4b5b", "PurchaseEvent");
//            dataRepository.AddEvent("2260378f-05f2-4d6b-b47b-3b7924ab6cb1", "e96eba92-47f0-41dc-9c77-d8929e08691b", "9f7005aa-7d18-4a20-bb58-a8f021a12168", "PurchaseEvent");

//            dataRepository.AddEvent("5ae736a7-793e-4e2c-84c3-dc8b7d9ff648", "7aeded14-a6cf-4a4c-9f54-03ef98d48d58", "5d82a11a-2d3c-4061-994b-aa857a62afab", "ReturnEvent");
//            dataRepository.AddEvent("7bad89f8-6cbe-4e47-aa3d-3e1e44a370e2", "221435ce-9fcc-46b3-85ab-cf51f0524f9b", "dc295f09-53ed-4293-876d-c91668fe9f67", "ReturnEvent");
//            dataRepository.AddEvent("fa8b45ba-0589-4e50-b77f-e9774852762b", "e96eba92-47f0-41dc-9c77-d8929e08691b", "9f7005aa-7d18-4a20-bb58-a8f021a12168", "ReturnEvent");
//            dataRepository.AddEvent("4c47667f-08f3-46da-a4a4-6541d9fc7650", "e5a18edc-5cbb-4739-8d81-75d2f69de7da", "979861af-d81f-4217-b465-9eb7bea24077", "ReturnEvent");

//            dataRepository.AddEvent("a12f6a91-e8e1-4e3a-bf0d-8bce65aa4ea9", "e96eba92-47f0-41dc-9c77-d8929e08691b", "4e6ea13b-a3f7-433c-bafc-0303ef70495c", "SupplyEvent", 10);
//            dataRepository.AddEvent("a3324ac5-7321-48f1-86b6-72153bf46871", "e5a18edc-5cbb-4739-8d81-75d2f69de7da", "4e6ea13b-a3f7-433c-bafc-0303ef70495c", "SupplyEvent", 12);
//            dataRepository.AddEvent("ab733a46-c282-499f-b99a-6dc757882ac7", "7aeded14-a6cf-4a4c-9f54-03ef98d48d58", "4e6ea13b-a3f7-433c-bafc-0303ef70495c", "SupplyEvent", 20);
//            dataRepository.AddEvent("5684415a-5e25-4412-8d5a-cfc3b691dd9b", "221435ce-9fcc-46b3-85ab-cf51f0524f9b", "4e6ea13b-a3f7-433c-bafc-0303ef70495c", "SupplyEvent", 7);
//            dataRepository.AddEvent("edb84553-f700-460f-90d0-fb02610b0d61", "ff7878ad-6c56-4c7a-8e40-9f560f7deaa2", "4e6ea13b-a3f7-433c-bafc-0303ef70495c", "SupplyEvent", 5);
//            dataRepository.AddEvent("e71f51ed-21cb-41f3-9d40-b21cb46506bd", "41aaece7-a579-464c-8474-dd576834a5e6", "4e6ea13b-a3f7-433c-bafc-0303ef70495c", "SupplyEvent", 9);
//        }
//    }
//}
