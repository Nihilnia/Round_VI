using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Overture.Areas.Database
{
    public static class GridProcesses
    {
        public static void AddMovie(string daUsername, string daMovieName)
        {
            using (var DB = new OvertureContext())
            {
                var findUser = DB.Users.Where(f => f.UserName == daUsername).FirstOrDefault();
                var newMovie = new Movie() { Name = daMovieName };
                findUser.Movies.Add(newMovie);
                DB.SaveChanges();
            }
        }

        public static void UpdateMovie(string daMovieName)
        {
            using (var DB = new OvertureContext())
            {
                var findMovie = DB.Movies.Where(f => f.Name == daMovieName).FirstOrDefault();

                DB.SaveChanges();
            }
        }

        public static void DeleteMovie(string daMovieName)
        {
            using (var DB = new OvertureContext())
            {
                var findMovie = DB.Movies.Where(f => f.Name == daMovieName).FirstOrDefault();
                DB.Movies.Remove(findMovie);

                DB.SaveChanges();
            }
        }
    }
}