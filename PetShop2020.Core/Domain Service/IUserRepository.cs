using System;
using System.Collections.Generic;
using System.Text;
using PetShop2020.Core.Entity;

namespace PetShop2020.Core.Domain_Service
{
   public interface IUserRepository
    {
        User Create(User user);
        User Update(User user);
        User Delete(int id);
        User ReadById(int id);
        IEnumerable<User> ReadAll();
	}
}
