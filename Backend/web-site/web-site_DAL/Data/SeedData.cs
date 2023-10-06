using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using web_site_Domain.Enums;
using web_site_Domain.Models;

namespace web_site_DAL.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //uncomment @return@ if you are making a migration or update-database command
            //comment @return@ if you want to seed data

            //return;

            using (var context = new WebSiteDbContext(serviceProvider.GetRequiredService<DbContextOptions<WebSiteDbContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Users.Any())
                {
                    return;
                }

                var comments = new List<Comment>();                      // ++
                var designs = new List<Design>();                        // ++
                var images = new List<ImageUrl>();                       // ++
                var likes = new List<Like>();                            // ++
                var locations = new List<Location>();                    // ++
                var posts = new List<Post>();                            // ++
                var postCategories = new List<PostCategory>();           // ++
                var realEstates = new List<RealEstate>();                // ++
                var rents = new List<Rent>();                            // ++
                var subscriptions = new List<Subscription>();            // ++
                var complexes = new List<ResidentialComplex>();          // --


                images = new List<ImageUrl>
                {
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},

                    //for design
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},

                    //for rent
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},

                    //for real estate
                        //new buildings
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        //other real estate statuses
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    
                    //for posts
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test2.png", FileName = "test2.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test2.png", FileName = "test2.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test2.png", FileName = "test2.png"},
                    new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},

                    //for real estate again
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                        new ImageUrl {Url = "https://documentsinhome.blob.core.windows.net/images/test1.png", FileName = "test1.png"},
                };
                context.ImageUrls.AddRange(images);

                var users = new List<User>
                {
                    new User { Name = "Name_1", Surname = "Surname_1", Email="Email_1@test.com", Password = "1234", Phone="Phone_1", Role = Role.Admin   , UserType = UserType.Individual, Information = "Info_1"},
                    new User { Name = "Name_2", Surname = "Surname_2", Email="Email_2@test.com", Password = "1234", Phone="Phone_2", Role = Role.Customer, UserType = UserType.Agency, Information = "Info_2"},
                    new User { Name = "Name_3", Surname = "Surname_3", Email="Email_3@test.com", Password = "1234", Phone="Phone_3", Role = Role.Customer, UserType = UserType.DesignStudio, Information = "Info_3"},
                    new User { Name = "Name_4", Surname = "Surname_4", Email="Email_4@test.com", Password = "1234", Phone="Phone_4", Role = Role.Customer, UserType = UserType.Developer, Information = "Info_4"},
                    new User { Name = "Name_5", Surname = "Surname_5", Email="Email_5@test.com", Password = "1234", Phone="Phone_5", Role = Role.Customer, UserType = UserType.Individual, Information = "Info_5"},
                    new User { Name = "Name_6", Surname = "Surname_6", Email="Email_6@test.com", Password = "1234", Phone="Phone_6", Role = Role.Customer, UserType = UserType.Freelancer, Information = "Info_6"}
                };
                context.Users.AddRange(users);

                locations = new List<Location>
                {
                    new Location{ Country = "Ukraine", City = "Kyiv", Address = "Addr_1" },
                    new Location{ Country = "Ukraine", City = "Kyiv", Address = "Addr_2" },
                    new Location{ Country = "Ukraine", City = "Lviv", Address = "Addr_3" },
                    new Location{ Country = "Spain", City = "Madrid", Address = "Addr_4" }
                };
                context.Locations.AddRange(locations);
                context.SaveChanges();

                subscriptions = new List<Subscription>
                {
                    new Subscription{ ReceiverId = users.Find(e => e.Name == "Name_4").Id, SubscriberId = users.Find(u => u.Name == "Name_2").Id, Subscriber = users.Find(u => u.Name == "Name_2"), Receiver = users.Find(e => e.Name == "Name_4")},
                    new Subscription{ ReceiverId = users.Find(e => e.Name == "Name_4").Id, SubscriberId = users.Find(u => u.Name == "Name_3").Id, Subscriber = users.Find(u => u.Name == "Name_3"), Receiver = users.Find(e => e.Name == "Name_4")},
                    new Subscription{ ReceiverId = users.Find(e => e.Name == "Name_4").Id, SubscriberId = users.Find(u => u.Name == "Name_5").Id, Subscriber = users.Find(u => u.Name == "Name_5"), Receiver = users.Find(e => e.Name == "Name_4")},
                    new Subscription{ ReceiverId = users.Find(e => e.Name == "Name_4").Id, SubscriberId = users.Find(u => u.Name == "Name_6").Id, Subscriber = users.Find(u => u.Name == "Name_6"), Receiver = users.Find(e => e.Name == "Name_4")},
                    new Subscription{ ReceiverId = users.Find(e => e.Name == "Name_2").Id, SubscriberId = users.Find(u => u.Name == "Name_1").Id, Subscriber = users.Find(u => u.Name == "Name_1"), Receiver = users.Find(e => e.Name == "Name_2")},
                    new Subscription{ ReceiverId = users.Find(e => e.Name == "Name_4").Id, SubscriberId = users.Find(u => u.Name == "Name_1").Id, Subscriber = users.Find(u => u.Name == "Name_1"), Receiver = users.Find(e => e.Name == "Name_4")}
                };

                context.Subscriptions.AddRange(subscriptions);

                comments = new List<Comment>
                {
                    new Comment{    Text = "Text_1",  AuthorId = users.Find(u => u.Name == "Name_1").Id },
                    new Comment{    Text = "Text_2",  AuthorId = users.Find(u => u.Name == "Name_1").Id },
                    new Comment{    Text = "Text_3",  AuthorId = users.Find(u => u.Name == "Name_2").Id },
                    new Comment{    Text = "Text_4",  AuthorId = users.Find(u => u.Name == "Name_3").Id },
                    new Comment{    Text = "Text_5",  AuthorId = users.Find(u => u.Name == "Name_4").Id },
                    new Comment{    Text = "Text_6",  AuthorId = users.Find(u => u.Name == "Name_5").Id },
                    new Comment{    Text = "Text_7",  AuthorId = users.Find(u => u.Name == "Name_5").Id },
                    new Comment{    Text = "Text_8",  AuthorId = users.Find(u => u.Name == "Name_6").Id },
                    new Comment{    Text = "Text_9",  AuthorId = users.Find(e => e.Name == "Name_1").Id },
                    new Comment{    Text = "Text_10", AuthorId = users.Find(e => e.Name == "Name_1").Id },
                    new Comment{    Text = "Text_11", AuthorId = users.Find(e => e.Name == "Name_1").Id }
                };
                context.Comments.AddRange(comments);

                posts = new List<Post>
                {
                    new Post { Title = "PostTitle_1", Description = "PostDescription_1", UserId = users.Find(e => e.Name == "Name_4").Id, User = users.Find(e => e.Name == "Name_4"),Location = locations.First()                         , LocationId = locations.First().Id,                          Photos = images.GetRange(58,1),   Comments = comments.GetRange(0,4),   PostLikes = likes.Where(l => l.Id == 1).ToList()                          },
                    new Post { Title = "PostTitle_2", Description = "PostDescription_2", UserId = users.Find(e => e.Name == "Name_4").Id, User = users.Find(e => e.Name == "Name_4"),Location = locations.Find(l => l.Address == "Addr_2"), LocationId = locations.Find(l => l.Address == "Addr_2").Id, Photos = images.GetRange(59,1),   Comments = comments.GetRange(4,1),   PostLikes = likes.Where(l => l.Id == 1).ToList()                          },
                    new Post { Title = "PostTitle_3", Description = "PostDescription_3", UserId = users.Find(e => e.Name == "Name_4").Id, User = users.Find(e => e.Name == "Name_4"),Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, Photos = images.GetRange(60,1),   Comments = comments.GetRange(5,1),   PostLikes = likes.Where(l => l.UserId == 1).ToList()                      },
                    new Post { Title = "PostTitle_4", Description = "PostDescription_4", UserId = users.Find(e => e.Name == "Name_2").Id, User = users.Find(e => e.Name == "Name_2"),Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, Photos = images.GetRange(61,1),   Comments = comments.GetRange(6,2),   PostLikes = likes.Where(l => l.UserId == 1).ToList()                      },
                    new Post { Title = "PostTitle_5", Description = "PostDescription_5", UserId = users.Find(e => e.Name == "Name_4").Id, User = users.Find(e => e.Name == "Name_4"),Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, Photos = images.GetRange(62,2),   Comments = comments.GetRange(8,3),   PostLikes = likes.Where(l => l.UserId == 3).ToList()                      },
                    new Post { Title = "PostTitle_6", Description = "PostDescription_6", UserId = users.Find(e => e.Name == "Name_4").Id, User = users.Find(e => e.Name == "Name_4"),Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, Photos = images.GetRange(63,2),   Comments = null,                     PostLikes = likes.Where(l => l.UserId >= 4 && l.UserId <=6).ToList()      }
                };
                context.Posts.AddRange(posts);

                postCategories = new List<PostCategory>
                {
                    new PostCategory { CategoryName = "PostCategory_1", Posts = posts.GetRange(0,2)},
                    new PostCategory { CategoryName = "PostCategory_2", Posts = posts.GetRange(2,2)},
                    new PostCategory { CategoryName = "PostCategory_3", Posts = posts.GetRange(4,1)},
                    new PostCategory { CategoryName = "PostCategory_4", Posts = posts.GetRange(5,1)}
                };
                context.PostCategories.AddRange(postCategories);

                likes = new List<Like>
                {
                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find( u => u.Name == "Name_1").Id,           Post = posts.Find(p => p.Title == "PostTitle_1"), PostId = posts.Find(p => p.Title == "PostTitle_1").Id },
                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find( u => u.Name == "Name_1").Id,           Post = posts.Find(p => p.Title == "PostTitle_2"), PostId = posts.Find(p => p.Title == "PostTitle_2").Id },
                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Post = posts.Find(p => p.Title == "PostTitle_3"), PostId = posts.Find(p => p.Title == "PostTitle_3").Id },
                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find(u => u.Name == "Name_1").Id,            Post = posts.Find(p => p.Title == "PostTitle_4"), PostId = posts.Find(p => p.Title == "PostTitle_4").Id },
                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find(u => u.Name == "Name_1").Id,            Post = posts.Find(p => p.Title == "PostTitle_4"), PostId = posts.Find(p => p.Title == "PostTitle_4").Id },
                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find(u => u.Name == "Name_1").Id,            Post = posts.Find(p => p.Title == "PostTitle_4"), PostId = posts.Find(p => p.Title == "PostTitle_4").Id },
                    new Like { User = users.Find(u => u.Name == "Name_3"),              UserId = users.Find( u => u.Name == "Name_3").Id,           Post = posts.Find(p => p.Title == "PostTitle_5"), PostId = posts.Find(p => p.Title == "PostTitle_5").Id },
                    new Like { User = users.Find(u => u.Name == "Name_4"),              UserId = users.Find( u => u.Name == "Name_4").Id,           Post = posts.Find(p => p.Title == "PostTitle_6"), PostId = posts.Find(p => p.Title == "PostTitle_6").Id },
                    new Like { User = users.Find(u => u.Name == "Name_5"),              UserId = users.Find( u => u.Name == "Name_5").Id,           Post = posts.Find(p => p.Title == "PostTitle_6"), PostId = posts.Find(p => p.Title == "PostTitle_6").Id },
                    new Like { User = users.Find(u => u.Name == "Name_6"),              UserId = users.Find( u => u.Name == "Name_6").Id,           Post = posts.Find(p => p.Title == "PostTitle_6"), PostId = posts.Find(p => p.Title == "PostTitle_6").Id }
                };
                context.Likes.AddRange(likes);

                rents = new List<Rent>
                {
                    new Rent { Title = "RentTitle_1", Description = "Description_1", Price = 100, AdvertisingLabel = "Label_1", ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.OldBuilding, LivingSpace = 50.5f, MinimalRentPeriod = 3,  UserId = users[0].Id, User = users[0], Location = locations.Find(l => l.Address == "Addr_2"), LocationId = locations.Find(l => l.Address == "Addr_2").Id, PhotosUrls = images.GetRange(31,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_2", Description = "Description_2", Price = 200, AdvertisingLabel = "Label_2", ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 120f,  MinimalRentPeriod = 3,  UserId = users[1].Id, User = users[1], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(32,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_3", Description = "Description_3", Price = 100, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.OldBuilding, LivingSpace = 50.5f, MinimalRentPeriod = 3,  UserId = users[2].Id, User = users[2], Location = locations.Find(l => l.Address == "Addr_2"), LocationId = locations.Find(l => l.Address == "Addr_2").Id, PhotosUrls = images.GetRange(33,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_4", Description = "Description_4", Price = 200, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 60f,  MinimalRentPeriod = 7,  UserId = users[3].Id, User = users[3], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(34,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_5", Description = "Description_5", Price = 200, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 82f,  MinimalRentPeriod = 6,  UserId = users[4].Id, User = users[4], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(35,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_6", Description = "Description_6", Price = 500, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 70f,  MinimalRentPeriod = 3,  UserId = users[4].Id, User = users[4], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(36,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_7", Description = "Description_7", Price = 600, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 120f,  MinimalRentPeriod = 8,  UserId = users[0].Id, User = users[0], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(37,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_8", Description = "Description_8", Price = 700, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 80f,  MinimalRentPeriod = 8,  UserId = users[1].Id, User = users[1], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(38,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_9", Description = "Description_9", Price = 800, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 90f,  MinimalRentPeriod = 3,  UserId = users[2].Id, User = users[3], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(39,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_10", Description = "Description_10", Price = 900, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 90f,  MinimalRentPeriod = 3,  UserId = users[2].Id, User = users[3], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(40,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_11", Description = "Description_11", Price = 1000, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 90f,  MinimalRentPeriod = 3,  UserId = users[2].Id, User = users[3], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(41,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_12", Description = "Description_12", Price = 1100, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 90f,  MinimalRentPeriod = 3,  UserId = users[2].Id, User = users[3], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(42,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_13", Description = "Description_13", Price = 1200, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 90f,  MinimalRentPeriod = 3,  UserId = users[2].Id, User = users[3], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(43,1), CreationDate = DateTime.Now   },
                    new Rent { Title = "RentTitle_14", Description = "Description_14", Price = 1300, AdvertisingLabel = null, ProjectType = ProjectType.Rent, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 90f,  MinimalRentPeriod = 3,  UserId = users[2].Id, User = users[3], Location = locations.Find(l => l.Address == "Addr_3"), LocationId = locations.Find(l => l.Address == "Addr_3").Id, PhotosUrls = images.GetRange(44,1), CreationDate = DateTime.Now   },
                };
                context.Rents.AddRange(rents);

                designs = new List<Design>
                {
                    new Design { Title = "DesignTitle_1",  Description = "DesignDescription_1",  Price = 300, AdvertisingLabel = "DesignLabel_1",     ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.NewBuilding,         User = users.Find(e => e.Name == "Name_1"), UserId = users.Find(e => e.Name == "Name_1").Id,  PhotosUrls = images.GetRange(18,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_2",  Description = "DesignDescription_2",  Price = 600, AdvertisingLabel = null,                ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.UnderConstruction,   User = users.Find(e => e.Name == "Name_2"), UserId = users.Find(e => e.Name == "Name_2").Id,  PhotosUrls = images.GetRange(19,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_3",  Description = "DesignDescription_3",  Price = 400, AdvertisingLabel = "DesignLabel_3",     ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.OldBuilding,         User = users.Find(e => e.Name == "Name_3"), UserId = users.Find(e => e.Name == "Name_3").Id,  PhotosUrls = images.GetRange(20,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_4",  Description = "DesignDescription_4",  Price = 100, AdvertisingLabel = "DesignLabel_4",     ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.UnderConstruction,   User = users.Find(e => e.Name == "Name_1"), UserId = users.Find(e => e.Name == "Name_1").Id,  PhotosUrls = images.GetRange(21,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_5",  Description = "DesignDescription_5",  Price = 300, AdvertisingLabel = "DesignLabel_1",     ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.NewBuilding,         User = users.Find(e => e.Name == "Name_1"), UserId = users.Find(e => e.Name == "Name_1").Id,  PhotosUrls = images.GetRange(22,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_6",  Description = "DesignDescription_6",  Price = 600, AdvertisingLabel = "DesignLabel_2",     ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.UnderConstruction,   User = users.Find(e => e.Name == "Name_1"), UserId = users.Find(e => e.Name == "Name_1").Id,  PhotosUrls = images.GetRange(23,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_7",  Description = "DesignDescription_7",  Price = 400, AdvertisingLabel = "DesignLabel_3",     ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.OldBuilding,         User = users.Find(e => e.Name == "Name_1"), UserId = users.Find(e => e.Name == "Name_1").Id,  PhotosUrls = images.GetRange(24,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_8",  Description = "DesignDescription_8",  Price = 100, AdvertisingLabel = null,                ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.UnderConstruction,   User = users.Find(e => e.Name == "Name_2"), UserId = users.Find(e => e.Name == "Name_2").Id,  PhotosUrls = images.GetRange(25,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_9",  Description = "DesignDescription_9",  Price = 300, AdvertisingLabel = "DesignLabel_1",     ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.NewBuilding,         User = users.Find(e => e.Name == "Name_1"), UserId = users.Find(e => e.Name == "Name_1").Id,  PhotosUrls = images.GetRange(26,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_10", Description = "DesignDescription_10", Price = 600, AdvertisingLabel = "DesignLabel_2",   ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.UnderConstruction,   User = users.Find(e => e.Name == "Name_6"), UserId = users.Find(e => e.Name == "Name_6").Id,  PhotosUrls = images.GetRange(27,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_11", Description = "DesignDescription_11", Price = 400, AdvertisingLabel = null,              ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.OldBuilding,         User = users.Find(e => e.Name == "Name_5"), UserId = users.Find(e => e.Name == "Name_5").Id,  PhotosUrls = images.GetRange(28,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now },
                    new Design { Title = "DesignTitle_12", Description = "DesignDescription_12", Price = 100, AdvertisingLabel = "DesignLabel_4",   ProjectType = ProjectType.Design, RealEstateStatus = RealEstateStatus.UnderConstruction,   User = users.Find(e => e.Name == "Name_4"), UserId = users.Find(e => e.Name == "Name_4").Id,  PhotosUrls = images.GetRange(29,1),    Location = locations.Find(l => l.Address == "Addr_4"), LocationId = locations.Find(l => l.Address == "Addr_4").Id, CreationDate = DateTime.Now }
                };
                context.Designs.AddRange(designs);

                realEstates = new List<RealEstate>
                {
                    new RealEstate {Title = "RealEstateTitle_1",  Description = "RealEstateDescription_1",  Price = 123, AdvertisingLabel = "RealEstateLabel_1", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(58,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_2",  Description = "RealEstateDescription_2",  Price = 223, AdvertisingLabel = "RealEstateLabel_2", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_2").Id, User = users.Find(e => e.Name == "Name_2"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(59,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_3",  Description = "RealEstateDescription_3",  Price = 323, AdvertisingLabel = "RealEstateLabel_3", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_3").Id, User = users.Find(e => e.Name == "Name_3"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(60,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_4",  Description = "RealEstateDescription_4",  Price = 423, AdvertisingLabel = "RealEstateLabel_4", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_4").Id, User = users.Find(e => e.Name == "Name_4"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(61,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_5",  Description = "RealEstateDescription_5",  Price = 523, AdvertisingLabel = "RealEstateLabel_5", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_5").Id, User = users.Find(e => e.Name == "Name_5"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(62,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_7",  Description = "RealEstateDescription_7",  Price = 623, AdvertisingLabel = "RealEstateLabel_7", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_6").Id, User = users.Find(e => e.Name == "Name_6"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(45,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_8",  Description = "RealEstateDescription_8",  Price = 723, AdvertisingLabel = "RealEstateLabel_8", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(46,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_9",  Description = "RealEstateDescription_9",  Price = 823, AdvertisingLabel = "RealEstateLabel_9", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_2").Id, User = users.Find(e => e.Name == "Name_2"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(47,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_10", Description = "RealEstateDescription_10", Price = 923, AdvertisingLabel = "RealEstateLabel_10", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_3").Id, User = users.Find(e => e.Name == "Name_3"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(48,1), CreationDate = DateTime.Now   },

                    new RealEstate {Title = "RealEstateTitle_31", Description = "RealEstateDescription_31", Price = 1123, AdvertisingLabel = "RealEstateLabel_31",ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id,  PhotosUrls = images.GetRange(63,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_32", Description = "RealEstateDescription_32", Price = 5123, AdvertisingLabel = "RealEstateLabel_32",ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_2").Id, User = users.Find(e => e.Name == "Name_2"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id,  PhotosUrls = images.GetRange(64,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_33", Description = "RealEstateDescription_33", Price = 5223, AdvertisingLabel = "RealEstateLabel_33",ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_3").Id, User = users.Find(e => e.Name == "Name_3"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id,  PhotosUrls = images.GetRange(65,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_34", Description = "RealEstateDescription_34", Price = 5323, AdvertisingLabel = "RealEstateLabel_34",ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_4").Id, User = users.Find(e => e.Name == "Name_4"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id,  PhotosUrls = images.GetRange(66,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_35", Description = "RealEstateDescription_35", Price = 5423, AdvertisingLabel = "RealEstateLabel_35",ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_5").Id, User = users.Find(e => e.Name == "Name_5"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id,  PhotosUrls = images.GetRange(67,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_36", Description = "RealEstateDescription_36", Price = 5523, AdvertisingLabel = "RealEstateLabel_36",ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_6").Id, User = users.Find(e => e.Name == "Name_6"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id,  PhotosUrls = images.GetRange(68,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_38", Description = "RealEstateDescription_38", Price = 5623, AdvertisingLabel = "RealEstateLabel_38",ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id,  PhotosUrls = images.GetRange(69,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_39", Description = "RealEstateDescription_39", Price = 5723, AdvertisingLabel = "RealEstateLabel_39",ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_2").Id, User = users.Find(e => e.Name == "Name_2"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id,  PhotosUrls = images.GetRange(70,1), CreationDate = DateTime.Now   },
                    new RealEstate {Title = "RealEstateTitle_37", Description = "RealEstateDescription_37", Price = 5823, AdvertisingLabel = "RealEstateLabel_37", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.NewBuilding, LivingSpace = 125.5f, UserId = users.Find(e => e.Name == "Name_3").Id, User = users.Find(e => e.Name == "Name_3"),        Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(71,1), CreationDate = DateTime.Now   },

                    //
                    new RealEstate {Title = "RealEstateTitle_11", Description = "RealEstateDescription_11", Price = 1000, AdvertisingLabel = "RealEstateLabel_11", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.UnderConstruction,  LivingSpace = 77.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(49,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_12", Description = "RealEstateDescription_12", Price = 1100, AdvertisingLabel = "RealEstateLabel_12", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.OldBuilding,        LivingSpace = 77.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(50,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_13", Description = "RealEstateDescription_13", Price = 1200, AdvertisingLabel = "RealEstateLabel_13", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.UnderConstruction,  LivingSpace = 77.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(51,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_14", Description = "RealEstateDescription_14", Price = 1300, AdvertisingLabel = "RealEstateLabel_14", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.UnderConstruction,  LivingSpace = 77.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(52,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_15", Description = "RealEstateDescription_15", Price = 1400, AdvertisingLabel = "RealEstateLabel_15", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.OldBuilding,        LivingSpace = 77.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(53,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_16", Description = "RealEstateDescription_16", Price = 1500, AdvertisingLabel = "RealEstateLabel_16", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.OldBuilding,        LivingSpace = 77.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(54,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_18", Description = "RealEstateDescription_18", Price = 1600, AdvertisingLabel = "RealEstateLabel_18", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.UnderConstruction,  LivingSpace = 77.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(55,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_19", Description = "RealEstateDescription_19", Price = 1700, AdvertisingLabel = "RealEstateLabel_19", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.OldBuilding,        LivingSpace = 77.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(56,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_20", Description = "RealEstateDescription_20", Price = 1800, AdvertisingLabel = "RealEstateLabel_20", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.UnderConstruction,  LivingSpace = 77.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(57,1), CreationDate = DateTime.Now },

                    new RealEstate {Title = "RealEstateTitle_21", Description = "RealEstateDescription_21", Price = 2000, AdvertisingLabel = "RealEstateLabel_21", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.UnderConstruction,  LivingSpace = 97.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(72,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_22", Description = "RealEstateDescription_22", Price = 3000, AdvertisingLabel = "RealEstateLabel_22", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.OldBuilding,        LivingSpace = 57.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(73,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_23", Description = "RealEstateDescription_23", Price = 4000, AdvertisingLabel = "RealEstateLabel_23", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.UnderConstruction,  LivingSpace = 87.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(74,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_24", Description = "RealEstateDescription_24", Price = 5000, AdvertisingLabel = "RealEstateLabel_24", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.UnderConstruction,  LivingSpace = 27.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(75,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_25", Description = "RealEstateDescription_25", Price = 6000, AdvertisingLabel = "RealEstateLabel_25", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.OldBuilding,        LivingSpace = 17.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(76,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_26", Description = "RealEstateDescription_26", Price = 7000, AdvertisingLabel = "RealEstateLabel_26", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.OldBuilding,        LivingSpace = 37.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(77,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_27", Description = "RealEstateDescription_27", Price = 8000, AdvertisingLabel = "RealEstateLabel_27", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.UnderConstruction,  LivingSpace = 47.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(78,1), CreationDate = DateTime.Now },
                    new RealEstate {Title = "RealEstateTitle_28", Description = "RealEstateDescription_28", Price = 9000, AdvertisingLabel = "RealEstateLabel_28", ProjectType = ProjectType.RealEstate, RealEstateStatus = RealEstateStatus.OldBuilding,        LivingSpace = 57.7f, UserId = users.Find(e => e.Name == "Name_1").Id, User = users.Find(e => e.Name == "Name_1"),  Location = locations.Find(l => l.Address == "Addr_1"), LocationId = locations.Find(l => l.Address == "Addr_1").Id, PhotosUrls = images.GetRange(79,1), CreationDate = DateTime.Now },
                };
                context.RealEstates.AddRange(realEstates);

                likes = new List<Like>
                {
                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find( u => u.Name == "Name_1").Id,           Post = posts.Find(p => p.Title == "PostTitle_1"), PostId = posts.Find(p => p.Title == "PostTitle_1").Id },
                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find( u => u.Name == "Name_1").Id,           Post = posts.Find(p => p.Title == "PostTitle_2"), PostId = posts.Find(p => p.Title == "PostTitle_2").Id },
                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Post = posts.Find(p => p.Title == "PostTitle_3"), PostId = posts.Find(p => p.Title == "PostTitle_3").Id },
                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find(u => u.Name == "Name_1").Id,            Post = posts.Find(p => p.Title == "PostTitle_4"), PostId = posts.Find(p => p.Title == "PostTitle_4").Id },
                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find(u => u.Name == "Name_2").Id,            Post = posts.Find(p => p.Title == "PostTitle_4"), PostId = posts.Find(p => p.Title == "PostTitle_4").Id },
                    new Like { User = users.Find(u => u.Name == "Name_3"),              UserId = users.Find(u => u.Name == "Name_3").Id,            Post = posts.Find(p => p.Title == "PostTitle_4"), PostId = posts.Find(p => p.Title == "PostTitle_4").Id },
                    new Like { User = users.Find(u => u.Name == "Name_3"),              UserId = users.Find( u => u.Name == "Name_3").Id,           Post = posts.Find(p => p.Title == "PostTitle_5"), PostId = posts.Find(p => p.Title == "PostTitle_5").Id },
                    new Like { User = users.Find(u => u.Name == "Name_4"),              UserId = users.Find( u => u.Name == "Name_4").Id,           Post = posts.Find(p => p.Title == "PostTitle_6"), PostId = posts.Find(p => p.Title == "PostTitle_6").Id },
                    new Like { User = users.Find(u => u.Name == "Name_5"),              UserId = users.Find( u => u.Name == "Name_5").Id,           Post = posts.Find(p => p.Title == "PostTitle_6"), PostId = posts.Find(p => p.Title == "PostTitle_6").Id },
                    new Like { User = users.Find(u => u.Name == "Name_6"),              UserId = users.Find( u => u.Name == "Name_6").Id,           Post = posts.Find(p => p.Title == "PostTitle_6"), PostId = posts.Find(p => p.Title == "PostTitle_6").Id },

                    //for rent
                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find( u => u.Name == "Name_1").Id,           Project = rents.Find(p => p.Title == "RentTitle_1"), ProjectId = rents.Find(p => p.Title == "RentTitle_1").Id },
                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Project = rents.Find(p => p.Title == "RentTitle_1"), ProjectId = rents.Find(p => p.Title == "RentTitle_1").Id },
                    new Like { User = users.Find(u => u.Name == "Name_3"),              UserId = users.Find( u => u.Name == "Name_3").Id,           Project = rents.Find(p => p.Title == "RentTitle_1"), ProjectId = rents.Find(p => p.Title == "RentTitle_1").Id },

                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find( u => u.Name == "Name_1").Id,           Project = rents.Find(p => p.Title == "RentTitle_2"), ProjectId = rents.Find(p => p.Title == "RentTitle_2").Id },
                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Project = rents.Find(p => p.Title == "RentTitle_2"), ProjectId = rents.Find(p => p.Title == "RentTitle_2").Id },
                    new Like { User = users.Find(u => u.Name == "Name_3"),              UserId = users.Find( u => u.Name == "Name_3").Id,           Project = rents.Find(p => p.Title == "RentTitle_2"), ProjectId = rents.Find(p => p.Title == "RentTitle_2").Id },
                    new Like { User = users.Find(u => u.Name == "Name_4"),              UserId = users.Find( u => u.Name == "Name_4").Id,           Project = rents.Find(p => p.Title == "RentTitle_2"), ProjectId = rents.Find(p => p.Title == "RentTitle_2").Id },

                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Project = rents.Find(p => p.Title == "RentTitle_3"), ProjectId = rents.Find(p => p.Title == "RentTitle_3").Id },

                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Project = rents.Find(p => p.Title == "RentTitle_4"), ProjectId = rents.Find(p => p.Title == "RentTitle_4").Id },

                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Project = rents.Find(p => p.Title == "RentTitle_5"), ProjectId = rents.Find(p => p.Title == "RentTitle_5").Id },

                    new Like { User = users.Find(u => u.Name == "Name_6"),              UserId = users.Find( u => u.Name == "Name_6").Id,           Project = rents.Find(p => p.Title == "RentTitle_6"), ProjectId = rents.Find(p => p.Title == "RentTitle_6").Id },
                    
                    new Like { User = users.Find(u => u.Name == "Name_4"),              UserId = users.Find( u => u.Name == "Name_4").Id,           Project = rents.Find(p => p.Title == "RentTitle_7"), ProjectId = rents.Find(p => p.Title == "RentTitle_7").Id },

                    new Like { User = users.Find(u => u.Name == "Name_3"),              UserId = users.Find( u => u.Name == "Name_3").Id,           Project = rents.Find(p => p.Title == "RentTitle_8"), ProjectId = rents.Find(p => p.Title == "RentTitle_8").Id }, 

                    //for design
                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find( u => u.Name == "Name_1").Id,           Project = designs.Find(p => p.Title == "DesignTitle_1"), ProjectId = designs.Find(p => p.Title == "DesignTitle_1").Id },
                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Project = designs.Find(p => p.Title == "DesignTitle_1"), ProjectId = designs.Find(p => p.Title == "DesignTitle_1").Id },
                    new Like { User = users.Find(u => u.Name == "Name_3"),              UserId = users.Find( u => u.Name == "Name_3").Id,           Project = designs.Find(p => p.Title == "DesignTitle_1"), ProjectId = designs.Find(p => p.Title == "DesignTitle_1").Id },

                    new Like { User = users.Find(u => u.Name == "Name_1"),              UserId = users.Find( u => u.Name == "Name_1").Id,           Project = designs.Find(p => p.Title == "DesignTitle_2"), ProjectId = designs.Find(p => p.Title == "DesignTitle_2").Id },
                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Project = designs.Find(p => p.Title == "DesignTitle_2"), ProjectId = designs.Find(p => p.Title == "DesignTitle_2").Id },
                    new Like { User = users.Find(u => u.Name == "Name_3"),              UserId = users.Find( u => u.Name == "Name_3").Id,           Project = designs.Find(p => p.Title == "DesignTitle_2"), ProjectId = designs.Find(p => p.Title == "DesignTitle_2").Id },
                    new Like { User = users.Find(u => u.Name == "Name_4"),              UserId = users.Find( u => u.Name == "Name_4").Id,           Project = designs.Find(p => p.Title == "DesignTitle_2"), ProjectId = designs.Find(p => p.Title == "DesignTitle_2").Id },

                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Project = designs.Find(p => p.Title == "DesignTitle_3"), ProjectId = designs.Find(p => p.Title == "DesignTitle_3").Id },

                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Project = designs.Find(p => p.Title == "DesignTitle_4"), ProjectId = designs.Find(p => p.Title == "DesignTitle_4").Id },

                    new Like { User = users.Find(u => u.Name == "Name_2"),              UserId = users.Find( u => u.Name == "Name_2").Id,           Project = designs.Find(p => p.Title == "DesignTitle_5"), ProjectId = designs.Find(p => p.Title == "DesignTitle_5").Id },

                    new Like { User = users.Find(u => u.Name == "Name_6"),              UserId = users.Find( u => u.Name == "Name_6").Id,           Project = designs.Find(p => p.Title == "DesignTitle_6"), ProjectId = designs.Find(p => p.Title == "DesignTitle_6").Id },

                    new Like { User = users.Find(u => u.Name == "Name_4"),              UserId = users.Find( u => u.Name == "Name_4").Id,           Project = designs.Find(p => p.Title == "DesignTitle_7"), ProjectId = designs.Find(p => p.Title == "DesignTitle_7").Id },

                    new Like { User = users.Find(u => u.Name == "Name_3"),              UserId = users.Find( u => u.Name == "Name_3").Id,           Project = designs.Find(p => p.Title == "DesignTitle_8"), ProjectId = designs.Find(p => p.Title == "DesignTitle_8").Id },               
                    
                };
                context.Likes.AddRange(likes);

                complexes = new List<ResidentialComplex>
                {
                    new ResidentialComplex {Name = "Complex_1", Description = "ComplexDescription_1", LocationId = 1, Apartments = realEstates.GetRange(0,1), User = users.Find(u => u.Name == "Name_1"), UserId = users.Find( u => u.Name == "Name_1").Id,  },
                    new ResidentialComplex {Name = "Complex_2", Description = "ComplexDescription_2", LocationId = 1, User = users.Find(u => u.Name == "Name_1"), UserId = users.Find( u => u.Name == "Name_1").Id,  },
                    new ResidentialComplex {Name = "Complex_3", Description = "ComplexDescription_3", LocationId = 1, User = users.Find(u => u.Name == "Name_1"), UserId = users.Find( u => u.Name == "Name_1").Id,   }
                };
                context.ResidentialComplexes.AddRange(complexes);

                context.SaveChanges();
            }
        }
    }
}

