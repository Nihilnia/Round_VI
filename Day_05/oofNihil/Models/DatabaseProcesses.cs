using oofNihil.Models.Database;

namespace oofNihil.Models
{
    public static class DatabaseProcesses
    {
        public static bool Register(string daUserName, string daPassword)
        {
            var result = false;

            using (var DB = new GloriaContext())
            {
                var newUser = new User() { UserName = daUserName, Password = daPassword };
                DB.Users.Add(newUser);
                DB.SaveChanges();

                result = true;
            }

            return result;
        }


        public static User LoginControl(string daUserName, string daPassword)
        {
            var user = new User();

            using (var DB = new GloriaContext())
            {
                var findUser = DB.Users.Where(f => f.UserName == daUserName).FirstOrDefault();

                if (findUser != null)
                {
                    if (findUser.Password == daPassword)
                    {
                        user = findUser;
                    }
                }
            }

            return user;
        }

        public static User GetUser(string daUserName)
        {
            var theUser = new User();

            using (var DB = new GloriaContext())
            {
                var findUser = DB.Users.Where(f => f.UserName == daUserName).FirstOrDefault();

                if (findUser != null)
                {   
                    theUser = findUser;
                }
            }

            return theUser;
        }
    }
}
