using System;
using System.Collections.Generic;
using System.Text;
using PetShop2020.Core.Entity;


namespace PetShop2020.Core.Domain_Service
{
    public interface IPetRepository
    {
       
        Pet Create(Pet pet);
        Pet Update(Pet pet);
        Pet Delete(int id);
        Pet ReadById(int id);
        List<Pet> SortPetByPrice(Filter filter);
        Pet CheapestAvailable(); 
        IEnumerable <Pet>ReadAll(Filter filter = null);
    }
}
