using PetShop2020.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using PetShop2020.Core.Domain_Service;

namespace PetShop2020.Core.Application_Service.Service
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;


        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet CheapestAvailable()
        {
            return _petRepository.CheapestAvailable();
        }

        public Pet Create(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string previousOwner, double price)
        {
            Pet newPet = new Pet() {Name = name, Type = type, BirthDate = birthdate, SoldDate = soldDate, Price = price };
            return newPet;

        }
        public Pet Create(Pet pet)
        {
            
                if (pet.ID <= 1)
                {
                    throw new ArgumentOutOfRangeException($" Id cannot be null. Please enter a valid num");
                }

                else if (pet.Name != String.Empty)
                {
                    throw new ArgumentNullException($" Name field cannot be empty");
                }
                else if (pet.Price <= 0)
                {
                    throw new ArgumentOutOfRangeException($" Price cannot be zero or below");
                }

                return _petRepository.Create(pet);

        }

        public Pet Delete(int id)
        {
            if ((id == null || id <= 0))
            {
                throw new ArgumentNullException();
            }

            return _petRepository.Delete(id);

        }


        public Pet ReadById(int id)
        {
            if (id<= 0) 
            {
                throw new InvalidDataException();
            }

            return _petRepository.ReadById(id);
        }

        

        public List<Pet> SortPetByPrice(string OrderBy)
        {
           
            return _petRepository.SortPetByPrice(OrderBy);
        }

        public Pet Update(Pet pet)
        {
            CheckValidId(pet);
            return _petRepository.Update(pet);
            
        }

        private void CheckValidId(Pet pet)
        {
            
            if (pet.ID <= 0)
            {
                throw new ArgumentNullException($"Pet Id cannot be in negative");
            }
            else if (String.IsNullOrEmpty(pet.Name) )
            {
                throw new NoNullAllowedException($" Pet id cannot be null or empty");
            }

        }


        public List<Pet> GetPets()
        {
            return _petRepository.GetPets().ToList();
        }
    }
}
