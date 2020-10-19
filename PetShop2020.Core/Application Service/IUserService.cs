using System;
using System.Collections.Generic;
using System.Text;
using PetShop2020.Core.Entity;

namespace PetShop2020.Core.Application_Service
{
    public interface IUserService
    {
        User Create(User user);
        User Update(User user);
        User Delete(int id);
        User ReadById(int id);
        List<User> ReadAll();
        User ValidateUser(LoginInputModel loginInputModel);
	}
}
