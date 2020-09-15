using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using PetShop2020.Core;
using PetShop2020.Core.Domain_Service;
using PetShop2020.Core.Entity;

namespace PetShop2020.Infrastructure.DBInitialiser
{
    public class DBinitialiser
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;
       

        public DBinitialiser(IPetRepository petRepository , IOwnerRepository ownerRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;


        }

        public void InitPetData()
        {
           
            Pet catPet1 = new Pet()
            {
                Name = "Charlie",
                Type = AnimalType.CAT,
                BirthDate = DateTime.Parse("2016-4-1"),
                SoldDate = DateTime.Parse("2016-5-25"),
                Price = 50
            };
            _petRepository.Create(catPet1);

            Pet catPet2 = new Pet()
            {
                Name = "Max",
                Type = AnimalType.CAT,
                BirthDate = DateTime.Parse("2019-5-25"),
                SoldDate = DateTime.Parse("2018-8-25"),
                Price = 55
            };
            _petRepository.Create(catPet2);

            Pet catPet3 = new Pet()
            {
                Name = "Banana",
                Type = AnimalType.CAT,
                BirthDate = DateTime.Parse("2018-2-13"),
                SoldDate = DateTime.Parse("2018-3-15"),
                Price = 29
            };
            _petRepository.Create(catPet3);

            Pet catPet4 = new Pet()
            {
                Name = "Toby",
                Type = AnimalType.CAT,
                BirthDate = DateTime.Parse("2018-7-11"),
                SoldDate = DateTime.Parse("2019-12-23"),
                Price = 100
            };
            _petRepository.Create(catPet4);

            Pet dogPet1 = new Pet()
            {
                Name = "Bingo",
                Type = AnimalType.DOG,
                BirthDate = DateTime.Parse("2018-12-30"),
                SoldDate = DateTime.Parse("2019-02-05"),
                Price = 45
            };
            _petRepository.Create(dogPet1);

            Pet dogPet2 = new Pet()
            {
                Name = "Biscuit",
                Type = AnimalType.DOG,
                BirthDate = DateTime.Parse("2017-1-15"),
                SoldDate = DateTime.Parse("2017-09-10"),
                Price = 30
            };
            _petRepository.Create(dogPet2);

            Pet dogPet3 = new Pet()
            {
                Name = "Louis",
                Type = AnimalType.DOG,
                BirthDate = DateTime.Parse("2019-03-12"),
                SoldDate = DateTime.Parse("2019-03-10"),
                Price = 90
            };
            _petRepository.Create(dogPet3);

            Pet dogPet4 = new Pet()
            {
                Name = "Frodo",
                Type = AnimalType.DOG,
                BirthDate = DateTime.Parse("2018-06-28"),
                SoldDate = DateTime.Parse("2018-10-18"),
                Price = 50
            };
            _petRepository.Create(dogPet4);

            Pet goatPet1 = new Pet()
            {
                Name = "Paco",
                Type = AnimalType.GOAT,
                BirthDate = DateTime.Parse("2019-02-24"),
                SoldDate = DateTime.Parse("2019-08-20"),
                Price = 90
            };
            _petRepository.Create(goatPet1);

            Pet goatPet2 = new Pet()
            {
               
                Name = "Rex",
                Type = AnimalType.GOAT,
                BirthDate = DateTime.Parse("2018-08-10"),
                SoldDate = DateTime.Parse("2018-1-12"),
                Price = 40
            };
            _petRepository.Create(goatPet2);

            Pet goatPet3 = new Pet()
            {
                Name = "Tiki",
                Type = AnimalType.GOAT,
                BirthDate = DateTime.Parse("10/05/2017"),
                SoldDate = DateTime.Parse("05/03/2018"),
                Price = 65
            };
            _petRepository.Create(goatPet3);

            Pet goatPet4 = new Pet()
            {
                Name = "Bobo",
                Type = AnimalType.GOAT,
                BirthDate = DateTime.Parse("2018-05-12"),
                SoldDate = DateTime.Parse("2019-11-15"),
                Price = 35
            };
            _petRepository.Create(goatPet4);

            Pet rabbitPet1 = new Pet()
            {
                Name = "Heidi",
                Type = AnimalType.RABBIT,
                BirthDate = DateTime.Parse("2018-10-22"),
                SoldDate = DateTime.Parse("2019-04-19"),
                Price = 150
            };
            _petRepository.Create(rabbitPet1);

            Pet rabbitPet2 = new Pet()
            {
                Name = "Loki",
                Type = AnimalType.RABBIT,
                BirthDate = DateTime.Parse("2019-07-05"),
                SoldDate = DateTime.Parse("2019-10-11"),
                Price = 180
            };
            _petRepository.Create(rabbitPet2);

            Pet rabbitPet3 = new Pet()
            {
                Name = "Otto",
                Type = AnimalType.RABBIT,
                BirthDate = DateTime.Parse("2019-10-09"),
                SoldDate = DateTime.Parse("2020-03-01"),
                Price = 200
            };
            _petRepository.Create(rabbitPet3);

            Pet rabbitPet4 = new Pet()
            {
                Name = "Maxwell",
                Type = AnimalType.RABBIT,
                BirthDate = DateTime.Parse("2018-11-29"),
                SoldDate = DateTime.Parse("2020-07-30"),
                Price = 220
            };
            _petRepository.Create(rabbitPet4);


           

        }

        public void InitOwnerData()
        {
            Owner owner1 = new Owner() 
                { 
                    FirstName = "Son", 
                    LastName = "Goku", 
                    Address = "King kai's 25", 
                    Email = "dragonballz@gmail.com"
                };
            _ownerRepository.Create(owner1);
            

            Owner owner3 = new Owner()
            {
                FirstName = "Bart", 
                LastName = "Simpson", 
                Address = "Evergreen Terrace 13", 
                Email = "eatMYSHORTS@gmail.com"
            };
            _ownerRepository.Create(owner3);

            Owner owner4 = new Owner()
            {
                FirstName = "Clarke", 
                LastName = "Kent", 
                Address = "Metropolis 89", 
                Email = "notSuperman@hotmail.com"
            };
            _ownerRepository.Create(owner4);



        }
    }
}

