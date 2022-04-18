using System;
using System.Collections.Generic;

namespace HtmlBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var acceptedValues = new List<string>() { "div", "span", "close", "exit" };
            var textTags = new List<string>() { "p", "h1", "h2", "h3", "h4", "h5", "h6", "img" };
            var tagStack = new Stack<string>();

            var UserInputList = new List<string>();
            string userInput;

            AddRequiredTags(UserInputList, "html", tagStack);

            AddRequiredTags(UserInputList, "head", tagStack);

            AddRequiredTags(UserInputList, "body", tagStack);
            foreach (string e in tagStack)
            {
                Console.WriteLine(e);
            }


            do
            {
                {
                    Console.WriteLine("Add tag:\n");
                    userInput = Console.ReadLine().ToLower();

                    if (acceptedValues.Contains(userInput) || textTags.Contains(userInput))
                    {

                        AddTextTags(textTags, UserInputList, userInput, tagStack);

                        AddItemsToUserInputList(textTags, UserInputList, userInput, tagStack);

                        DisplayListContent(UserInputList);


                        foreach (string e in tagStack)
                        {
                            Console.WriteLine(e);
                        }


                    }
                    else
                    {
                        Console.WriteLine("Incorrect value\n");
                    }
                }
                if (userInput == "exit")
                {
                    SaveAsHtml(UserInputList);
                    Environment.Exit(0);
                }

            }
            while (userInput != "exit");
        }

        private static void SaveAsHtml(List<string> UserInputList)
        {
            System.IO.File.WriteAllLines(@"C:\Users\cezar.iancu\Documents\Output.html", UserInputList);
        }

        private static string FormatValue(string userInput, string text, Stack<string> stackTag)
        {
            return userInput switch
            {
                "html" => "<!DOCTYPE html>",
                "head" => "<head><title>HtmlBuilder</title></head>",
                "body" => "<body>",
                "div" => "<div>",
                "span" => "<span>",
                "p" => "<p>" + text + "</p>",
                "h1" => "<h1>" + text + "</h1>",
                "h2" => "<h2>" + text + "</h2>",
                "h3" => "<h3>" + text + "</h3>",
                "h4" => "<h4>" + text + "</h4>",
                "h5" => "<h5>" + text + "</h5>",
                "h6" => "<h5>" + text + "</h6>",
                "img"=> "<img src='"+text+"' alt='imagine'/>",
                "close" =>stackTag.Count>0? stackTag.Pop() : null,
                _ => ""
            };
        }

        private static void DisplayListContent(List<string> UserInputList)
        {
            foreach (string i in UserInputList)
            {
                Console.WriteLine("ai in lista {0}\n", i);
            }
        }

        private static void AddItemsToUserInputList(List<string> textTags, List<string> UserInputList, string userInput, Stack<string> stackTag)
        {
            if (!textTags.Contains(userInput))
            {
                UserInputList.Add(FormatValue(userInput, null, stackTag));
                if (userInput != "close")
                {
                    if(stackTag.Count > 0)
                    {
                        PushClosingTags(userInput, stackTag);
                    }
                }
            }
        }

        private static void PushClosingTags(string userInput, Stack<string> stackTag)
        {
            stackTag.Push("</" + userInput + ">");
        }

        private static void AddTextTags(List<string> textTags, List<string> UserInputList, string userInput, Stack<string> stackTag)
        {
            if (textTags.Contains(userInput))
            {
                Console.WriteLine("Add text:");
                string tagText = Console.ReadLine();
                UserInputList.Add(FormatValue(userInput, tagText,null));
           
            }

        }

        private static string AddRequiredTags(List<string> UserInputList, string tag, Stack<string> stackTag)
        {
            string userInput;
            do
            {
                Console.WriteLine("Add {0} tag:\n", tag);
                userInput = Console.ReadLine().ToLower();

                if (userInput == tag)
                {
                    UserInputList.Add(FormatValue(userInput, null,null));
                    if (tag != "head")
                    {
                        PushClosingTags(userInput, stackTag);
                    }

                    DisplayListContent(UserInputList);
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
