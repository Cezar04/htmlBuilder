using System;
using System.Collections.Generic;

namespace HtmlBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var acceptedValues = new List<string>() { "div", "span", "close", "exit" };
            var textTags = new List<string>() { "p", "h1", "h2", "h3", "h4", "h5", "h6", };

            var UserInputList = new List<string>();
            string userInput;

            AddRequiredTags(UserInputList, "html");

            AddRequiredTags(UserInputList, "head");

            AddRequiredTags(UserInputList, "body");

            do
            {
                {
                    Console.WriteLine("Add tag:\n");
                    userInput = Console.ReadLine().ToLower();

                    if (acceptedValues.Contains(userInput) || textTags.Contains(userInput))
                    {

                        AddTextTags(textTags, UserInputList, userInput);

                        AddItemsToUserInputList(textTags, UserInputList, userInput);

                        DisplayListContent(UserInputList);

                    }
                    else
                    {
                        Console.WriteLine("Incorrect value\n");
                    }
                }
                if (userInput == "exit")
                {
                    Environment.Exit(0);
                }

            }
            while (userInput != "exit");
        }

        private static void DisplayListContent(List<string> UserInputList)
        {
            foreach (string i in UserInputList)
            {
                Console.WriteLine("ai in lista {0}\n", i);
            }
        }

        private static void AddItemsToUserInputList(List<string> textTags, List<string> UserInputList, string userInput)
        {
            if (!textTags.Contains(userInput))
            {
                UserInputList.Add(userInput);
            }
        }

        private static void AddTextTags(List<string> textTags, List<string> UserInputList, string userInput)
        {
            if (textTags.Contains(userInput))
            {
                Console.WriteLine("Add text:");
                string tagText = Console.ReadLine();
                UserInputList.Add(userInput + " " + tagText);
            }
        }

        private static string AddRequiredTags(List<string> UserInputList, string tag)
        {
            string userInput;
            do
            {
                Console.WriteLine("Add {0} tag:\n", tag);
                userInput = Console.ReadLine().ToLower();

                if (userInput == tag)
                {
                    UserInputList.Add(userInput);

                    foreach (string i in UserInputList)
                    {
                        Console.WriteLine("ai in lista {0}\n", i);
                    }
                }
                else if (userInput == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Value should be: {0}\n", tag);
                }
            } while (userInput != tag);
            return userInput;
        }
    }
}
