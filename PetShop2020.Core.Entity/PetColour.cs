using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PetShop2020.Core.Entity
{
    public class PetColour
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public Colour Colour { get; set; }
    }
}
