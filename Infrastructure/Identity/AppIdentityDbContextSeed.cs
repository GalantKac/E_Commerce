using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Jan",
                    Email = "jak@k.pl",
                    UserName = "jak@k.pl",
                    Address = new Address
                    {
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        Street = "Jana Kowala 99",
                        City = "Warszawa",
                        State = "Mazowieckie",
                        Zipcode = "1"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        } 
    }
}
