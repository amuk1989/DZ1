using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace HelloWPF
{
    class AddData
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;       
        private static void Add(string command)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();


                var insert_data_command = new SqlCommand(
                    command,
                    connection);
                insert_data_command.ExecuteNonQuery();
            }

        }

        public static void SqlAddDepartment(string name)
        {
            string AddDepartment = @"INSERT INTO [dbo].[deparments] (Name) VALUES (N'{0}');";
            Add(string.Format(AddDepartment, name));
        }
        public static void SqlAddEmployee(string name, string surName)
        {
            string AddEmploee = @"INSERT INTO [dbo].[Employee] (Name, Surname) VALUES (N'{0}', N'{1}');";
            Add(string.Format(AddEmploee, name, surName));
        }
    }
}
