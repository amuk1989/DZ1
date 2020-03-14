using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF
{
    public class Department : INotifyPropertyChanged
    {
        private string _Name;
        public event PropertyChangedEventHandler PropertyChanged;
        //private List<string> _ListOfEmloy;

        public string Name
        {
            get
            {
                return _Name;

            }
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }



        
    }
}
