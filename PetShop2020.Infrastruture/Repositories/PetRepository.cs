using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
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
        
        public Pet CheapestAvailable()
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
            var PetEntry = _context.Pets.Add(pet);
            _context.SaveChanges();
            return PetEntry.Entity;
        }

        
        public Pet Delete(int id)
        {
            var PetDeleted = _context.Remove((new Pet(){ID = id}));
            _context.SaveChanges();
            return PetDeleted.Entity;

        }

        public IEnumerable<Pet> GetPets()
        {
           return _context.Pets.ToList();
        }

        public Pet ReadById(int id)
        {
            return _context.Pets.FirstOrDefault(pet => pet.ID == id);
        }

       

        public List<Pet> SortPetByPrice(string direction)
        {
            var tempList = new List<Pet>();
            if (direction.Equals("desc"))
            {
                tempList = _context.Pets.OrderByDescending(s => s.Price).ToList();
            }
            else if (direction.Equals("asc"))
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

            return pet;

            var PetEntry = _context.Pets.Update(pet);
            _context.SaveChanges();
            return PetEntry.Entity;
        } 
    }

}