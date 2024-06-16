using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.DataAccess
{
    public class AspContext : DbContext
    {
        //private readonly string _connectionString;
        //public AspContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        //internal AspContext()
        //{
        //    _connectionString = @"Data Source=ZARKO\SQLEXPRESS;Initial Catalog=ProjectASP;Integrated Security=True;Trust Server Certificate=True";
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=ZARKO\SQLEXPRESS;Initial Catalog=ProjectASP;Integrated Security=True;Trust Server Certificate=True")
                .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<RoleUseCase>().HasKey(x => new
            {
                x.RoleId,
                x.UseCaseId
            });

            
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.IsActive = true;
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<CategoryStage> CategoryStage { get; set; }
        public DbSet<FieldItem> FieldItems { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<RoleUseCase> RoleUseCase { get; set; }
        public DbSet<PackagePage> PackagePage { get; set; }

    }
}
