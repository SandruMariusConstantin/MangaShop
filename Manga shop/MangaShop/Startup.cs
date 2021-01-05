using MangaShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MangaShop.Startup))]
namespace MangaShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdminAndUserRoles();
        }

        private void CreateAdminAndUserRoles()
        {
            var ctx = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(
                            new RoleStore<IdentityRole>(ctx));
            var userManager = new UserManager<ApplicationUser>(
                            new UserStore<ApplicationUser>(ctx));

            //adaugam rolurile pe care le poate avea un utilizator din cadrul aplicatiei
            if (!roleManager.RoleExists("Admin"))
            {
                //adaugam rolul de administrator
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // se adauga utilizatorul administrator
                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";

                var adminCreated = userManager.Create(user, "Admin2020!");
                if (adminCreated.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Publisher"))
            {
                // adaugati rolul specific aplicatiei voastre
                var role = new IdentityRole();
                role.Name = "Publisher";
                roleManager.Create(role);

                // se adauga utilizatorul publisher 1
                var user1 = new ApplicationUser();
                user1.UserName = "pub1@pub.com";
                user1.Email = "pub1@pub.com";

                var pubCreated1 = userManager.Create(user1, "Publisher1!");
                if (pubCreated1.Succeeded)
                {
                    userManager.AddToRole(user1.Id, "Publisher");
                }

                // se adauga utilizatorul publisher 2
                var user2 = new ApplicationUser();
                user2.UserName = "pub2@pub.com";
                user2.Email = "pub2@pub.com";

                var pubCreated2 = userManager.Create(user2, "Publisher2!");
                if (pubCreated2.Succeeded)
                {
                    userManager.AddToRole(user2.Id, "Publisher");
                }

                // se adauga utilizatorul publisher 3
                var user3 = new ApplicationUser();
                user3.UserName = "pub3@pub.com";
                user3.Email = "pub3@pub.com";

                var pubCreated3 = userManager.Create(user3, "Publisher3!");
                if (pubCreated3.Succeeded)
                {
                    userManager.AddToRole(user3.Id, "Publisher");
                }

                // se adauga utilizatorul publisher 4
                var user4 = new ApplicationUser();
                user4.UserName = "pub4@pub.com";
                user4.Email = "pub4@pub.com";

                var pubCreated4 = userManager.Create(user4, "Publisher4!");
                if (pubCreated4.Succeeded)
                {
                    userManager.AddToRole(user4.Id, "Publisher");
                }
            }
            // ATENTIE !!! Pentru proiecte, pentru a adauga un rol nou trebuie sa adaugati secventa:
            /*if (!roleManager.RoleExists("your_role_name"))
            {
            // adaugati rolul specific aplicatiei voastre
            var role = new IdentityRole();
            role.Name = "your_role_name";
            roleManager.Create(role);
            // se adauga utilizatorul
            var user = new ApplicationUser();
            user.UserName = "your_user_email";
            user.Email = "your_user_email";
            }*/
        }
    }
}
