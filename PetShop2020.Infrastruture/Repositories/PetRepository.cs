using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop2020.Core.Application_Service.Services;
using PetShop2020.Core.Domain_Service;
using PetShop2020.Core.Entity;

namespace PetShop2020.Infrastruture
{
    public class PetRepository : IPetRepository
    {
       
       private readonly PetShop2020DBContext _context;



        public PetRepository(PetShop2020DBContext context)
        {

            _context = context;
        }
        
        public Pet CheapestAvailable() // any other ways to do this
        {
            var HighestPrice = Double.MaxValue;
            Pet finalPet = null;
            foreach (var pet in _context.Pets.ToList())
            {
                if (HighestPrice > pet.Price)
                {
                    finalPet = pet;
                    HighestPrice = pet.Price;
                }
            }

            return finalPet;
        }

        

        public Pet Create(Pet pet)
        {
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;
        }

        
        public Pet Delete(int id)
        {
            var PetDeleted = ReadById(id);// why is a variable needed here.
            _context.Attach(PetDeleted).State = EntityState.Deleted;
            _context.SaveChanges();
            return PetDeleted;

        }

        public IEnumerable<Pet> GetPets()
        {
           return _context.Pets.ToList();
        }

        public Pet ReadById(int id)
        {
            return _context.Pets.AsNoTracking().Include(p => p.Owner).FirstOrDefault(pet => pet.ID == id);//why is owner needed here
        }

       

        public List<Pet> SortPetByPrice(Filter filter)
        {
            var tempList = new List<Pet>();
            if (filter.Equals("desc"))
            {
                tempList = _context.Pets.OrderByDescending(s => s.Price).ToList();
            }
            else if (filter.Equals("asc"))
            {
                tempList = _context.Pets.OrderBy(s => s.Price).ToList();
            }

            return tempList;

        }

        public Pet Update(Pet pet)
        {
            if (pet.ID != null || pet.ID <=0)
            {
              throw new NoNullAllowedException();
            }
            _context.Attach(pet).State = EntityState.Modified;
            _context.SaveChanges();
            return pet;
        } 
    }

}