using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DenchikDance.Models;

namespace DenchikDance.Data
{
    public class SiteContext : DbContext
    {
        public SiteContext (DbContextOptions<SiteContext> options)
            : base(options)
        {
        }

        public DbSet<DenchikDance.Models.Post> Posts { get; set; }
        public DbSet<DenchikDance.Models.Category> Categories { get; set; } 
        public DbSet<DenchikDance.Models.User> Users { get; set; }
        public DbSet<DenchikDance.Models.Tag> Tags { get; set; }
        public DbSet<DenchikDance.Models.TagRelation> TagRelations { get; set; }
        public DbSet<DenchikDance.Models.Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Post");    
            modelBuilder.Entity<Category>().ToTable("Category");   
            modelBuilder.Entity<User>().ToTable("User"); 
            modelBuilder.Entity<Tag>().ToTable("Tag"); 
            modelBuilder.Entity<TagRelation>().ToTable("TagRelation"); 
            modelBuilder.Entity<Tournament>().ToTable("Tournament");  

        }
    }
}
