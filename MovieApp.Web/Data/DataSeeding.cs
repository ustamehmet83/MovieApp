using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Web.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Data
{
    public static class DataSeeding
    {

        public static void Seed(IApplicationBuilder app)
        {

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate();
            var genres = new List<Genre>()
             {
            new Genre{Name="Macera",Movies=new List<Movie>()
                                        {

                           new Movie
                            {

                                Title = "film 1",
                                Description = "açıklama 1",
                                ImageUrl = "1.jpg",


                            },
                            new Movie
                            {

                                Title = "film 2",
                                Description = "açıklama 2",
                                ImageUrl = "2.jpg",

                            },





                   } },
            new Genre{Name="Komedi" },
            new Genre{Name="Romantik" },
            new Genre{Name="Savaş" },
            new Genre{Name="Bilim Kurgu" },
            };
            var movies = new List<Movie>()
                        {

                            new Movie
                            {

                                Title = "film 1",
                                Description = "açıklama 1",
                                ImageUrl = "1.jpg",
                                Genres=new List<Genre>(){ genres[0], genres[1] }

                            },
                            new Movie
                            {

                                Title = "film 2",
                                Description = "açıklama 2",
                                ImageUrl = "2.jpg",
                                Genres=new List<Genre>(){ genres[1], genres[2] }
                            },
                            new Movie
                            {

                                Title = "film 3",
                                Description = "açıklama 3",
                                ImageUrl = "3.jpg",
                                Genres=new List<Genre>(){ genres[3], genres[2] }
                            },

                            new Movie
                            {

                                Title = "film 1",
                                Description = "açıklama 1",
                                ImageUrl = "1.jpg",
                                Genres=new List<Genre>(){ genres[1], genres[3] }
                            },
                            new Movie
                            {

                                Title = "film 2",
                                Description = "açıklama 2",
                                ImageUrl = "2.jpg",
                                Genres=new List<Genre>(){ genres[2], genres[0] }

                            },
                            new Movie
                            {

                                Title = "film 3",
                                Description = "açıklama 3",
                                ImageUrl = "3.jpg",
                                Genres=new List<Genre>(){ genres[0], genres[1] }
                            },

                      };
            var users = new List<User>()
            {
                new User(){ Username="usera",Email="user@gmail.com",Password="1234",ImageUrl="person1.jpg"},
                new User(){ Username="userb",Email="user@gmail.com",Password="1234",ImageUrl="person2.jpg"},
                new User(){ Username="userc",Email="user@gmail.com",Password="1234",ImageUrl="person3.jpg"}

            };
            var people = new List<Person>()
            {
                new Person()
                {
                        Name="Personel1",
                        Biography="Tanıtım 1",
                        User=users[0]
                },
                new Person()
                {
                        Name="Personel2",
                        Biography="Tanıtım 2",
                        User=users[1]
                }

            };
            var crews = new List<Crew>()
            {

            new Crew(){ Movie=movies[0],Person=people[0],Job="Yönetmen" },
            new Crew(){ Movie=movies[0],Person=people[1],Job="Yönetmen Yard." },







            };
            var casts = new List<Cast>()
            {

                new Cast(){ Movie=movies[0],Person=people[0],Name="Oyuncu Adı 1",Character="Karakter 1"},
                new Cast(){ Movie=movies[0],Person=people[1],Name="Oyuncu Adı 2",Character="Karakter 1"},

            };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {


                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }

                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(movies);
                }

                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(users);
                }

                if (context.People.Count() == 0)
                {
                    context.People.AddRange(people);
                }

                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(casts);
                }

                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }

                context.SaveChanges();
            }


        }



    }
}
