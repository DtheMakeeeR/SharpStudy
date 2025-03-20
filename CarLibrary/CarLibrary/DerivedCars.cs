using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CarLibrary
{
    public class SportsCar : Car
    {
        public SportsCar() { }

        public SportsCar(string name, int cs, int ms) : base(name, cs, ms) { }
        public override void TurboBoost()
        {
            MessageBox.Show("Ramming speed!", "Faster is better!");
        }
    }
    public class MiniVan: Car
    {
        public override void TurboBoost()
        {
            MessageBox.Show("Eek... Too fast!", "Your engine is dead!");
            engiState = EngineState.IsDead;
        }
        public MiniVan() { }
        public MiniVan(string name, int cs, int ms): base(name, cs, ms) { }
    }
}
