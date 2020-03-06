using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Gamer
    {
        private string _name;
        private int _score;



        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Score
        {
            get => _score;
            set => _score = value;
        }
        
    }
}
