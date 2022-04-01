using System;
using System.Collections.Generic;

namespace HtmlBuilder
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> ValueList = new List<string>();
            string userInput;
            do
            {
                {
                    Console.WriteLine("Enter input:");
                    userInput = Console.ReadLine().ToLower();
                    ValueList.Add(userInput);
                    foreach (string i in ValueList)
                    {
                        Console.WriteLine("ai in list {0}", i);
                    }

                }
            }
            while (userInput != "exit");

        }
    }
}
