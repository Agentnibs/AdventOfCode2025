
using System.Numerics;

namespace AdventOfCode2025
{
    public class Day1
    {

        int countOfZeros = 0;
        public int passesZero = 0;


        public void Initialize(string filePath)
        {
            var lines = System.IO.File.ReadAllLines(filePath);
            CalculateAttempt5(lines);

        }


        public void CalculateAttempt5(string[] lines)
        {
            int currentPosition = 50;

            //Loop through each line
            foreach (var line in lines)
            {
                var direction = line[0]; //First character
                var rotation = int.Parse(line.Substring(1)); //Rest of the string
                
                //use rotation to define the boundy of the for loop
                //example R10 we will loop 10 times, each time incrementing currentPosition by 1
                //allowing us to track each individual step and see if we pass 0
                for (int i = 1; i <= rotation; i++)
                {
                    if (direction == 'R')
                    {
                        //then we move right
                        currentPosition++;
                    }
                    else
                    {
                        //otherwise move left..by substracting!
                        currentPosition--;
                    }

                    //if it's at a 0. we either touched or landed on it
                    if (currentPosition % 100 == 0)
                    {
                        //i increments each loop, if i is at the end of the loop...so equals rotaion. Than we landed on 0
                        if (i == rotation)
                        {
                            //we landed on 0
                            countOfZeros++;
                        }
                        else
                        {
                            passesZero++;
                        }
                    }
                }

            }

            Console.WriteLine("Count of Zeroes: " + countOfZeros);
            Console.WriteLine("Pased zero: " + passesZero);
            Console.WriteLine("Total: " + (countOfZeros + passesZero));
        }

    }

}
