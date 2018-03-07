using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Keno.Data
{
    public class KenoEntities : DbContext
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
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
