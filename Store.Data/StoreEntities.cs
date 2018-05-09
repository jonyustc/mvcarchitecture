using Store.Data.Configurations;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Data.Migrations;

namespace Store.Data
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() :
            base("StoreEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreEntities, Configuration>());
        
        }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
