using System;
using System.Collections.Generic;
using System.Text;
using PetShop2020.Core.Entity;

namespace PetShop2020.Infrastruture
{

    public static class FakeDb
    {
        public static int PetId;
        public static List<Pet> petsList;
        public static IEnumerable<Pet> petEnumerable;
        public static void InitialiseData()
        {
            
            InitialisePetData();
        }
        public static void InitialisePetData()
        {
            petsList = new List<Pet>();
            Pet catPet1 = new Pet()
            {
                ID = PetId++, Name = "Charlie", Type = AnimalType.CAT, BirthDate = DateTime.Parse("2016-4-1"),
                SoldDate = DateTime.Parse("2016-5-25"), Price = 50
            };
            Pet catPet2 = new Pet()
            {
                ID = PetId++, Name = "Max", Type = AnimalType.CAT, BirthDate = DateTime.Parse("2019-5-25"),
                SoldDate = DateTime.Parse("2018-8-25"), Price = 55
            };
            Pet catPet3 = new Pet() 
            {
                ID = PetId++, Name = "Banana", Type = AnimalType.CAT, BirthDate = DateTime.Parse("2018-2-13"), 
                SoldDate = DateTime.Parse("2018-3-15"),  Price = 29
            };

            Pet catPet4 = new Pet()
            {   
                ID = PetId++, Name = "Toby", Type = AnimalType.CAT, BirthDate = DateTime.Parse("2018-7-11"),
                SoldDate = DateTime.Parse("2019-12-23"),  Price = 100
            };

            Pet dogPet1 = new Pet()
            {
                Id = PetId++, Name = "Bingo", Type = AnimalType.DOG, BirthDate = DateTime.Parse("2018-12-30"),
                SoldDate = DateTime.Parse("2019-02-05"), Price = 45
            };
            Pet dogPet2 = new Pet()
            {
                Id = PetId++,
                Name = "Biscuit",
                Type = AnimalType.DOG,
                BirthDate = DateTime.Parse("2017-1-15"),
                SoldDate = DateTime.Parse("2017-09-10"),
                Price = 30
            };
            Pet dogPet3 = new Pet()
            {
                Id = PetId++, Name = "Louis", Type = AnimalType.DOG, BirthDate = DateTime.Parse("2019-03-12"),
                SoldDate = DateTime.Parse("2019-03-10"), Price = 90
            };
            Pet dogPet4 = new Pet()
            {
                Id = PetId++, Name = "Frodo", Type = AnimalType.DOG, BirthDate = DateTime.Parse("2018-06-28"),
                SoldDate = DateTime.Parse("2018-10-18"), Price = 50
            };
            Pet goatPet1 = new Pet()
            {
                Id = PetId++, Name = "Paco", Type = AnimalType.GOAT, BirthDate = DateTime.Parse("2019-02-24"),
                SoldDate = DateTime.Parse("2019-08-20"), Price = 90
            };
            Pet goatPet2 = new Pet()
            {
                Id = PetId++, Name = "Rex", Type = AnimalType.GOAT, BirthDate = DateTime.Parse("2018-08-10"),
                SoldDate = DateTime.Parse("2018-1-12"), Price = 40
            };
            Pet goatPet3 = new Pet()
            {
                Id = PetId++, Name = "Tiki", Type = AnimalType.GOAT, BirthDate = DateTime.Parse("10/05/2017"),
                SoldDate = DateTime.Parse("05/03/2018"), Price = 65
            };
            Pet goatPet4 = new Pet()
            {
                Id = PetId++, Name = "Bobo", Type = AnimalType.GOAT, BirthDate = DateTime.Parse("2018-05-12"),
                SoldDate = DateTime.Parse("2019-11-15"), Price = 35
            };

            Pet rabbitPet1 = new Pet()
            {
                Id = PetId++, Name = "Heidi", Type = AnimalType.RABBIT, BirthDate =  DateTime.Parse("2018-10-22"),
                SoldDate = DateTime.Parse("2019-04-19"), Price = 150
            };
            Pet rabbitPet2 = new Pet()
            {
                Id = PetId++, Name = "Loki", Type = AnimalType.RABBIT, BirthDate = DateTime.Parse("2019-07-05"),
                SoldDate = DateTime.Parse("2019-10-11"), Price = 180
            };
            Pet rabbitPet3 = new Pet()
            {
                Id = PetId++, Name = "Otto", Type = AnimalType.RABBIT, BirthDate = DateTime.Parse("2019-10-09"),
                SoldDate = DateTime.Parse("2020-03-01"), Price = 200
            };
            Pet rabbitPet4 = new Pet()
            {
                Id = PetId++, Name = "Maxwell", Type = AnimalType.RABBIT, BirthDate = DateTime.Parse("2018-11-29"),
                SoldDate = DateTime.Parse("2020-07-30"), Price = 220
            };


            petsList.Add(catPet1);
            petsList.Add(catPet2);
            petsList.Add(catPet3);
            petsList.Add(catPet4);
            petsList.Add(dogPet1);
            petsList.Add(dogPet2);
            petsList.Add(dogPet3);
            petsList.Add(dogPet4);
            petsList.Add(rabbitPet1);
            petsList.Add(rabbitPet2);
            petsList.Add(rabbitPet3);
            petsList.Add(rabbitPet4);
            petsList.Add(goatPet1);
            petsList.Add(goatPet2);
            petsList.Add(goatPet3);
            petsList.Add(goatPet4);

        }

        public static IEnumerable<Pet> ReadPetData()
        {
            return petEnumerable;
        }
    }
}

 
