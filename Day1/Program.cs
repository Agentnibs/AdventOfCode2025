
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
            Day2 day2 = new Day2();
            var list = day2.ReadFileAndReturnListOfStrings();
            day2.SomeMethod(list);

        }
    }


    //main program class

}