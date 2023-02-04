using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociologySimulator.Models
{
    public class SocialContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Closure> Closures { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Character> Characters { get; set; }

        public string DbPath { get; }
        
        public SocialContext(string dbPath = null)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = dbPath == null ? ":memory:" : System.IO.Path.Join(path, dbPath);
            // manual override. Change to dbpath in the future maybe. But project directory should work
            DbPath = "Resources/social.sqlite";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
            options.EnableSensitiveDataLogging();
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Type>().HasData(
                new Type { Id = 1, Name = "string" },
                new Type { Id = 2, Name = "float" },
                new Type { Id = 3, Name = "int" }
            );

            modelBuilder.Entity<Node>().HasData(
                new Node { Id = 1, Name = "Needs" },
                new Node { Id = 2, Name = "Physical Needs", ParentId = 1 },
                new Node { Id = 3, Name = "Social Needs", ParentId = 1 },
                new Node { Id = 4, Name = "Water", ParentId = 2},
                new Node { Id = 5, Name = "Food", ParentId = 2 },
                new Node { Id = 6, Name = "Love", ParentId = 3 },
                new Node { Id = 101, Name = "Values"}
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Name = "Importance", NodeId = 4, TypeId = 2, Value = "0.999" },
                new Tag { Name = "Status", NodeId = 4, TypeId = 2, Value = "0.88" },
                new Tag { Name = "Importance", NodeId = 5, TypeId = 2, Value = "0.97" },
                new Tag { Name = "Status", NodeId = 5, TypeId = 2, Value = "0.77" },
                new Tag { Name = "Value", NodeId = 101, TypeId = 2, Value = "0.51" }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, FirstName = "Josh", LastName = "Moody", MindId = 1},
                new Character { Id = 2, FirstName = "Matthew", LastName = "Moody", MindId = 101 }
            );

            modelBuilder.Entity<Closure>().HasData(
                new Closure { ParentId = 1, ChildId = 1, Depth = 0 },
                new Closure { ParentId = 2, ChildId = 2, Depth = 0 },
                new Closure { ParentId = 3, ChildId = 3, Depth = 0 },
                new Closure { ParentId = 4, ChildId = 4, Depth = 0 },
                new Closure { ParentId = 5, ChildId = 5, Depth = 0 },
                new Closure { ParentId = 6, ChildId = 6, Depth = 0 },
                new Closure { ParentId = 1, ChildId = 2, Depth = 1 },
                new Closure { ParentId = 1, ChildId = 3, Depth = 1 },
                new Closure { ParentId = 2, ChildId = 4, Depth = 1 },
                new Closure { ParentId = 2, ChildId = 5, Depth = 1 },
                new Closure { ParentId = 3, ChildId = 6, Depth = 1 },
                new Closure { ParentId = 1, ChildId = 4, Depth = 2 },
                new Closure { ParentId = 1, ChildId = 5, Depth = 2 },
                new Closure { ParentId = 1, ChildId = 6, Depth = 2 },
                new Closure { ParentId = 101, ChildId = 101, Depth = 0 }
            );
        }
    
    }
}
