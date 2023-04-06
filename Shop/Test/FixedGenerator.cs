using Shop.Data;

namespace Shop.Test
{
    public class FixedGenerator : IGenerator
    {
        public void Generate(IDataContext Context) {
            User user1 = new User(null, "Mateusz", "Kowalski", "m_kowalski@gmail.com", 353,
                new DateTime(2013, 5, 21), 543234567);
            User user2 = new User(null, "Kamil", "Miglanc", "k_miglanc@gmail.com", 222,
                new DateTime(2011, 11, 22), 123908765);
            User user3 = new User(null, "Wladyslaw", "Tomislawowski", "w_tomislawowski@gmail.com", 12,
                new DateTime(2007, 4, 12), 578965335);
            User user4 = new User(null, "Joanna", "Dzoanna", "j_dzoanna@gmail.com", 332,
                new DateTime(2001, 10, 1), 236879098);
            User user5 = new User(null, "Michal", "Zahenkos", "m_Zahenkos@gmail.com", 1245,
                new DateTime(1999, 12, 2), 422344789);
            User user6 = new User(null, "Andrzej", "Tomislawowski", "a_Tomislawowski@gmail.com", 333,
                new DateTime(2003, 1, 22), 168332885);
            User user7 = new User(null, "Eivor", "Ravensthrope", "e_ravensthrope@ac.no", 500,
                new DateTime(1996, 11, 10), 849529364);
            User user8 = new User(null, "Seokjin", "Kim", "s_kim@naver.kr", 100000, 
                new DateTime(2005, 7, 8), 839049333);
            User user9 = new User(null, "Hermenegilda", "Bauenhaupt", "h_bauenhaupt@outlook.com", 5, 
                new DateTime(1998, 4, 19), 859302198);
            User user10 = new User(null, "Stefan", "Zapominalski", "s_zapominalski@gmail.com", 68,
                new DateTime(2003, 11, 8), 938575039);


            Context.Elements[typeof(IUser)].Add(user1.Guid, user1);
            Context.Elements[typeof(IUser)].Add(user2.Guid, user2);
            Context.Elements[typeof(IUser)].Add(user3.Guid, user3);
            Context.Elements[typeof(IUser)].Add(user4.Guid, user4);
            Context.Elements[typeof(IUser)].Add(user5.Guid, user5);
            Context.Elements[typeof(IUser)].Add(user6.Guid, user6);
            Context.Elements[typeof(IUser)].Add(user7.Guid, user7);
            Context.Elements[typeof(IUser)].Add(user8.Guid, user8);
            Context.Elements[typeof(IUser)].Add(user9.Guid, user9);
            Context.Elements[typeof(IUser)].Add(user10.Guid, user10);
        }
    }
}
