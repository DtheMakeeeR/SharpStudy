using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    public class Car
    {
        public delegate void CarEngineHandler(string msgForCaller);
        private CarEngineHandler listOfHandlers;
        public void RegisterWithEngine(CarEngineHandler handler)
        {
            listOfHandlers = handler;
        }
        // Данные состояния,
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        // Исправен ли автомобиль?
        private bool carlsDead;
        // Конструкторы класса,
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        public void Accelerate(int delta)
        {
            if (carlsDead)
            {
                if (listOfHandlers != null)
                {
                    listOfHandlers("Sorry, car is dead!");
                }
            }
            else
            {
                CurrentSpeed += delta;
                if (MaxSpeed < delta + CurrentSpeed)
                {
                    listOfHandlers("Carefull buddy, its gonna blow!");
                }
                if (CurrentSpeed > MaxSpeed)
                {
                    carlsDead = true;
                }
                else Console.WriteLine("Current speed is {0}", CurrentSpeed);
            }
        }        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");
            Car MyCar = new Car("McMillan", 100, 0);
            MyCar.RegisterWithEngine(AwareMe);
            for (int i = 0; i < 10; i++)
            {
                MyCar.Accelerate(i * 5);
            }
        }

        private static void AwareMe(string msgForCaller)
        {
            Console.WriteLine("*****Message from a car*****");
            Console.WriteLine("=> {0}", msgForCaller);
            Console.WriteLine("****************************");
        }
    }
}
