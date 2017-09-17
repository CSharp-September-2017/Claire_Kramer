﻿using System;
using System.Collections.Generic;
using DbConnection;

namespace dbconnection
{
    class Program
    {
        static void Read(){
            string query = "Select * from Users;";
            List<Dictionary<string, object>> result = DbConnector.Query(query);
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
            Insert();
        }
    }
}