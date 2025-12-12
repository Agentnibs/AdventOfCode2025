
//given a list of ranges of IDs
//find invalid IDs by identifying if the ID is made only of some sequence of digits repeated twice
//So, 55 (5 twice), 6464 (64 twice), and 123123 (123 twice) would all be invalid IDs.

using AdventOfCode._2025.Helpers;

namespace AdventOfCode2025
{

    public class Day2
    {
        // Day 2 code would go here

    //     List<string> listOfIDRanges = new List<string>
    // {
    //     "11-22",
    //     "95-115",
    //     "998-1012",
    //     "1188511880-1188511890",
    //     "222220-222224",
    //     "1698522-1698528",
    //     "446443-446449",
    //     "38593856-38593862",
    //     "565653-565659",
    //     "824824821-824824827",
    //     "2121212118-2121212124"

    // };

        List<long> ListOfInvalidIDs = new List<long>();


 



        public void Day2Solved()
        {
            var listOfIDRanges = Helpers.ReadFileAndReturnListOfStrings(@"C:\Users\AlexC\OneDrive\Documents\Code\AdventOfCode\2025\testdata\Day2\day2input.txt");

            foreach (var id in listOfIDRanges)
            {
                var startingValue = long.Parse(id.Split('-')[0]);
                var endingValue = long.Parse(id.Split('-')[1]);

                //Notes for myself
                //a range is given as two numbers separated by a hyphen
                //I split the string to get a starting and ending value
                //I loop from starting to ending value inclusive
                //for each value, I convert to a string I get the length of the string
                //if the length is odd, I skip it because it can't be made of a sequence repeated twice
                //if the length is even, I split the string in half
                //I compare the first half to the second half
                //if they are the same, I add the number to the list of invalid IDs
                for (long i = startingValue; i <= endingValue; i++)
                {
                     var idString = i.ToString();
                     var length = idString.Length;

                    //Ok so now any sequence of digits that is repeated twice makes an invalid ID

                    //so maybe we can start by looking for sequences where all the numbers are the same, to remove them from the pile
                    //like 11, 22, 3333, 4444, 555555, etc
                    //check if distinct count is 1
                    // if (idString.Distinct().Count() == 1)
                    // {
                    //     Console.WriteLine($"Invalid ID found: {idString}");
                    //     ListOfInvalidIDs.Add(i);
                    //     continue;
                    // }

                    //get the factors of the length
                    var factors = new List<int>();
                    for (int f = 1; f <= length / 2; f++)
                    {
                        if (length % f == 0)
                        {
                            factors.Add(f);
                        }
                    }

                    //use the factors to check for repated factors, from smallest to largest
                    bool isInvalid = false;
                    foreach (var factor in factors)
                    {
                        var segment = idString.Substring(0, factor);
                        var repeatedSegment = string.Concat(Enumerable.Repeat(segment, length / factor));
                        if (repeatedSegment == idString)
                        {
                            Console.WriteLine($"Invalid ID found: {idString}");
                            ListOfInvalidIDs.Add(i);
                            isInvalid = true;
                            break;
                        }
                    }


                    
                    //check if length is odd
                    // if (length % 2 != 0)
                    // {
                    //     //odd length IDs cannot be made of a sequence repeated twice
                    //     continue;
                    // }


                    // var halfLength = length / 2;
                    // var firstHalf = idString.Substring(0, halfLength);
                    // var secondHalf = idString.Substring(halfLength);

                    // if (firstHalf == secondHalf)
                    // {
                    //     Console.WriteLine($"Invalid ID found: {idString}");
                    //     ListOfInvalidIDs.Add(i);
                    // }
                }
            }

            Console.WriteLine("Sum of invalid IDs: " + ListOfInvalidIDs.Sum());
        }



    }
}