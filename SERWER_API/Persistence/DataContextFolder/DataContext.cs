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

        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Localisation> Localisations { get; set; }
    }
}
