using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Database;

namespace CitizenJournalismNetworkServer.Models
{
    public class CitizenJournalismNetworkServerContext : DbContext
    {
        public DbSet<CitizenJournalismNetworkServer.Models.Workspace> Workspaces { get; set; }
    
        public DbSet<CitizenJournalismNetworkServer.Models.Person> People { get; set; }
    
        public DbSet<CitizenJournalismNetworkServer.Models.Link> Links { get; set; }
    
        public DbSet<CitizenJournalismNetworkServer.Models.Entry> Entries { get; set; }
    
        public DbSet<CitizenJournalismNetworkServer.Models.Category> Categories { get; set; }
    
        public DbSet<CitizenJournalismNetworkServer.Models.ContentType> ContentTypes { get; set; }
    
        public DbSet<CitizenJournalismNetworkServer.Models.Collection> Collections { get; set; }
    
        public CitizenJournalismNetworkServerContext()
        {
            // Instructions:
            //  * You can add custom code to this file. Changes will *not* be lost when you re-run the scaffolder.
            //  * If you want to regenerate the file totally, delete it and then re-run the scaffolder.
            //  * You can delete these comments if you wish
            //  * If you want Entity Framework to drop and regenerate your database automatically whenever you 
            //    change your model schema, uncomment the following line:
			DbDatabase.SetInitializer(new DropCreateDatabaseIfModelChanges<CitizenJournalismNetworkServerContext>());
            
        }

        protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // A collection has many Content Types, and Content Type may be part of a Collection.
            // NEW: A Content Type may be used by many Collections.
            modelBuilder.Entity<Collection>().HasMany<ContentType>(collection => collection.AcceptedTypes).WithMany();

            // A Collection may have many Categories, and a Category may be used in many Collections.
            modelBuilder.Entity<Collection>().HasMany<Category>(collection => collection.Categories).WithMany();

            // A workspace may have many Collections, and a Collection may be in many Workspaces.
            modelBuilder.Entity<Workspace>().HasMany<Collection>(workspace => workspace.Collections).WithMany();

            // An entry may have many Authors, and people may author many entries.
            modelBuilder.Entity<Entry>().HasMany<Person>(entry => entry.Authors).WithMany();

            // An entry may have many Contributors, and people may contribute to many Entries.
            modelBuilder.Entity<Entry>().HasMany<Person>(entry => entry.Contributors).WithMany();

            // An entry may be associated with many Categories, and a Category may have many Entries.
            modelBuilder.Entity<Entry>().HasMany<Category>(entry => entry.Categories).WithMany();

            // An Entry may have many Links.
            modelBuilder.Entity<Entry>().HasMany<Link>(entry => entry.Links);

            // An Entry may have a Source article.
            modelBuilder.Entity<Entry>().HasOptional<Entry>(entry => entry.Source);

            // An Entry is composed of itself AND Content.
            modelBuilder.ComplexType<Content>();
            
        }
    }
}