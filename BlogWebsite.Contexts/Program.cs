using System;

namespace BlogWebsite.Contexts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //this is a workaround - you can't have EF6 in .NET Standard library, but you can use it in .NET Core Console App - that's why I used it as core project
        }
    }
}
