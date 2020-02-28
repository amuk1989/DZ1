using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Asteroid: BaseObject
    {
        Image fileOfAsteroid = Image.FromFile("asteroid.png");

        public Asteroid(Point pos, Point dir, Size size, int Layer) : base(pos, dir, size, Layer)
        {

        }

        public override void Draw()
        {

            Game.Buffer.Graphics.DrawImage(fileOfAsteroid, Pos.X, Pos.Y, Size.Width, Size.Height);// объект картинка

        }

    }
}
