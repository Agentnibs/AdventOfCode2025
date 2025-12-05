
//given a list of ranges of IDs
//find invalid IDs by identifying if the ID is made only of some sequence of digits repeated twice
//So, 55 (5 twice), 6464 (64 twice), and 123123 (123 twice) would all be invalid IDs.

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


    public List<string> ReadFileAndReturnListOfStrings()
        {
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\AlexC\OneDrive\Documents\Code\AdventOfCode2025\day2input.txt"))
                {                
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var array = line.Split(',');
                        foreach (var item in array)
                        {
                            lines.Add(item.Trim());
                        }
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return lines;
        }



        public void SomeMethod(List<string> listOfIDRanges)
        {
            foreach (var id in listOfIDRanges)
            {
                var startingValue = long.Parse(id.Split('-')[0]);
                var endingValue = long.Parse(id.Split('-')[1]);

                for (long i = startingValue; i <= endingValue; i++)
                {

                    var idString = i.ToString();
                    var length = idString.Length;

                    if (length % 2 != 0)
                    {
                        //odd length IDs cannot be made of a sequence repeated twice
                        continue;
                    }

                    var halfLength = length / 2;
                    var firstHalf = idString.Substring(0, halfLength);
                    var secondHalf = idString.Substring(halfLength);

                    if (firstHalf == secondHalf)
                    {
                        Console.WriteLine($"Invalid ID found: {idString}");
                        ListOfInvalidIDs.Add(i);
                    }
                }
            }

            Console.WriteLine("Sum of invalid IDs: " + ListOfInvalidIDs.Sum());
        }



    }
}