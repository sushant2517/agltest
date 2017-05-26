using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGL.App.DI;
using Autofac;

namespace AGL.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var prog = new Program();
            var container = prog.BuildContainer();

            var processor = container.Resolve<Processor>();

            var petsGroupings = processor.GetResponse().Result;
            foreach (var genderGroup in petsGroupings)
            {
                Console.WriteLine($"{genderGroup.GenderKey}");
                foreach (var pet in genderGroup.Pets)
                {
                    Console.WriteLine($"\t> {pet.Name}");
                }
            }

            Console.Read();
        }

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppModule>();
            return builder.Build();
        }
    }
}
