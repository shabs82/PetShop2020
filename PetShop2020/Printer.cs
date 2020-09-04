using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using PetShop2020.Core.Application_Service;
using PetShop2020.Core.Application_Service.Service;
using PetShop2020.Core.Domain_Service;
using PetShop2020.Core.Entity;
using PetShop2020.Infrastruture;

namespace PetShop2020.UI
{
    public class Printer : IPrinter
    {
        private readonly IPetService _petService;
        private readonly IPetRepository _petRepository;
        

        public  Printer()
        {
            
            _petRepository = new PetRepository();
            _petService = new PetService(_petRepository);
            startUI();
            

        }
        
            public void startUI()
            {
               
               
                Pet pet = new Pet()
            {
                    Id = 50,
                    Name = "Warner",
                    Type = AnimalType.RABBIT,
                    BirthDate = DateTime.Parse("11/29/2011"),
                    SoldDate = DateTime.Parse("07/30/2012"),
                    Price = 275

            };
                _petService.Create(pet);
        }
    };

}

