using Microsoft.AspNetCore.Identity;
using WEB_053504_Mazurenko.Data;
using WEB_053504_Mazurenko.Entites;

namespace WEB_053504_Mazurenko.Misc
{
    public class DbInitializer
    {
        public static async void Initialize(WebApplication app)
        {
            var serviceProvider = app.Services.CreateScope().ServiceProvider;

            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            dbContext.Database.EnsureCreated();
            if(!dbContext.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            
            if(!dbContext.Users.Any())
            {
                ApplicationUser admin = new ApplicationUser { Email = "admin@admin.com", UserName = "admin@admin.com" };
                await userManager.CreateAsync(admin, "admin12345");

                ApplicationUser user = new ApplicationUser { Email = "user@user.com", UserName = "user@user.com" };
                await userManager.CreateAsync(user, "user12345");

                await userManager.AddToRoleAsync(admin, "admin");
                await userManager.AddToRoleAsync(user, "user");
            }

            if(!dbContext.Cakes.Any() && !dbContext.CakeGroups.Any())
            {
                List<CakeGroup> _cakeGroups = new List<CakeGroup>();
                var cakeGroup1 = new CakeGroup { Name = "Торт" };
                _cakeGroups.Add(cakeGroup1);
                var cakeGroup2 = new CakeGroup { Name = "Пирог" };
                _cakeGroups.Add(cakeGroup2);

                dbContext.CakeGroups.AddRange(_cakeGroups);

                List<Cake> _cakes = new List<Cake>();
                var cake1 = new Cake { Name = "Сникерс", Image = "cake1.jpg", MimeType = "image/jpeg", Price = 21, Group = cakeGroup1, Description = "Шоколадный бисквит, карамельный крем, жареный арахис и шоколадная глазурь - все на месте :) А еще - прослойка из меренги. Все вместе - очень гармоничный по вкусу торт без невыносимой приторной сладости." };
                _cakes.Add(cake1);
                var cake2 = new Cake { Name = "Позитив", Image = "cake2.jpg", MimeType = "image/jpeg", Price = 24, Group = cakeGroup1, Description = "Этот торт был задуман и испечен специально для одной команды программистов, дабы привнести кусочек позитива в их серые рабочие будни. Судя по тому, что торт прекратил свое существование спустя 20 минут после того, как был принесен в офис, задумка более чем удалась." };
                _cakes.Add(cake2);
                var cake3 = new Cake { Name = "Венский с мандаринами", Image = "cake3.jpg", MimeType = "image/jpeg", Price = 21, Group = cakeGroup2, Description = " В кремовой основе пирога - желированный крем \"Дипломат\" - то есть заварной, смешанный со взбитыми сливками. Верх - консервированные мандарины, самое оно в новогодний сезон :)" };
                _cakes.Add(cake3);
                var cake4 = new Cake { Name = "Радужный", Image = "cake4.jpg", MimeType = "image/jpeg", Price = 21, Group = cakeGroup1, Description = "В основе - простое кексовое тесто, подкрашенное пищевыми красителями, и масляный крем со сливочным сыром." };
                _cakes.Add(cake4);
                var cake5 = new Cake { Name = "Ийогуртовый с персиками", Image = "cake5.jpg", MimeType = "image/jpeg", Price = 24, Group = cakeGroup2, Description = "Начало октября - самое время вспомнить о лете, которое еще совсем недавно радовало теплом и изобилием ярких свежих фруктов и ягод. Помните эти сочные персики? Их аромат, яркий вкус и цвет? В октябре свежих персиков почти не сыскать. А вот консервированных полно, и они тоже весьма ароматные." };
                _cakes.Add(cake5);
                var cake6 = new Cake { Name = "Копия пятого торта", Image = "cake5.jpg", MimeType = "image/jpeg", Price = 24, Group = cakeGroup2, Description = "Начало октября - самое время вспомнить о лете, которое еще совсем недавно радовало теплом и изобилием ярких свежих фруктов и ягод. Помните эти сочные персики? Их аромат, яркий вкус и цвет? В октябре свежих персиков почти не сыскать. А вот консервированных полно, и они тоже весьма ароматные." };
                _cakes.Add(cake6);

                dbContext.Cakes.AddRange(_cakes);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
