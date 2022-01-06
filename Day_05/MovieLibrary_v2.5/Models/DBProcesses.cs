using Microsoft.EntityFrameworkCore;
using MovieLibrary_v2._5.Models.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MovieLibrary_v2._5.Models
{
    public static class DBProcesses
    {

        //ALL INTEL OF USER
        public static User GetUserIntel(string daUserName)
        {
            var findUser = new User();

            using (var DB = new MovieLibraryContext())
            {
                //var theUser = DB.Users.Where(f => f.UserName == daUserName).Include(m => m.Movies).FirstOrDefault();

                
                var query = DB.Users.Where(f => f.UserName == daUserName).Include(m => m.Movies);
                

                //var theUser = DB.Users.FromSqlRaw(@"SELECT * FROM Users AS Usr
                //                                    INNER JOIN Movies AS Mov
                //                                    ON Usr.ID = Mov.UserID
                //                                    INNER JOIN Categories AS Cat
                //                                    ON Mov.ID = Cat.MovieID");

                findUser = DB.Users.Where(f => f.UserName == daUserName).FirstOrDefault();
            }

            return findUser;
        }


        //REGISTER
        public static bool Register(string daUserName, string daPassWord, int daRole)
        {
            var result = false;

            var newUser = new User() { UserName = daUserName, Password = daPassWord, Role = daRole };

            using (var DB = new MovieLibraryContext())
            {
                if (DB.Users.Where(f => f.UserName == newUser.UserName).FirstOrDefault() != null)
                {
                    result = false;
                }
                else
                {
                    result = true;
                    DB.Users.Add(newUser);
                    DB.SaveChanges();
                }
            }

            return result;
        }


        //LOGIN
        public static bool LoginControl(string daUserName, string daPassWord)
        {
            var result = false;

            var incominUser = new User() { UserName= daUserName, Password = daPassWord };

            using (var DB = new MovieLibraryContext())
            {
                var findUser = DB.Users.Where(f => f.UserName == daUserName).FirstOrDefault();

                if (findUser != null)
                {
                    if (findUser.Password == incominUser.Password)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }




        //UPDATE
        public static void UpdateUser(string daUserName, string passWord, string firstName, string lastName, string eMail, string profilePP)
        {
            using (var DB = new MovieLibraryContext())
            {
                var theUser = DB.Users.Where(f => f.UserName == daUserName).FirstOrDefault();

                if (theUser != null)
                {
                    theUser.FirstName = firstName;
                    theUser.LastName = lastName;
                    theUser.EMail = eMail;
                    theUser.ProfilePic = profilePP;

                    DB.SaveChanges();
                }
            }
        }




        //DELETE USER
        public static bool DeleteUser(string daUserName)
        {
            var result = false;

            using (var DB = new MovieLibraryContext())
            {
                var theUser = DB.Users.Where(f => f.UserName == daUserName).FirstOrDefault();

                if (theUser != null)
                {
                    DB.Users.Remove(theUser);
                    DB.SaveChanges();

                    result = true;
                }
            }

            return result;
        }



        //                                                             MOVIE THINGS


        // ADD
        public static bool AddMovie(string daMovieName, User daUser)
        {
            var result = false;

            var newMovie = new Movie() { Name = daMovieName, UserID = daUser.ID};

            using (var DB = new MovieLibraryContext())
            {
                DB.Movies.Add(newMovie);
                DB.SaveChanges();

                result = true;
            }

            return result;
        }

        //DELETE
        public static bool DeleteMovie(string daMovieName)
        {
            var result = false;

            using (var DB = new MovieLibraryContext())
            {
                var theMovie = DB.Movies.Where(f => f.Name == daMovieName).FirstOrDefault();

                if (theMovie != null)
                {
                    DB.Movies.Remove(theMovie);
                    DB.SaveChanges();

                    result = true;
                }

                
            }

            return result;
        }

        //READ
        public static List<Movie> GetMovies(User daUser)
        {
            var fukinUserMovies = new List<Movie>();

            using (var DB = new MovieLibraryContext())
            {
                if (daUser != null)
                {
                    fukinUserMovies = DB.Movies.Where(f => f.UserID == daUser.ID).ToList();
                }
            }

            return fukinUserMovies;
        }


        //UPDATE
        public static bool UpdateMovie(string daMovieName, string newMovieName)
        {
            var result = false;

            using (var DB = new MovieLibraryContext())
            {
                var theMovie = DB.Movies.Where(f => f.Name == daMovieName).FirstOrDefault();

                if (theMovie != null)
                {
                    theMovie.Name = newMovieName;
                    DB.SaveChanges();

                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

    }
}