using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Bulet: BaseObject
    {
        private const int width = 5;
        private const int height = 3;

        public Bulet(int position) : base(new Point(30, position-(height*3)/2), Point.Empty, new Size(width, height), 0)
        {

        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            
        }

        public override void Draw()
        {

            Game.Buffer.Graphics.DrawRectangle(Pens.Red, Pos.X, Pos.Y, Size.Width, Size.Height);// объект картинка
            Game.Buffer.Graphics.FillRectangle(Brushes.Yellow, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
