using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Star: BaseObject
    {
        Image fileOfStar = Properties.Resources.star1;
        Random Random = new Random();
        Image RandomColorStar(int color)
        {
            
            if (color == 0) return Properties.Resources.star1;
            else if (color == 1) return Properties.Resources.star2;
            else return Properties.Resources.star3;

        }

        public Star(Point pos, Point dir, Size size, int Layer) : base(pos, dir, size, Layer)
        {
            int _color = Random.Next(0, 3);
            fileOfStar = (RandomColorStar(_color));// инициализация картинки
        }

        public override void Draw()
        {
            
            Game.Buffer.Graphics.DrawImage(fileOfStar, Pos.X, Pos.Y, Size.Width, Size.Height);// объект картинка

        }

        

    }
}
