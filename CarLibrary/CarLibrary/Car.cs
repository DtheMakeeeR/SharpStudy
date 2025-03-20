using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public enum EngineState
    {
        IsAlive, IsDead
    }
    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrSpeed { get; set; }
        public int MaxSpeed { get; set; }
        protected EngineState engiState = EngineState.IsAlive;
        public EngineState EngineState => engiState;
        public abstract void TurboBoost();
        public Car() { }
        public Car(string name, int cs, int ms)
        {
            PetName = name;
            CurrSpeed = cs;
            MaxSpeed = ms;
        }
    }
}
