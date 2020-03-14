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
        private string _SurName;
        private Department _Department;

       
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string SurName 
        { 
            get => _SurName; 
            set 
            {
                _SurName = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SurName))); 
            } 
        }

        public Department Department
        {
            get => _Department;
            set
            {
                _Department = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Department)));
            } 
        }

       

        public override string ToString() => $"Сотрудник {Name} {SurName}. Отдел {Department}";
    }
}
