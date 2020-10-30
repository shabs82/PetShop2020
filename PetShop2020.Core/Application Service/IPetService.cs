using System;
using System.Collections.Generic;
using System.Text;
using PetShop2020.Core.Entity;

namespace PetShop2020.Core.Application_Service
{
   public interface IPetService
    {
        Pet Create(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string previousOwner, double price);
        Pet Create(Pet pet);
        Pet Update(Pet pet);
        Pet Delete(int id);
        Pet ReadById(int id);
        List<Pet> SortPetByPrice(Filter filter);
        Pet CheapestAvailable(); 
        List<Pet> ReadAll(Filter filter);
    }
}
