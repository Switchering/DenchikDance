using DenchikDance.Data;
using DenchikDance.Models;
using System;
using System.Linq;

namespace DenchikDance.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SiteContext context)
        {
            //context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category{Title="Блог", Description="Здесь я рассказываю о моей жизни"},
                new Category{Title="Тренировки", Description="Здесь я рассказываю о моих тренировках"},
                new Category{Title="Учеба", Description="Здесь я рассказываю о "},
                new Category{Title="Поездки", Description="Здесь я рассказываю о поездках"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var users = new User[]
            {
                new User{Login="admin", Email="admin@lokup.com", Password="admin"},
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}