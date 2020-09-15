using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop2020.Core.Entity;

namespace PetShop2020.Infrastruture
{
    public class PetShop2020Context : DbContext
    {
        public PetShop2020Context(DbContextOptions<PetShop2020Context> options) : base(options)
        {
        }


        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }

}
