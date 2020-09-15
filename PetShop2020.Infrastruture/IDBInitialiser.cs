using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2020.Infrastruture
{
    public interface IDBInitializer
    {
        void Seed(PetShop2020Context context);
    }
}
