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
        Image newImage = Image.FromFile("star.png");


        public BaseObject(Point pos, Point dir, Size size, int layer)// layer - это слой объктна 
             //-0-объиектн далиеко ие тниеподвиежиетн, 2 - объиектн блиежие ие двиежиетнся миедлиетнией 3. объиектн блиезко ие двиежиетнся быстнро
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            Dir.X = (layer + 1) * 10;
            Size.Width = Size.Width * (layer + 1) * 3;
            Size.Height = Size.Height * (layer + 1) * 3;
        }
        public virtual void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

    }
}
