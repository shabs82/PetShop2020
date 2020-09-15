using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2020.Core.Entity
{
    public class Filter
    {
        public string OrderBy { get; set; }
        public int CheapestAvailable { get; set; }
        public AnimalType AnimalType { get; set; }
        public Pet SearchByName { get; set; }
    }
}
