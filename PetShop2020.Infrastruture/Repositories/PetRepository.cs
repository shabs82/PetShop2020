using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.AspNetCore.Mvc;
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
            //Ask Lars
            //var result = _context.Pets.FromSqlRaw(
            //    "SELECT Top(1) FROM Pet " +
            //    "OrderBy ASC");

            //     return result;




        }

        

        public Pet Create(Pet pet)// ask Lars about state and attach.
        {
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;
        }

        
        public Pet Delete(int id)
        {
            //var PetDeleted = ReadById(id);// why is a variable needed here.
            //if (PetDeleted != null)
            //{
            //    _context.Attach(PetDeleted).State = EntityState.Deleted;
            //    _context.SaveChanges();
            //    return PetDeleted;
            //}
            //throw new ArgumentException($" pet not found");

            if (ReadById(id) != null)
            {
                _context.Attach(ReadById(id)).State = EntityState.Deleted;
                _context.SaveChanges();
                return ReadById(id); // this mthod is inefficient incase of large sets of data. good for small amount of data.
            }
            throw new ArgumentException($" pet not found");
        }

        public IEnumerable<Pet> ReadAll(Filter filter = null)
        {
           //return _context.Pets.ToList();
           if (filter == null)
           {
               return _context.Pets.ToList();
           }

           if (filter.FilterByColour != null)
           { 
              return _context.Pets.Where(x => x.Colour == filter.FilterByColour).Skip(filter.CurrentPage - 1 * filter.ItemsPerPage)
                  .Take(filter.ItemsPerPage);
           }

           if (filter.AnimalType == AnimalType.None)
           {
               throw new ArgumentException($" Animal type has ro point to a animal");
           }
           //if (filter.CurrentPage == -1)
           return _context.Pets
               .Skip(filter.CurrentPage - 1 * filter.ItemsPerPage)
               .Take(filter.ItemsPerPage);
        }

        public Pet ReadById(int id)
        {
            return _context.Pets.AsNoTracking().Include(p => p.Owner).FirstOrDefault(pet => pet.ID == id);//why is owner needed here
        }

       

        public List<Pet> SortPetByPrice(Filter filter)
        {
            if (filter.OrderBy == "asc")
            {
                return _context.Pets.OrderBy(s => s.Price).ToList();
            }
            else 
            {
                return _context.Pets.OrderByDescending(s => s.Price).ToList();
            }


            //var resultList = new List<Pet>();

            //if (filter.Equals("desc"))
            //{
            //    return _context.Pets.OrderByDescending(s => s.Price).ToList();
            //}

            //return resultList;

        }

        public Pet Update(Pet pet)// ask lars why do we need to check data validity here when its being checked in services.
        {
            if (pet.ID <= 0)
            {
                throw new NoNullAllowedException();
            }
            _context.Attach(pet).State = EntityState.Modified;
            _context.SaveChanges();
            return pet;
        } 
    }

}