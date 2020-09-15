using System;
using System.Collections.Generic;
using System.Text;
using PetShop2020.Core.Entity;

namespace PetShop2020.Core.Domain_Service
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);
        Owner Update(Owner owner);
        Owner Delete(int id);
        Owner ReadById(int id);
        List<Owner> GetAllOwners();
        List<Owner> FilteredList(Filter filter);
    }
}
