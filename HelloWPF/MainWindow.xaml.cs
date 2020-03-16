using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;


namespace HelloWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Department> departments = new ObservableCollection<Department>();//это список отделов
        //ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();//это список сотрудников
        public static ObservableCollection<Employee> _Employees = new ObservableCollection<Employee>();

        public MainWindow()
        {
            InitializeComponent();
            //ObservableCollection<Department> departments = new ObservableCollection<Department>();//это список отделов

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

            AddData.SqlAddDepartment(TextNameDepartment.Text);

            ListDepartments.ItemsSource = departments;

            ListDepartments.SelectedItem = _department;
        }

        private void ButtonEditDep_Click(object sender, RoutedEventArgs e)
        {

            //ListDepartments.SelectedItem.Name = TextNameDepartment.Text;
            
            departments[ListDepartments.SelectedIndex].Name = ListDepartments.Text;
            
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
                AddData.SqlAddEmployee(TextName.Text, TextLastName.Text);
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
