using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using Test.Models;

namespace Test.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new DatabaseInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                .HasRequired<Country>(_ => _.Country)
                .WithMany(_ => _.State)
                .HasForeignKey<int>(_ => _.CountryId);

            modelBuilder.Entity<City>()
                .HasRequired<State>(_ => _.State)
                .WithMany(_ => _.City)
                .HasForeignKey<int>(_ => _.StateId);
        }

    }
}