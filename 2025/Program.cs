
using System;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;


namespace AdventOfCode2025
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Day1 day1 = new Day1();
            // day1.Initialize(@"C:\Users\AlexC\OneDrive\Documents\Code\AdventOfCode\2025\testdata\Day1\input.txt");


            Day2 day2 = new Day2();
            var list = day2.ReadFileAndReturnListOfStrings();
            day2.SomeMethod(list);
        }
    }


    //main program class

}