using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Medecine: BaseObject
    {
        Image fileOfMedecine = Image.FromFile("medecine.png");

        public Medecine(Point pos, Point dir, Size size) : base(pos, dir, size, 3)
        {

        }

        public override void Draw()
        {

            Game.Buffer.Graphics.DrawImage(fileOfMedecine, Pos.X, Pos.Y, Size.Width, Size.Height);// объект картинка

        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            
        }
    }
}
