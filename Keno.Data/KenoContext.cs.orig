using System;
using System.Collections.Generic;
using System.Text;
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
<<<<<<< HEAD
        public DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=keno.db");
        }
=======
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
>>>>>>> 20182f60325cd124a2a5119fee3f7fc1c68e9ce8
    }
}
