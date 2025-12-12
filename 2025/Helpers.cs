

namespace AdventOfCode._2025.Helpers
{
    public static class Helpers
    {
        public static List<string> ReadFileAndReturnListOfStrings(string path)
        {
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
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
    }
}