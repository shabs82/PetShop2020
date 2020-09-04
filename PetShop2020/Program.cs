using System;
using Microsoft.Extensions.DependencyInjection;
using PetShop2020.Core.Application_Service;
using PetShop2020.Core.Application_Service.Service;
using PetShop2020.Core.Domain_Service;
using PetShop2020.Infrastruture;
using PetShop2020.UI;

namespace PetShop2020
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.startUI();
            FakeDb.InitialisePetData();
        }
    }
}
