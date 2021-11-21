// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.Data.SqlClient;

class MyClass

{

    Console.WriteLine("Ange ett namn");
        var input = Console.ReadLine();
    var sql = "Select * from RandomUsers";




    private static DataTable GetDataTable(string sql, string paramName, string paramValue)
    {

        var connString = "server=(localdb\\mssqllocaldb;integrated security=true; database=RandomUsers";
        var dt = new DataTable();
        using (var connection = new SqlConnection(connString)) 

        {
            connection.Open();

            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue(paramName, paramValue);
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }

        }
        return dt;
    }

}


