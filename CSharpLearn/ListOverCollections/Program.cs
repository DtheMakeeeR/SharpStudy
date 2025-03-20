using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace ListOverCollections
{
    internal class Program
    {
        public class Car
        {
            public string PetName { get; set; } = "";
            public string Color { get; set; } = "";
            public int Speed { get; set; }
            public string Make { get; set; } = "";

        }
        static void Main(string[] args)
        {
            //7ListOverCollections();
            LINQOverArrayList();
        }
        static void ListOverCollections()
        {
            Console.WriteLine("***** LINQ over Generic Collections *****\n");
            // Создать список Listo объектов Car.
            List<Car> myCars = new List<Car> { 
                new Car{ PetName = "Henry",  Color = "Silver ", Speed = 100, Make = "BMW" },
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "Lada" },
                new Car{ PetName = "Mary", Color = " Black", Speed = 55, Make = "VW" },
                new Car{PetName = "Clunker ", Color = "Rust ", Speed = 5, Make = "Yugo" },
                new Car{PetName = "Melvin", Color = "White ", Speed = 43, Make = "Ford" }
            };
            GetFastCars(myCars);
            Console.WriteLine();
            GetFastBMWs(myCars);
            Console.ReadLine();

        }
        static void GetFastCars(List<Car> cars)
        {
            var subset = from c in cars where c.Speed > 55 select c;
            foreach (var car in subset)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }
        static void GetFastBMWs(List<Car> cars)
        {
            var subset = from c in cars where (c.Speed > 55) && (c.Make == "BMW") select c;
            foreach (var car in subset)
            {
                Console.WriteLine("{0} is BMW and is going to fast !", car.PetName);
            }
        }
        static void LINQOverArrayList()
        {
            ArrayList myItems = new ArrayList {
                new Car{ PetName = "Henry",  Color = "Silver ", Speed = 100, Make = "BMW" },
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "Lada" },
                new Car{ PetName = "Mary", Color = " Black", Speed = 55, Make = "VW" },
                new Car{PetName = "Clunker ", Color = "Rust ", Speed = 5, Make = "Yugo" },
                new Car{PetName = "Melvin", Color = "White ", Speed = 43, Make = "Ford" }
            };
            var definitelyCar = myItems.OfType<Car>();
            var fastCars = from c in definitelyCar where (c.Speed > 55) select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine($"{car.PetName} is going too fast!");
            }
        }
    }
}
