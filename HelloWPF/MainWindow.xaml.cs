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

namespace HelloWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Department> departments = new List<Department>();//это список отделов
        List<Employee> _employees = new List<Employee>();//это список сотрудников
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
            if (!departments.Exists(x => x.Name == (_department.Name)))// нельзя добавить обдинаковый отдел
            {
                departments.Add(_department);
                
                ListDepartments.ItemsSource = departments.ToArray();
                ListDepartments.SelectedIndex = departments.IndexOf(_department);
            }
            else
            {
                MessageBox.Show("Такой отдел существует!");
            }
            
        }

        private void ButtonEditDep_Click(object sender, RoutedEventArgs e)
        {
            
            if (!departments.Exists(x => x.Name == (TextNameDepartment.Text)))// нельзя добавить обдинаковый отдел
            {
                departments[ListDepartments.SelectedIndex].Name = TextNameDepartment.Text;
                ListDepartments.ItemsSource = departments.ToArray();
                ListView.ItemsSource = _employees.ToArray();
            }
            else
            {
                MessageBox.Show("Такой отдел существует!");
            }
        }

        


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Employee _employ = new Employee();
            _employ.Name = TextName.Text;
            _employ.SurName = TextLastName.Text;
            _employ.Department = ListDepartments.Text;

            //_employees.Clear();
            _employees.Add(_employ);
            //TestData.Employees = _employees;
            ListView.ItemsSource = _employees.ToArray();

        }

        private void EditEmp_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var emp = _employees[ListView.SelectedIndex];

                emp.Name = TextName.Text;
                emp.SurName = TextLastName.Text;
                emp.Department = ListDepartments.Text;
                

            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            finally
            {
                //ListView.Items.Clear();
                ListView.ItemsSource = _employees.ToArray();
            }

        }
    }
}
