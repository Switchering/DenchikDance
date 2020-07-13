using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DenchikDance.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DenchikDance.Data
{
    public class SiteContext : IdentityDbContext
    {
        public SiteContext (DbContextOptions<SiteContext> options)
            : base(options)
        {
        }

        public DbSet<DenchikDance.Models.Article> Articles { get; set; }
        public DbSet<DenchikDance.Models.Category> Categories { get; set; } 
        public DbSet<DenchikDance.Models.User> Users { get; set; }
        public DbSet<DenchikDance.Models.Tag> Tags { get; set; }
        public DbSet<DenchikDance.Models.TagRelation> TagRelations { get; set; }
        public DbSet<DenchikDance.Models.Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().ToTable("Article");    
            modelBuilder.Entity<Category>().ToTable("Category");   
            modelBuilder.Entity<User>().ToTable("User"); 
            modelBuilder.Entity<Tag>().ToTable("Tag"); 
            modelBuilder.Entity<TagRelation>().ToTable("TagRelation"); 
            modelBuilder.Entity<Tournament>().ToTable("Tournament");  

        }
    }
}
