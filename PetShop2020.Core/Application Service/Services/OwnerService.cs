using PetShop2020.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using PetShop2020.Core.Domain_Service;

namespace PetShop2020.Core.Application_Service.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public Owner New(string firstName, string lastName, string address, string phoneNumber, string email)
        {
            Owner owner = New(firstName, lastName, address, phoneNumber, email);
            return owner;
        }
        public Owner Create(Owner owner)
        {
            if (owner.Id == null)
            {
                throw new NoNullAllowedException($"Id cannot be null ");
            }
            if (owner.Id <= 0)
            {
                throw new NotFiniteNumberException("Id cannot be in negative");
            } 
           
            if(String.IsNullOrEmpty(owner.FirstName)&& String.IsNullOrEmpty( owner.LastName))
            {    
                throw new InvalidDataException();
            }
            return _ownerRepository.Create(owner);

        }

        public Owner Delete(int Id)
        {
            if (Id  <= 0)
            {
                throw new NullReferenceException("Id cannot be in negative");
            }

            return _ownerRepository.Delete(Id);
        }

        

        public List<Owner> FilteredList(Filter filter)
        {
            return _ownerRepository.FilteredList(filter);
        }
        
        public Owner ReadById(int id)
        {
            return _ownerRepository.ReadById(id);
        }

        public Owner Update(Owner owner)
        {
            if (owner.Id <= 0)
            {
                throw new ArgumentNullException($"Owner Id cannot be in negative");
            }
            else if (String.IsNullOrEmpty(owner.FirstName))
            {
                throw new NoNullAllowedException($" Owner firstname cannot be null or empty");
            }

            return _ownerRepository.Update(owner);

        }

    }
}
