using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DZ1
{
    abstract class BaseObject: ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        //protected Image image;

        public Point _Pos => Pos;
        public Size _Size => Size;

        public BaseObject(Point pos, Point dir, Size size, int layer)// layer - это слой объктна или его удаленность
             //-0-объиектн далиеко ие ниподвиежен, 2 - объиект блиеже и двиежется медленей 3. объект близко и движется быстро
        {
            Pos = pos;
            Dir = dir;
            Size    = size;
            Dir.X = (layer + 1) * 10;// скорость зависит от удаленности объекта
            Size.Width = Size.Width * (layer + 1) * 3;// размер зависит от удаленности объекта
            Size.Height = Size.Height * (layer + 1) * 3;// размер зависит от удаленности объекта
            
            
        }
        public abstract void Draw();
        //public abstract void MoveUp();

        public virtual void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);

        public delegate void Message();

    }
}
