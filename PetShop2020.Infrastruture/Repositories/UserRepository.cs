using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop2020.Core.Domain_Service;
using PetShop2020.Core.Entity;

namespace PetShop2020.Infrastruture.SQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetShop2020DBContext _context;


        public UserRepository(PetShop2020DBContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            _context.Attach(user).State = EntityState.Added;
            _context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            User user = ReadById(id);
            _context.Attach(user).State = EntityState.Deleted;
            _context.SaveChanges();
            return user;
        }

        public IEnumerable<User> ReadAll()
        {
            return _context.Users.AsNoTracking();
        }

        public User ReadById(int id)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }

        public User Update(User user)
        {
            _context.Attach(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }
    }
}
