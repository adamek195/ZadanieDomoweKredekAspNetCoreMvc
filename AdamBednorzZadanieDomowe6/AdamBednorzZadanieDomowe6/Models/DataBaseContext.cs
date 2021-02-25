using AdamBednorzZadanieDomowe6.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.Models
{
    public class DataBaseContext: DbContext
    {
        //Polaczenie z baza danych
        private string _connectionString = "Data Source =HARDCOR\\BEDNORZSQL; Initial Catalog=GameRentalShop; Trusted_Connection = yes;";

        //Tabele bazy danych
        public DbSet<Game> Games { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
