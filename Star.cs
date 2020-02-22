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
       
        public Star(Point pos, Point dir, Size size, int Layer) : base(pos, dir, size, Layer)
        {
            //Dir.X = (Layer+1) * 10;
            //Size.Width = Size.Width * (Layer + 1)*3;
            //Size.Height = Size.Height * (Layer + 1)*3;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

       

    }
}
