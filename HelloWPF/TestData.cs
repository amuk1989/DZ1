using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF
{
    class TestData
    {
        /*private List<Employee> _Employees { get; } = Enumerable.Range(1, 2)
        .Select(i => new Employee
        {
            Id = i,
            Name = $"Имя {i}",
            SurName = $"Фамилия {i}",
            Patronymic = $"Отчество {i}",
            DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 / 6 * (i + 18)))
        })
        .ToList();*/
           private static List<Employee> _Employees = new List<Employee>();
           public static List<Employee> Employees
            {
                get
                {
                return _Employees;
                }

                set
                {
                _Employees.AddRange(value.ToArray());
                }
            }

        
        
    }
}
