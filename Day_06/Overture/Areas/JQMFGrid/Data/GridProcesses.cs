using Microsoft.EntityFrameworkCore;
using Overture.Areas.User.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Overture.Areas.Database
{
    public static class GridProcesses
    {
        //TRY
        public static List<GridModel> GETMFGET(string daUserName)
        {
            var result = new List<GridModel>();

            using (var DB = new OvertureContext())
            {
                var findUser = DB.Users.Where(f => f.UserName == daUserName).FirstOrDefault();

                var userMovies = DB.Movies.Where(f => f.UserID == findUser.ID).Include(c => c.Categories).ToList();

                findUser.Movies = userMovies;

                foreach (var f in findUser.Movies)
                {
                    var movID = f.ID;
                    var movName = f.Name;
                    foreach (var c in f.Categories)
                    {
                        var catID = c.ID;
                        var catName = c.Name;

                        result.Add(new GridModel()
                        {
                            MovieID = movID,
                            MovieName = movName,
                            CategoryID = catID,
                            CategoryName = catName,
                        });
                    }
                }

            }

            return result;
        }


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