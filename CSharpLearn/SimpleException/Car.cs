using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    internal class Car
    {
        public const int MaxSpeed = 100;
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";
        private bool carIsDead;
        private Radio theMusicBox = new Radio();
        public Car() { }
        public Car(string name, int speed)
        {
            PetName = name;
            CurrentSpeed = speed;
        }
        public void CrankMusic(bool state)
        {
            theMusicBox.TurnOn(state);
        }
        public void Accelerate(int delta)
        {
            if (carIsDead) {
                Console.WriteLine("The car cant move");
                return;
            }
            CurrentSpeed += delta;
            if (CurrentSpeed > MaxSpeed)
            {
                //Console.WriteLine("The car is overheated");
                CurrentSpeed = 0;
                carIsDead = true;
                Exception ex = new Exception($"{PetName}'s engine died")
                { 
                    HelpLink = "http://www.CarsRUs.com"
                };
                ex.Data.Add("TimeStamp", $"The car exploaded at {DateTime.Now}");
                ex.Data.Add("Cause", "You have a lead foot");
                throw ex;
            }
            else Console.WriteLine("=> Current speed: {0}", CurrentSpeed);
        }
    }
}
