using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        Random Random = new Random();
        Image fileOfStar = Image.FromFile("star1.png");

        string RandomColor(int color)
        {
            if (color == 0) return "star1.png";
            else if (color == 1) return "star2.png";
            else return "star3.png";

        }

        public BaseObject(Point pos, Point dir, Size size, int layer, int color)// layer - это слой объктна или его удаленность
             //-0-объиектн далиеко ие ниподвиежен, 2 - объиект блиеже и двиежется медленей 3. объект близко и движется быстро
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            Dir.X = (layer + 1) * 10;// скорость зависит от удаленности объекта
            Size.Width = Size.Width * (layer + 1) * 3;// размер зависит от удаленности объекта
            Size.Height = Size.Height * (layer + 1) * 3;// размер зависит от удаленности объекта
            fileOfStar = Image.FromFile(RandomColor(color));// инициализация картинки
        }
        public virtual void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
                        
            Game.Buffer.Graphics.DrawImage(fileOfStar, Pos.X, Pos.Y, Size.Width, Size.Height);// объект картинка
        }
        public void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

    }
}
