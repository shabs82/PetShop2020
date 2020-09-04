using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PetShop2020.Core.Entity
{
    public class Pet
    {
        public int Id;

        public int ID { get; set; }
        public string Name { get; set; }
       
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Colour { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }
        public AnimalType Type { get; set; }
    }
}
