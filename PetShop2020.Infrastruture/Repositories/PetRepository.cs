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
       
        private static List<Pet> pets = new List<Pet>();
        
        
       
        public PetRepository()
        {


        }
        
        public Pet CheapestAvailable()
        {
            var HighestPrice = Double.MaxValue;
            Pet finalPet = null;
            foreach (var pet in pets)
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
            pet.ID++;
            pets.Add(pet);
            return pet;
        }

        
        public Pet Delete(int id, string name)
        {
           Pet pet =  ReadById(id);
           if (pet != null)
           {
               pets.Remove(pet);
               return pet;
           }

           return null;
        }

        public IEnumerable<Pet> GetPets()
        {
           return pets.ToList();
        }

        public Pet ReadById(int id)
        {
            return pets.FirstOrDefault(pet => pet.ID == id);
        }

       

        public List<Pet> SortPetByPrice(string direction)
        {
            var tempList = new List<Pet>();
            if (direction.Equals("desc"))
            {
                tempList = pets.OrderByDescending(s => s.Price).ToList();
            }
            else if (direction.Equals("asc"))
            {
                tempList = pets.OrderBy(s => s.Price).ToList();
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
        } 
    }

}