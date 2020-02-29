using System;
using System.Windows.Forms;

namespace DZ1
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = Screen.PrimaryScreen.Bounds.Width-100,
                Height = Screen.PrimaryScreen.Bounds.Height-100
            };
            Game.Init(form);
            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);
        }
    }
}
