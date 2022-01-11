using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Overture.Areas.Database
{
    public static class AdminDatabaseProcesses
    {
        public static User GetAdmin(string daMFAdmin)
        {
            var aooof = new User();

            using (var DB = new OvertureContext())
            {
                var findAdmin = DB.Users.Where(f => f.UserName == daMFAdmin).FirstOrDefault();

                if (findAdmin != null)
                {
                    aooof = findAdmin;
                }
            }

            return aooof;
        }

        public static bool Register(string daAdminName, string daAdminPass, int daRole)
        {
            bool result = false;

            using (var DB = new OvertureContext())
            {
                var cryptedPass = Crypt.Gloria(daAdminPass);

                var newAdmin = new User()
                {
                    UserName = daAdminName,
                    Password = cryptedPass,
                    Role = daRole
                };

                DB.Users.Add(newAdmin);
                DB.SaveChanges();

                result = true;
            }

            return result;
        }


        public static bool LoginControl(string daAdminName, string daPassWord)
        {
            var result = false;

            using (var DB = new OvertureContext())
            {

                var findAdmin = DB.Users.Where(f => f.UserName == daAdminName).FirstOrDefault();

                if (findAdmin != null)
                {
                    var cryptedPass = Crypt.Gloria(daPassWord);
                    //var crypt_2 = Crypt.Gloria("666");

                    if (findAdmin.Password == cryptedPass)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public static bool Update(User incomingInfos)
        {
            bool result = false;

            using (var DB = new OvertureContext())
            {
                //
            }

            return result;
        }

        public static void Delete()
        {
            //
        }
    }
}