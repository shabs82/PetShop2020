using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop2020.Core;
using PetShop2020.Core.Application_Service;
using PetShop2020.Core.Domain_Service;
using PetShop2020.Core.Entity;
using Filter = PetShop2020.Core.Entity.Filter;

namespace PetShop2020.Infrastruture
{
    public class OwnerRepository : IOwnerRepository
    {
       
        private readonly PetShop2020DBContext _context;
        
        public OwnerRepository(PetShop2020DBContext context)
        {
            _context = context;
        }


        public Owner Create(Owner owner)
        {
            
            _context.Attach(owner).State = EntityState.Added;
            _context.SaveChanges();
            return owner;
        }

        public Owner Delete(int id)
        {
            Owner own = ReadById(id);
            _context.Attach(own).State = EntityState.Deleted;
            _context.SaveChanges();
            return own;
        }

        public List<Owner> FilteredList(Filter filter)
        {
            var tempList = new List<Owner>();

            if (!String.IsNullOrEmpty(filter.OrderBy))
            {
                // If true. Filter by order
            }

            if (filter.AnimalType != AnimalType.None)
            {
                //if true filter by animal type
            } 
            
            if (filter.FilterByColour != null)
            {
                // if true filer by color
            }

            return tempList;
            ;
        }

        public Owner ReadById(int id)// check if this is correct
        {
    
            return _context.Owners.AsNoTracking().Include(p => p.PetId).FirstOrDefault(x => x.Id == id);
        }

        public Owner Update(Owner owner)
        {
            if (owner.Id != null || owner.Id <= 0)
            {
                throw new NoNullAllowedException();
            }

            _context.Attach(owner).State = EntityState.Modified;
            _context.SaveChanges();
            return owner;
        }

        public List<Owner> GetAllOwners()
        {
            return _context.Owners.ToList();
        }
    }
}
