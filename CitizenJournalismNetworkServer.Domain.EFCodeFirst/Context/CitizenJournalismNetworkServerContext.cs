using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;
using System.ComponentModel.DataAnnotations;


namespace CitizenJournalismNetworkServer.Domain.EFCodeFirst.Context
{
    public class CitizenJournalismNetworkServerContext : DbContext
    {
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<Collection> Collections { get; set; }
    


        public CitizenJournalismNetworkServerContext()
        {
            // If you want Entity Framework to drop and regenerate your database automatically whenever you 
            // change your model schema, uncomment the following line:
            //Database.SetInitializer(new CreateDatabaseIfNotExists<CitizenJournalismNetworkServerContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CitizenJournalismNetworkServerContext>());    
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            MapColumnProperties(modelBuilder);

            ManyToManyRelationships(modelBuilder);

            OneToOneRelationships(modelBuilder);

            OneToManyRelationships(modelBuilder);
        }


        private static void MapColumnProperties(DbModelBuilder modelBuilder)
        {

            MapEntityProperties<Category>(modelBuilder);
            MapEntityProperties<Collection>(modelBuilder);
            MapEntityProperties<ContentType>(modelBuilder);
            MapEntityProperties<Entry>(modelBuilder);
            MapEntityProperties<Link>(modelBuilder);
            MapEntityProperties<Person>(modelBuilder);
            MapEntityProperties<Workspace>(modelBuilder);
            
        }

        private static void MapEntityProperties<DomainEntityType>(DbModelBuilder modelBuilder) where DomainEntityType: DomainEntity
        {
            modelBuilder.Entity<DomainEntityType>()
                .Property(entity => entity.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DomainEntityType>()
                .Property(entity => entity.VersionStamp)
                .HasColumnType("timestamp")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .IsConcurrencyToken();

        }


        private static void ManyToManyRelationships(DbModelBuilder modelBuilder)
        {
            // A collection has many Content Types, and Content Type may be part of a Collection.
            modelBuilder.Entity<Collection>()
                .HasMany<ContentType>(collection => collection.AcceptedTypes)
                .WithMany();

            // A Collection may have many Categories, and a Category may be used in many Collections.
            modelBuilder.Entity<Collection>()
                .HasMany<Category>(collection => collection.Categories)
                .WithMany();

            // A workspace may have many Collections, and a Collection may be in many Workspaces.
            modelBuilder.Entity<Workspace>()
                .HasMany<Collection>(workspace => workspace.Collections)
                .WithMany();

            // An entry may have many Authors, and people may author many entries.
            modelBuilder.Entity<Entry>()
                .HasMany<Person>(entry => entry.Authors)
                .WithMany()
                .Map(action => action.ToTable("EntryAuthors"));

            // An entry may have many Contributors, and people may contribute to many Entries.
            modelBuilder.Entity<Entry>()
                .HasMany<Person>(entry => entry.Contributors)
                .WithMany()
                .Map(action => action.ToTable("EntryContributors"));

            // An entry may be associated with many Categories, and a Category may have many Entries.
            modelBuilder.Entity<Entry>()
                .HasMany<Category>(entry => entry.Categories)
                .WithMany();
        }



        private static void OneToOneRelationships(DbModelBuilder modelBuilder)
        {
            //**** ONE-TO-ZERO-OR-ONE Relationships

            // An Entry may have a Source article.
            modelBuilder.Entity<Entry>()
                .HasOptional<Entry>(entry => entry.Source);

            // An Entry is composed of itself AND Content.
            modelBuilder.ComplexType<Content>();
            
        }


        private static void OneToManyRelationships(DbModelBuilder modelBuilder)
        {

            // An Entry belongs to a Collection, which has many Entries.
            modelBuilder.Entity<Entry>()
                .HasRequired<Collection>(entry => entry.Collection)
                .WithMany();

            // An Entry may have many Links.
            modelBuilder.Entity<Entry>()
                .HasMany<Link>(entry => entry.Links);

        }


    }
}