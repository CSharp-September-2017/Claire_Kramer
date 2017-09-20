using System;
using System.Collections.Generic;
using DbConnection;
// Solid coding Claire.  It looks like it's making sense to you. Just make sure to run the Read() after every Insert();
namespace dbconnection
{
    class Program
    {
        static void Read(){
            string query = "Select * from Users;";
            List<Dictionary<string, object>> result = DbConnector.Query(query);
            foreach(Dictionary<string, object> dict in result)
            {   
                foreach (KeyValuePair<string, object> item in dict)
                {
                    Console.WriteLine(item.Value);   
                }
            }
        }

        static void Insert(){
            Console.Write("First Name: ");
            string FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string LastName = Console.ReadLine();
            Console.Write("Favorite Number: ");
            string FavNum = Console.ReadLine();

            string insert = $"Insert Into Users (firstName, lastName, favoriteNumber) Values('{FirstName}', '{LastName}', '{FavNum}');";
            DbConnector.Execute(insert);
        }
        static void Main(string[] args)
        {
            Read();
        }
    }
}
