using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF
{
    public class Department
    {
        private string _Name;
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
            }
        }

        /*public List<string> Employee
        {
            get
            {
                return _ListOfEmloy;
            }
            set
            {
                _ListOfEmloy = value;
            }
        }*/

        
    }
}
