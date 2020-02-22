using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DZ1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] _objs;//Массив фоновых объектов
        static Game()
        {
        }

        //добавим дополнительно метод Load, в котором реализуем инициализацию наших объектов:
        public static void Load()
        {
            Random Random = new Random();
            _objs = new BaseObject[30];// 30 объектов
            for (int i = 0; i < _objs.Length; i++)
            {
                int _x = Random.Next(0,Width);
                int _y = i * 20;
                int _layer = Random.Next(0, 5);
                int _type = Random.Next(0, 2);
                if (_type == 0)
                
                    _objs[i] = new Star(new Point(_x, _y), new Point(10, 0), new Size(1, 1), _layer);
                
                else
                    _objs[i] = new BaseObject(new Point(_x, _y), new Point(10, 0), new Size(1, 1), _layer);
                //отнриесовка
            }

        }

        public static void Init(Form form)
        {
            Timer timer = new Timer { Interval = 100 };
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }


        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }
}
