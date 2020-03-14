using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace HelloWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Department> departments = new ObservableCollection<Department>();//это список отделов
        //ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();//это список сотрудников
        static ObservableCollection<Employee> _Employees = new ObservableCollection<Employee>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAddDep_Click(object sender, RoutedEventArgs e)
        {
            Department _department = new Department();

            _department.Name = TextNameDepartment.Text;
           
                departments.Add(_department);
                
                ListDepartments.ItemsSource = departments;
                ListDepartments.SelectedIndex = departments.IndexOf(_department);
            
            
        }

        private void ButtonEditDep_Click(object sender, RoutedEventArgs e)
        {
            
                departments[ListDepartments.SelectedIndex].Name = TextNameDepartment.Text;
                ListDepartments.ItemsSource = departments;
                ListView.ItemsSource = _Employees;
         
        }

        


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee _employ = new Employee();
                _employ.Name = TextName.Text;
                _employ.SurName = TextLastName.Text;
                _employ.Department = departments[ListDepartments.SelectedIndex];

                //_employees.Clear();
                //_employees.Add(_employ);
                _Employees.Add(_employ);
                ListView.ItemsSource = _Employees;
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }

        }

        private void EditEmp_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                _Employees[ListView.SelectedIndex].Name = TextName.Text;
                _Employees[ListView.SelectedIndex].SurName = TextLastName.Text;
                _Employees[ListView.SelectedIndex].Department = departments[ListDepartments.SelectedIndex];
                //_Employees.SetItem(ListView.SelectedIndex, emp);

            }
            catch
            {
                MessageBox.Show("Ошибка! Выберите сотрудника в списке");
            }
            finally
            {
                //ListView.Items.Clear();
                ListView.ItemsSource = _Employees;
            }

        }
    }
}
