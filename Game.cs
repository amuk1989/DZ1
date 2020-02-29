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
        private static Timer _timer = new Timer() { Interval = 70 };

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] _stars;//Массив фоновых объектов
        public static BaseObject[] _asteroids;//Массив фоновых объектов
        public static Ship _ship;//корабль
        public static Bulet _bulet;//пуля
        public static Medecine _medecine;//Аптечка
        public static Gamer gamer;

        static Game()
        {
        }

        //добавим дополнительно метод Load, в котором реализуем инициализацию наших объектов:
        public static void Load()
        {
            Random Random = new Random();

            gamer = new Gamer();
            gamer.Name = "Player";
            gamer.Score = 0;

            int starsCount = 50;
            _stars = new Star[starsCount];// 50 объектов
            for (int i = 0; i < _stars.Length; i++)
            {
                int _x = Random.Next(0,Width); // случайное место
                int _y = i * Height/starsCount;
                int _layer = Random.Next(0, 5); //сдучайный слой
                                
                _stars[i] = new Star(new Point(_x, _y), new Point(10, 0), new Size(1, 1), _layer);
              
                //отрисовка
            }

            int asteroidCount = 10;
            _asteroids = new Asteroid[asteroidCount];

            for (int i = 0; i < _asteroids.Length; i++)
            {
                
                _asteroids[i] = OneAsteroid();
                //отрисовка
            }

            {
                int _x = 10; 
                int _y = Height / 2;
                int _layer = 0;

                _ship = new Ship(new Point(_x, _y), new Point(10, 10), new Size(20, 20), _layer); 
            }

            _medecine = CreateMedecine();

        }

        static Medecine CreateMedecine()
        {
            
            Random Random = new Random();
            if (Random.Next(0, 10) > 8)
            {
                int _x = Width; // случайное место
                int _y = Random.Next(0, Height);

                return new Medecine(new Point(_x, _y), new Point(1, 0), new Size(5, 5));
            }
            else return null;
        }

        static Asteroid OneAsteroid()
        {
            Random Random = new Random();
            int _x = Random.Next(0, Width); // случайное место
            int _y = Random.Next(0, Height);
            int _layer = 3;
            return new Asteroid(new Point(_x, _y), new Point(1, 0), new Size(2, 2), _layer);
        }

        public static void Init(Form form)
        {
            Ship.MessageDie += Finish;
                        
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
            form.KeyDown += OnFormKeyDown;
            _timer.Start();
            _timer.Tick += Timer_Tick;
        }
        public static void Draw()
        {
            Random Random = new Random();
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _stars)
                obj.Draw();

            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }

            _bulet?.Draw();
            _ship?.Draw();

            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Name:" + gamer.Name, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("Score:" + gamer.Score, SystemFonts.DefaultFont, Brushes.White, 0, 15);
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 30);
            }
                
                        
            _medecine?.Draw();
            
            Buffer.Render();
        }

        public static void Update()
        {
            var random = new Random();

            foreach (BaseObject obj in _stars)
                obj.Update();

            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();

                if (_bulet != null && _bulet.Collision(_asteroids[i]))//попал по астероиду
                {
                    _asteroids[i] = null;
                    _bulet = null;
                    gamer.Score = gamer.Score+1;
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                
                _ship?.EnergyLow(random.Next(1, 10));
                if (_ship.Energy <= 0) _ship?.Die();

            }

            if (_medecine != null && _ship.Collision(_medecine))
            {
                _ship?.EnergyHight(random.Next(1, 10));
            }

            _ship?.Update();
            _bulet?.Update();
            _medecine?.Update();
            if (_medecine != null && _medecine._Pos.X < 0) _medecine = null;
        }


        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
            if (_medecine == null) 
                _medecine = CreateMedecine();
        }

        private static void OnFormKeyDown(object Sender, KeyEventArgs E)
        {
            switch (E.KeyCode)
            {
                case Keys.ControlKey:
                    
                    _bulet = new Bulet(_ship._Pos.Y+_ship._Size.Height/2);
                    

                    break;

                case Keys.Up:
                    _ship.MoveUp();
                    break;

                case Keys.Down:
                    _ship.MoveDown();
                    break;
            }
        }

        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

    }
}
