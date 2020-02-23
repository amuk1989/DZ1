using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Planet: BaseObject
    {
        public Planet(Point pos, Point dir, Size size, int Layer, int color) : base(pos, dir, size, Layer, color)
        {
            
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.FillEllipse(Brushes.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
