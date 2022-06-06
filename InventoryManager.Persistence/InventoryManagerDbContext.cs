using System;
using InventoryManager.Domain;
using InventoryManager.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Persistence
{
    /// <summary>
    /// DbContext para el manejo de la base de datos
    /// </summary>
    public class InventoryManagerDbContext : DbContext
    {
        public InventoryManagerDbContext(DbContextOptions<InventoryManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this let us include whatever configuration could be define in the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryManagerDbContext).Assembly);
        }

        /// <summary>
        /// Al rescribir esta función se busca mantener las columnas actualizadas para todas las entidad
        /// que hereden de BaseDomainEntity
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }


            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemEvent> ItemEvents { get; set; }
    }
}

