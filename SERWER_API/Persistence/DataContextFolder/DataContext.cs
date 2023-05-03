using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataContextFolder
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Localisation> Localisations { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<ConfigurationPosition> ConfigurationPositions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShipmentType> ShipmentTypes { get; set; }
        public DbSet<CustomCake> CustomCakes { get; set; }
        public DbSet<OrderProductItem> OrderProductItems { get; set; }
    }
}
