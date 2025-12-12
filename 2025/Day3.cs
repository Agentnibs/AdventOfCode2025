

using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using AdventOfCode._2025.Helpers;

namespace AdventOfCode2025
{

    public class Day3
    {

        public void Part1()
        {
            var lines = Helpers.ReadFileAndReturnListOfStrings(@"C:\Users\AlexC\OneDrive\Documents\Code\AdventOfCode\2025\testdata\Day3\input.txt");

            #region 12 pivot approach
            // foreach (var line in lines)
            // {
            //     //turn the number into a string list
            //     string numberAsString = line.ToString();
            //     List<int> numberList = new List<int>();
            //     foreach (char character in numberAsString)
            //     {
            //         double x = Char.GetNumericValue(character);
            //         numberList.Add((int)x);
            //     }

            //     List<int> biggestValues = new List<int>();
            //     int pivotIndex = 0;

            //     List<int> iterableList = new List<int>();
            //     iterableList =  numberList.Skip(0).Take(numberList.Count - 12).ToList();

            //     int whileIterator = iterableList.Count;
            //     //while (iterableList.Count >= 0)
            //     //{
            //         var largestPossibleNum = 9;

            //         for (int i = 0; i <= iterableList.Count -1; i++)
            //         {

            //             if (iterableList[i] >= largestPossibleNum)
            //             {
            //                 biggestValues.Add(numberList[i]);
            //                 pivotIndex = i;
            //                 largestPossibleNum--;

            //             }
            //             else
            //             {

            //             }


            //         }

            //         iterableList.RemoveRange(0, pivotIndex);
            //     //}

            //     //Look for the highest number


            //     Console.WriteLine(numberList);
            //     //foreach (var num in )
            // }

            #endregion

            #region BRUTE FORCE!!!!!

           
            List<double> biggestValues = new List<double>();
            foreach (var line in lines)
            {
                //turn the number into a string list
                string numberAsString = line.ToString();
                List<int> numberList = new List<int>();
                foreach (char character in numberAsString)
                {
                    double x = Char.GetNumericValue(character);
                    numberList.Add((int)x);
                }


                int startingPosition = 0;
                int reserveBank = 11;
                string biggestNumber = "";
                

                int range = numberList.Count - reserveBank;

                for (int i = 0; i < 12; i++)
                {

                //find the largest number in the current range
                var sublist = numberList.GetRange(startingPosition, range);

                int largestNum = numberList.GetRange(startingPosition, range).Max();
                
                int largestNumPosition = sublist.IndexOf(sublist.Max());
                // if (largestNumPosition == 0)
                //     {
                //         largestNumPosition++;
                //     }
                
                reserveBank--;
                startingPosition = startingPosition + largestNumPosition+1;;
                range = numberList.Count - startingPosition - reserveBank;
                //Console.WriteLine($"Largest number found: {largestNum} at position {largestNumPosition}");
                biggestNumber += largestNum.ToString();
                }

                Console.WriteLine($"biggest number: {biggestNumber}");
                biggestValues.Add(Double.Parse(biggestNumber));
                
            }

            Console.WriteLine("Sum of all numbers:" + biggestValues.Sum());

        }

        public int someRecursion(int startingPosition, int range, List<int> numberList)
        {

            if (startingPosition > range)
            {
                return 0;
            }

            int nextPosition = startingPosition;
            for (int i = startingPosition; i <= range; i++)
            {
                //find the largest number in the current range
                int largestNum = numberList.GetRange(i, range - i + 1).Max();
                int largestNumPosition = numberList.IndexOf(numberList.GetRange(i, range - i + 1).Max());
                Console.WriteLine($"Largest number found: {largestNum} at position {i}");

                nextPosition = i;
            }

            someRecursion(nextPosition + 1, range, numberList);
            return 0;
        }
    }
}
#endregion


public class Result
{
    public List<LineNumber> LineNumber { get; set; }
}

public class LineNumber
{
    public List<PositionAndValue> PositionAndValues { get; set; }
}
public class PositionAndValue
{

    public string OriginalString { get; set; }
    public int AdjustedPosition { get; set; }
    public int OriginalPosition { get; set; }
    public char Value { get; set; }
}

