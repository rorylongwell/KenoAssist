using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Keno.Data
{
    public class KenoContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientCondition> ClientConditions { get; set; }
        public DbSet<ClientDrink> ClientDrinks { get; set; }
        public DbSet<ClientFood> ClientFoods { get; set; }
        public DbSet<ClientIncident> ClientIncidents { get; set; }
        public DbSet<ClientInformation> ClientInformations { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentPhoto> IncidentPhotos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserIncident> UserIncidents { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "/Users/rorylongwell/Projects/KenoAssist/Keno.Data/keno.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

  

    }
}
