using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PUC.LDSI.DataBase.EntityConfig;
using PUC.LDSI.Domain.Entities;
using System;
using System.Linq;

namespace PUC.LDSI.DataBase
{
    public class AppDbContext : DbContext
    {
        //DbSets - example
        //public DbSet<EntityName> EntityName { get; set; }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Professor> Professor { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Example - Apply Configuration
            //modelbuilder.ApplyConfiguration(new EntityNameConfiguration());

            base.OnModelCreating(modelbuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var now = DateTime.Now;

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.DataCriacao = now;
                }
                else
                {
                    Entry(entity).Property(x => x.DataCriacao).IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
