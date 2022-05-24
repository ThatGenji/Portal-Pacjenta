using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal_Pacjenta.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Lekarz> Lekarze { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lekarz>().HasData(
                new Lekarz
                {
                    ID = 4,
                    Imie = "Mariusz",
                    Nazwisko = "Bazowy",
                    Spec = "Psychiatra"
                }
                );
        }
    }
}
