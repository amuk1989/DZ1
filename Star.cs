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
        Image fileOfStar = Image.FromFile("star1.png");
        Random Random = new Random();
        string RandomColorStar(int color)
        {
            if (color == 0) return "star1.png";
            else if (color == 1) return "star2.png";
            else return "star3.png";

        }

        public Star(Point pos, Point dir, Size size, int Layer) : base(pos, dir, size, Layer)
        {
            int _color = Random.Next(0, 3);
            fileOfStar = Image.FromFile(RandomColorStar(_color));// инициализация картинки
        }

        public override void Draw()
        {
            
            Game.Buffer.Graphics.DrawImage(fileOfStar, Pos.X, Pos.Y, Size.Width, Size.Height);// объект картинка

        }

        

    }
}
