// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.Data.SqlClient;

int MenuChoice =0;
bool Exit = false;

Console.WriteLine("Ange ett namn");
var input = Console.ReadLine();

var sql = "Select username, password, email from RandomUsers WHERE username LIKE @param";
var dt = GetDataTable(sql, "@param" , "%" + input + "%");

PrintRow();



while (Exit == false)
{
    Console.Clear(); 
    switch(MenuChoice)
    {
        case 1:
            break;

            case 2:
            break;

        case 3:
            break;

        case 4:
            break;

        case 5:
            break;

        case 6:
            break;

        case 7:
            break;

            default:
            MenuChoice = 0;
            break;


    }

}










 void GraphicMeny() // Huvudmeny
{
    Console.WriteLine("**********************************************************************************");
    Console.WriteLine("*|                                                                              |*");
    Console.WriteLine("*|       1.    Show how many unique countries there are.                        |*");
    Console.WriteLine("*|                                                                              |*");
    Console.WriteLine("*|       2.    Show the country the most people come from.                      |*");
    Console.WriteLine("*|                                                                              |*");
    Console.WriteLine("*|       3.    List the 10 first users with a name starting with L              |*");
    Console.WriteLine("*|                                                                              |*");
    Console.WriteLine("*|       4.    Show all users that have the same letter as first and last name. |*");
    Console.WriteLine("*|                                                                              |*");
    Console.WriteLine("*|       5.    Count how many countries are from Nordic and Scandinavian.       |*");
    Console.WriteLine("*|                                                                              |*");
    Console.WriteLine("*|       6.    Are all username and passwords unique?                           |*");
    Console.WriteLine("*|                                                                              |*");
    Console.WriteLine("*|       7.    Exit.                                                            |*");
    Console.WriteLine("*|                                                                              |*");
    Console.WriteLine("**********************************************************************************");
    
}











static DataTable GetDataTable(string sql, string paramName, string paramValue)
{
    var connString = "server=(localdb)\\mssqllocaldb;integrated security=true; database=RandomUsers";
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


static void ExecuteSQL(string sql, string paramName, string paramValue)
{
    var connString = "server=(localdb)\\mssqllocaldb;integrated security=true; database=RandomUsers";
    var dt = new DataTable();
    using (var connection = new SqlConnection(connString))

    {
        connection.Open();

        using (var command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue(paramName, paramValue);
            command.ExecuteNonQuery();

        }

    }
    
}



 void PrintRow()
{
    foreach (DataRow row in dt.Rows)
    {
        for (var i = 0; i < dt.Columns.Count; i++)
        {
            Console.WriteLine(row[i] + " ");
        }
        Console.WriteLine();
    }
}

