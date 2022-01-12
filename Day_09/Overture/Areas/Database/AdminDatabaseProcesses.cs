using Microsoft.EntityFrameworkCore;
using Overture.Areas.Admin.Data;
using Overture.Areas.User.Data;
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

        public static bool AddMovie(string adminName, string movieName, string category)
        {
            bool result = false;

            using (var DB = new OvertureContext())
            {
                var getAdmin = GetAdmin(adminName);

                var newCategory = new List<Category>()
                {
                    new Category() { Name = category }
                };

                var newMovie = new Movie() { Name = movieName, Categories = newCategory, UserID = getAdmin.ID};

                DB.Movies.Add(newMovie);
                DB.SaveChanges();

                result = true;
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

        public static AdminModel GetEverything(string adminName)
        {
            var mfEverything = new AdminModel();

            using (var DB = new OvertureContext())
            {
                var findAdmin = DB.Users.Where(f => f.UserName == adminName).FirstOrDefault();

                if (findAdmin != null)
                {
                    mfEverything.ID = findAdmin.ID;
                    mfEverything.UserName = findAdmin.UserName;
                    mfEverything.ProfilePic = findAdmin.ProfilePic;

                    var allMovies = DB.Movies.Include(c => c.Categories).ToList();

                    foreach (var movies in allMovies)
                    {
                        var movieID = movies.ID;
                        var movieName = movies.Name;

                        foreach (var cat in movies.Categories)
                        {
                            var categoryID = cat.ID;
                            var categoryName = cat.Name;

                            var daGridModel = new GridModel() { 
                                MovieID = movieID, 
                                MovieName = movieName, 
                                CategoryID = categoryID, 
                                CategoryName = categoryName
                            };

                            mfEverything.GridModel.Add(daGridModel);
                        }
                    }
                }
            }

            return mfEverything;
        }

        public static List<GridModel> GetAdminIntel()
        {
            var daGridModel = new List<GridModel>();

            using (var DB = new OvertureContext())
            {
                var allMovies = DB.Movies.Where(f => f.ID > 0).Include(c => c.Categories).ToList();

                foreach (var movie in allMovies)
                {
                    var daMovieID = movie.ID;
                    var daMovieName = movie.Name;

                    foreach (var cat in movie.Categories)
                    {
                        var daCategoryID = cat.ID;
                        var daCategoryName = cat.Name;

                        daGridModel.Add(new GridModel() { MovieID = daMovieID, MovieName = daMovieName, CategoryID = daCategoryID, CategoryName = daCategoryName});
                    }
                }
                
            }

            return daGridModel;
        }
    }
}