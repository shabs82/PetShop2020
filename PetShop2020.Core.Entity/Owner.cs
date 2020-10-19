using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace PetShop2020.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<Pet> PetId { get; set; }
    }
}
