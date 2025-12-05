
namespace AdventOfCode2025
{
    public class Day1
    {
        int maxValue = 99;
        int minValue = 0;
        int startingValue = 50;
        int currentPosition;
        int countOfZeros = 0;
        public int passesZero = 0;

        public int RotateRight(int value)
        {

            var sum = currentPosition + value;

            //thhiis might never occur
            if (sum == 0)
            {
                //countOfZeros++;
                //passesZero++;
                return currentPosition;
            }

            if (sum > maxValue)
            {
                var position = sum % 100;

                if (sum > 100)
                {
                    passesZero += Math.Abs(sum / 100);
                }


                if (position == 0)
                {
                    //passesZero++;
                    countOfZeros++;
                }
                return position;
            }

            else
            {
                return sum;
            }

            //Handle overflow
            //100 -> 0 + 100 - 99 - 1 = 0
            // while (currentValue > maxValue)
            // {
            //     //int remainder = currentValue % 100;
            //     //currentValue = currentValue - maxValue - 1;



            //     currentValue = currentValue % 100;
            //     passesZero++;

            // }


        }

        public int RotateLeft(int value, int linenumber = 0)
        {

            //check the current value
            //rotate left by the value

            //substract the value from the current value
            //if the value == 0, we landed on zero, count it, and 0 is the current position.
            //if the value is > than 0, than that's the new current value (it didn't pass zero)
            //if the value is < than 0, we have to handle underflow (it passed zero)
            //we can get the remainder of the subtraction % 100, this will be the current posistion
            // But we need to see how many rotations of 100 we did to count how many times we passed zero
            //We can do this by dividing the subtraction by 100 and taking the absolute value of that

            var passCountToAdd = 0;
            var previousPosition = currentPosition;
            var difference = currentPosition - value;

            //if difference is 0, then we landed on zero and it counts as passing zero
            if (difference == 0)
            {
                countOfZeros++; //count landing on zero
                                //passesZero++; //count as passing zero
                return difference;
            }

            //if difference is 0, then the amount of ticks did not pass zero, so we can return it as the current position
            //and assume it did not pass zero
            if (difference > 0)
            {
                return difference;
            }

            //otherwise difference is negative we have to handle underflow. We passed zero at least once
            else
            {
                //remainder will tell us the current position
                int remainder = difference % 100;

                //if remainder is 0, we landed on zero
                if (remainder == 0)
                {
                    countOfZeros++; //count landing on zero
                                    //passesZero++; //count as passing zero
                }

                //if the difference is greater than -100 and it's not starting from 0 we didn't do a full roation but passed zero once
                if (difference > -100 && currentPosition != 0)
                {
                    //HOLD UP- if we're at like 40 and move L20, that doesn't pass zero and shouldnt be counted
                    //This was counting a zero pass when the turn was not a full rotation every time


                    passCountToAdd++;
                }
                //otherwise we did at least 1 full rotation
                else
                {
                    var x = Math.Abs(value / 100);//calculate full rotations
                    passCountToAdd += x;
                }

                //calculate how many times we passed zero
                //+ 1; //this won't count a single rotation... add 1?

                passesZero += passCountToAdd;

                var calculateResult = 100 - (remainder * -1);

                //   foreach (var i in Enumerable.Range(0, passCountToAdd))
                //     {
                //         //Console.WriteLine($"{linenumber} After R{value}, current position goes {previousPosition} -> {currentPosition} : Num of Times Hit 0: {countOfZeros} -- Num of times passed 0: {passesZero}");
                //         //Console.WriteLine($"{linenumber} After L{value}, current position goes {previousPosition} -> {currentPosition} : Num of Times Hit 0: {countOfZeros} -- Num of times passed 0: {passesZero}");
                //         Console.WriteLine($"Line: {linenumber}. Passed 0 on L{value} rotation {i + 1} of {passCountToAdd}. Total passes now: {passesZero}");
                //     }

                if (calculateResult == 100)
                {
                    return 0;
                }
                else
                {
                    return calculateResult;
                }
            }


        }
        //if difference is positive just return it



        //Substract value from current value because you're turning left

        //So if current value is 0 and you turn left 1, you go to 99


        //example current value = 50
        //turn left 500
        //current value = -450
        //-450 % 100 = -50
        //-50 + 100 = 50
        //

        //Handle underflow


        //passesZero += Math.Abs(num);

        //  return currentValue;


        public int Initialize(string filePath)
        {
            var lines = System.IO.File.ReadAllLines(filePath);
            currentPosition = startingValue;
            Console.WriteLine($"Starting at {currentPosition}");
            //return CalculateAttempt1(lines);
            return CalculateAttempt3(lines);
        }


        public int CalculateAttempt1(string[] lines)
        {
            foreach (var line in lines)
            {
                var direction = line[0]; //First character
                var value = int.Parse(line.Substring(1)); //Rest of the string


                //Perform rotation, maybe pass in the remainder and current value to check if we pass 0 
                if (direction == 'R')
                {
                    currentPosition = RotateRight(value);
                    Console.WriteLine($"After R{value}, current position is {currentPosition} -- Num of Times Hit 0: {countOfZeros} -- Num of times passed 0: {passesZero}");
                    //Console.WriteLine($"");
                }
                else if (direction == 'L')
                {
                    currentPosition = RotateLeft(value);
                    Console.WriteLine($"After L{value}, current position is {currentPosition} -- Num of Times Hit 0: {countOfZeros} -- Num of times passed 0: {passesZero}");
                    //Console.WriteLine($"");
                }

                // if (currentPosition == 0)
                // {
                //     countOfZeros++;
                // }

            }

            return countOfZeros;
        }

        public int CalculateAttempt2(string[] lines)
        {
            //Similar to attempt 1 but we track passing zero differently

            var linenumber = 0;
            foreach (var line in lines)
            {
                linenumber++;
                var direction = line[0]; //First character
                var value = int.Parse(line.Substring(1)); //Rest of the string
                int previousPosition = currentPosition;
                //Figure out Right Turns
                if (direction == 'R')
                {
                    var nextPosition = currentPosition + value;
                    var passCountToAdd = 0;

                    if (nextPosition % 100 == 0)
                    {
                        countOfZeros++;
                        passCountToAdd += Math.Abs(nextPosition / 100) - 1;
                        // if (nextPosition / 100 == 1)
                        // {
                        //     countOfZeros++;
                        // }

                        // else
                        // {
                        //     passesZero += Math.Abs(nextPosition / 100);
                        // }

                        currentPosition = 0;
                    }

                    else if (nextPosition > 100)
                    {
                        var x = Math.Abs(nextPosition / 100);
                        if (x >= 1)
                        {
                            passCountToAdd += x;
                        }

                        currentPosition = nextPosition % 100;

                        if (currentPosition == 0)
                        {
                            countOfZeros++;
                        }
                    }

                    else
                    {
                        currentPosition = nextPosition;
                    }
                    passesZero += passCountToAdd;


                    Console.WriteLine($"After R{value}, current position goes {previousPosition} -> {currentPosition} : Num of Times Hit 0: {countOfZeros} -- Num of times passed 0: {passesZero}");

                    if (currentPosition == 0)
                    {
                        //Console.WriteLine($"{linenumber} After R{value}, current position goes {previousPosition} -> {currentPosition} : Num of Times Hit 0: {countOfZeros} -- Num of times passed 0: {passesZero}");
                    }



                    foreach (var i in Enumerable.Range(0, passCountToAdd))
                    {
                        //Console.WriteLine($"{linenumber} After R{value}, current position goes {previousPosition} -> {currentPosition} : Num of Times Hit 0: {countOfZeros} -- Num of times passed 0: {passesZero}");
                        //Console.WriteLine($"{linenumber} After R{value}, current position goes {previousPosition} -> {currentPosition} : Num of Times Hit 0: {countOfZeros} -- Num of times passed 0: {passesZero}");
                        //Console.WriteLine($"Line: {linenumber}. Passed 0 on R{value} rotation {i + 1} of {passCountToAdd}. Total passes now: {passesZero}");
                    }

                    continue;
                }

                else if (direction == 'L')
                {

                    currentPosition = RotateLeft(value, linenumber);

                    Console.WriteLine($"After L{value}, current position goes {previousPosition} -> {currentPosition} : Num of Times Hit 0: {countOfZeros} -- Num of times passed 0: {passesZero}");

                    if (currentPosition == 0)
                    {
                        //.WriteLine($"{linenumber} After L{value}, current position goes {previousPosition} -> {currentPosition} : Num of Times Hit 0: {countOfZeros} -- Num of times passed 0: {passesZero}");
                    }
                }




            }

            return countOfZeros;
        }

        public int CalculateAttempt3(string[] lines)
        {
            //Try a different way of tracking passing zero
            var position = 50;
            var timesAtZero = 0;
            var timesPassingZero = 0;

            foreach (var line in lines)
            {
                var direction = line[0]; //First character
                var value = int.Parse(line.Substring(1)); //Rest of the string


                if (direction == 'R')
                {
                    timesPassingZero += (position + value) / 100; //integer division to get number of times passed zero
                    position = position % 100; //remaineder to get current position
                }
                else
                {
                    if (position == 0)
                    {
                        timesPassingZero += value / 100; // if starting point is 0, divide by 100 to get number of times passed zero
                    }
                    else if (value >= position)
                    {
                        //if value is 5 and position is 10, we get -5 % 100 = 95, so we passed zero once
                        timesPassingZero += (value - position) / 100 + 1;
                    }


                    position = (position - value) % 100;
                }

            }
            Console.WriteLine("Total times passing zero: " + timesPassingZero);
            return timesAtZero;
        }


        public void CalculateAttempt4()
        {
            // Save your input data to a file named 'input.txt' or paste it here
            string input = File.ReadAllText("C:\\Users\\AlexC\\OneDrive\\Documents\\Code\\AdventOfCode2025\\input.txt");

            // Clean input if it contains "" prefixes from the copy-paste
            var lines = input.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                             .Where(x => x.StartsWith("L") || x.StartsWith("R"));

            long currentPosition = 50;
            long totalEvents = 0;

            foreach (var turn in lines)
            {
                char direction = turn[0];
                int amount = int.Parse(turn.Substring(1));
                long prevPosition = currentPosition;

                if (direction == 'R')
                {
                    currentPosition += amount;
                    // Count multiples of 100 in interval (prev, curr]
                    totalEvents += (long)Math.Floor(currentPosition / 100.0) - (long)Math.Floor(prevPosition / 100.0);
                }
                else // 'L'
                {
                    currentPosition -= amount;
                    // Count multiples of 100 in interval [curr, prev)
                    // Logic: floor((prev - 1) / 100) - floor((curr - 1) / 100)
                    totalEvents += (long)Math.Floor((prevPosition - 1) / 100.0) - (long)Math.Floor((currentPosition - 1) / 100.0);
                }
            }

            Console.WriteLine("Total times landed on or passed 0: " + totalEvents);
        }

    }

}
