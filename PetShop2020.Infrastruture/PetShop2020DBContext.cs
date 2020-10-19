using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop2020.Core.Entity;

namespace PetShop2020.Infrastruture
{
    public class PetShop2020DBContext : DbContext
    {
        public PetShop2020DBContext(DbContextOptions<PetShop2020DBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(c => c.PetId)
                .OnDelete(deleteBehavior: DeleteBehavior.SetNull);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        

        
    }

}
