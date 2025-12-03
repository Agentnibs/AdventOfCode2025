
using System;
using System.IO;


//main program class
public static class Program
{
    public static void Main(string[] args)
    {
        Day1 day1 = new Day1();
        var result = day1.ReadInput("C:\\Users\\AlexC\\OneDrive\\Documents\\Code\\AdventOfCode2025\\input.txt");
        Console.WriteLine($"Number of times we hit 0: {result}");
    }
}



//Start at 50
//R22 -> 72
//R26 -> 98
//L20 -> 78
//R20 -> 98
//R9  -> 7 (wraps around)
//L50 -> 57

public class Day1
{
    int maxValue = 99;
    int minValue = 0;
    int startingValue = 50;
    int currentValue;
    int countOfZeros = 0;

    public int RotateRight(int value)
    {
        //Add value to current value 
        currentValue = currentValue + value;

        //Handle overflow
        //100 -> 0 + 100 - 99 - 1 = 0
        while (currentValue > maxValue)
        {
            currentValue = currentValue - maxValue - 1;
        }

        return currentValue;
    }

    public int RotateLeft(int value)
    {
        //Substract value from current value because you're turning left
        currentValue = currentValue - value;
        //So if current value is 0 and you turn left 1, you go to 99


        //Handle underflow
        while (currentValue < minValue)
        {                   //99        0          +1 tohandle 0 case  
            // var a = maxValue - (currentValue * -1);
            // var b = a + 1;
            // currentValue = b;
            currentValue = maxValue + currentValue + 1; //current value is always negative here so adding it is like subtracting
        }

        return currentValue;
    }

    public int ReadInput(string input)
    {
        //read file line by line
        var lines = System.IO.File.ReadAllLines(input);
        currentValue = startingValue;
        Console.WriteLine($"Starting at {currentValue}");

        foreach (var line in lines)
        {
            var direction = line[0]; //First character
            var value = int.Parse(line.Substring(1)); //Rest of the string

            if (direction == 'R')
            {
                currentValue = RotateRight(value);
                Console.WriteLine($"After R{value}, current value is {currentValue}");
            }
            else if (direction == 'L')
            {
                currentValue = RotateLeft(value);
                Console.WriteLine($"After L{value}, current value is {currentValue}");
            }

            if (currentValue == 0)
            {
                countOfZeros++;
            }

            
        }

        return countOfZeros;
    }
    
}     
                