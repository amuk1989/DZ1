using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Ship: BaseObject
    {
        Image fileOfStar = Image.FromFile("ship.png");

        private int _energy = 100;
        public int Energy => _energy;

        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        
        public void EnergyHight(int n)
        {
            _energy += n;
        }

        public Ship(Point pos, Point dir, Size size, int Layer) : base(pos, dir, size, Layer)
        {
            
        }

        public void MoveUp()
        {

            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;

        }

        public void MoveDown()
        {

            if (Pos.Y+Size.Height < Game.Height) 
                Pos.Y = Pos.Y + Dir.Y;

        }

        public override void Draw()
        {

            Game.Buffer.Graphics.DrawImage(fileOfStar, Pos.X, Pos.Y, Size.Width, Size.Height);// объект картинка

        }
        
        public override void Update()
        {

        }

        public void Die()
        {
            MessageDie?.Invoke();
        }

        public static event Message MessageDie;
    }
}
