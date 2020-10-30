using PetShop2020.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2020.Core.Entity
{
    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public string OrderBy { get; set; }

        public Pet SortPetByPrice{get ; set; }
        public AnimalType AnimalType { get; set; }
        public string FilterByColour { get; set; }
    }
}

