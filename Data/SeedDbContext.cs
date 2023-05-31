using BookingHotelsAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookingHotelsAPI.Data
{
    public static class SeedDbContext
    {
        public static async Task SeedDbContextAsync(this AppDbContext context)
        {
            if(!context.Hotels.Any())
            {
                List<Hotel> hotels = new List<Hotel>
                {
                    new Hotel
                    {
                        Name = "Four Seasons Hotel Cairo at Nile Plaza",
                        City = "Cairo",
                        ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/94190040.jpg?k=ef1c7c9927dbc4c9bb8ade64114c12302c1490a01530fec267460efffb8fdf47&o=&hp=1",
                        Country = "Egypt",
                        PriceOfNight = 250
                    },
                    new Hotel
                    {
                        Name = "The Oberoi, Sahl Hasheesh",
                        City = "Hurghada",
                        ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/67620966.jpg?k=884f4b5ca18df9e32dea5f80695dfc8935ba6cd39b7d3ed24417288b17ede227&o=&hp=1",
                        Country = "Egypt",
                        PriceOfNight = 300
                    },
                    new Hotel
                    {
                        Name = "Sofitel Legend Old Cataract Aswan",
                        City = "Aswan",
                        ImageUrl = "https://www.ahstatic.com/photos/1666_ho_00_p_1024x768.jpg",
                        Country = "Egypt",
                        PriceOfNight = 200
                    },
                    new Hotel
                    {
                        Name = "Mena House Hotel",
                        City = "Giza",
                        ImageUrl = "https://nohomejustroam.com/wp-content/uploads/2021/08/Marriott-Mena-House-Cairo-Egypt-View-of-the-Pyramids-of-Giza-from-139-Restaurant.jpg",
                        Country = "Egypt",
                        PriceOfNight = 150
                    },
                    new Hotel
                    {
                        Name = "Steigenberger Nile Palace Luxor Hotel & Convention Center",
                        City = "Luxor",
                        ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/413769909.jpg?k=736a61c5de49250d0c9bcb3d8c6f4d18ed61c2f6f5d62995ea76f8e9dcd94a11&o=&hp=1",
                        Country = "Egypt",
                        PriceOfNight = 120
                    },
                    new Hotel
                    {
                        Name = "Hilton Hurghada Resort",
                        City = "Hurghada",
                        ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/8e/48/42/hilton-hurghada-plaza.jpg?w=700&h=-1&s=1",
                        Country = "Egypt",
                        PriceOfNight = 100
                    },
                    new Hotel
                    {
                        Name = "Kempinski Hotel Soma Bay",
                        City = "Soma Bay",
                        ImageUrl = "https://www.fivestaralliance.com/files/fivestaralliance.com/field/image/nodes/2010/14272/14272_0_kempinskihotelsomabay_fsa-g.jpg",
                        Country = "Egypt",
                        PriceOfNight = 180
                    },
                    new Hotel
                    {
                        Name = "Maritim Jolie Ville Resort & Casino Sharm El Sheikh",
                        City = "Sharm El Sheikh",
                        ImageUrl = "https://www.maritim.com/fileadmin/_processed_/b/4/csm_EG-SRC_173_Sport-Area_1e9d634528.jpg",
                        Country = "Egypt",
                        PriceOfNight = 90
                    },
                    new Hotel
                    {
                        Name = "Sheraton Cairo Hotel & Casino",
                        City = "Cairo",
                        ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/439247892.jpg?k=6e07aba5d277c47db92817132518f1a80ba6e7b1d4aae2dc58e3d1fcff46267f&o=&hp=1",
                        Country = "Egypt",
                        PriceOfNight = 120
                    },
                    new Hotel
                    {
                        Name = "Rixos Sharm El Sheikh",
                        City = "Sharm El Sheikh",
                        ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0a/b8/2e/1d/exterior-view.jpg?w=700&h=-1&s=1",
                        Country = "Egypt",
                        PriceOfNight = 150
                    }
                };

                context.Hotels.AddRange(hotels);

                await context.SaveChangesAsync();
            }

            if(!context.Users.Any())
            {
                // Password to be seeded
                string plainPassword = "P@ssw0rd";

                // Create an instance of PasswordHasher
                var passwordHasher = new PasswordHasher<User>();

                // Hash the password
                string hashedPassword = passwordHasher.HashPassword(null, plainPassword);

                List<User> users = new List<User>
                {
                    new User
                    {
                        FirstName = "Abdulrahman",
                        LastName = "Nader",
                        PictureUrl = "https://www.abdulrahmanxso25.me/assets/profile.png",
                        Country = "Egypt",
                        Email = "AbdulrahmanNader@xso25.org",
                        UserName = "AbdulrahmanNader",
                        NormalizedUserName = "AbdulrahmanNader".ToUpper(),
                        PasswordHash = hashedPassword
                    },
                    new User
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        PictureUrl = "https://img.freepik.com/free-icon/user_318-159711.jpg?w=360",
                        Country = "United States",
                        Email = "john.doe@example.com",
                        UserName = "john.doe",
                        NormalizedUserName = "john.doe".ToUpper(),
                        PasswordHash = hashedPassword
                    },
                    new User
                    {
                        FirstName = "Alice",
                        LastName = "Smith",
                        PictureUrl = "https://img.freepik.com/free-icon/user_318-159711.jpg?w=360",
                        Country = "Canada",
                        Email = "alice.smith@example.com",
                        UserName = "alice.smith",
                        NormalizedUserName = "alice.smith".ToUpper(),
                        PasswordHash = hashedPassword
                    },
                    new User
                    {
                        FirstName = "Michael",
                        LastName = "Johnson",
                        PictureUrl = "https://img.freepik.com/free-icon/user_318-159711.jpg?w=360",
                        Country = "Australia",
                        Email = "michael.johnson@example.com",
                        UserName = "michael.johnson",
                        NormalizedUserName = "michael.johnson".ToUpper(),
                        PasswordHash = hashedPassword
                    }
                };

                context.Users.AddRange(users);

                await context.SaveChangesAsync();
            }

            if(!context.Roles.Any())
            {
                List<IdentityRole> roles = new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "User",
                        NormalizedName = "User".ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    }
                };

                context.Roles.AddRange(roles);

                await context.SaveChangesAsync();
            }
        }
    }
}
