using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Backend.Models
{
    

    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName { get { return $"{this.Name} {this.Surname}"; } } // Proprietà calcolata
    }
    public class Client : Person
    {
        public int ClientId { get; set; } 
    }
    public class Notary : Person
    {
        public int NotaryId { get; set; }
    }

    public class RealEstate
    {
        public int RealEstateId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Mq { get; set; }
        public int Price { get; set; }

    }
    public class Deed
    {
        public int DeedId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int NotaryId { get; set; }
        public Notary Notary { get; set; }
        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }
        public DateTime Date { get; set; }
    }



    // Add Microsoft.Data.Sqlite -  Microsoft.EntityFrameworkCore.Sqlite - Microsoft.EntityFrameworkCore.Design
    // Using package console:
    // Install ef tools: https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
    // Migrate database: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs
    // Read "Evolving your model" in the previous website to add functionalities in a new migration
    // https://www.entityframeworktutorial.net/efcore/entity-framework-core-console-application.aspx
    // https://fullstack-nuggets.com/ef-core-6-how-to-use-linq-to-write-strongly-typed-queries/
    // https://zetcode.com/csharp/mongodb/
    public class MyContext : DbContext
    {
        protected string uri;
        public DbSet<Client> Clients { get; set; }
        public DbSet<Notary> Notaries { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Deed> Deeds { get; set; }

        public MyContext() : base()
        {
            this.uri = "Data Source=C:\\Users\\boh_h\\source\\repos\\Testing\\Testing\\myefdb.sqlite";
        }
        public MyContext(string uri)
        {
            this.uri = uri;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(uri);
    }
}
