using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MySQL_Uppgift;

namespace MySQL_Uppgift
{
    public class Helper
    {
        int MenuChoice = 0;
        bool Exit = false;
        int Counter = 0;


        public static DataTable GetDataTable(string sql)
        {
            var connString = "server=(localdb)\\mssqllocaldb;integrated security=true; database=RandomUsers";
            var dt = new DataTable();
            using (var connection = new SqlConnection(connString))

            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }

            }
            return dt;
        }

        internal void StartProgram()
        {
            Console.Clear();
            GraphicMeny();
            Console.Write("Enter Choice: ");
            MenuChoice = TryCatch(MenuChoice);
            while (Exit == false)
            {
                GraphicMeny();
                Console.Clear();
                switch (MenuChoice)
                {
                    case 1:
                        First_UniqueCountries();
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
                        Exit = true;
                        break;

                    default:
                        MenuChoice = 0;
                        break;


                }

            }
        }

        private void GraphicMeny()
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

        public void First_UniqueCountries()
        {

            Counter = 0;
            var sql = "select country, count(distinct country) as 'unique country' from RandomUsers group by country";
            var dt = GetDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                Counter++;
                Console.WriteLine(row["country"] + " " + Counter);
                
                //for (var i = 0; i < dt.Columns.Count; i++)
                //{
                //    Console.WriteLine("There are " + row[i] + " unique Countries");
                //}
                //Console.WriteLine();
            }
            Console.WriteLine("");
            Console.WriteLine("There are " + Counter + " Unique Countries");
            Console.ReadKey();
            StartProgram();
        }

        public void PrintRows()
        {
            
            

            
        }

        public int TryCatch(int Choose)
        {
            try
            {
                Choose = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Choose = 0;
                Console.Clear();
            }

            return Choose;
        }
    }
}