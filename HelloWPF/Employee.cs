using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF
{
    class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _Name;

        public int Id { get; set; }

        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string SurName { get; set; }

        public string Department { get; set; }

        public DateTime DayOfBirth { get; set; }

        public int Age => (int)Math.Floor((DateTime.Now - DayOfBirth).TotalDays / 365);

        public override string ToString() => $"Сотрудник {Name} {SurName}. Отдел {Department}";
    }
}
