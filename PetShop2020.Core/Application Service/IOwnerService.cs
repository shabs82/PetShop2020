using System;
using System.Collections.Generic;
using System.Text;
using PetShop2020.Core.Entity;

namespace PetShop2020.Core.Application_Service
{
    public interface IOwnerService
    {
        Owner New(string firstName, string lastName, string address, string phoneNumber, string email);
        Owner Create(Owner owner);
        Owner Update(Owner owner);
        Owner Delete(int id);
        Owner ReadById(int id);
        List<Owner> FilteredList(Filter filter);
        List<Owner> ReadAll();
    }
}
