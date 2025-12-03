using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day1.Tests
{
    [TestClass]
    public class Day1Tests
    {
        private static string FindInputFile()
        {
            // Walk upward from the test assembly location to find input.txt
            var dir = AppContext.BaseDirectory!;
            for (int i = 0; i < 12; i++)
            {
                var candidate = Path.Combine(dir, "input.txt");
                if (File.Exists(candidate)) return candidate;
                dir = Path.GetFullPath(Path.Combine(dir, ".."));
            }
            throw new FileNotFoundException("Could not find input.txt when searching upward from test folder.");
        }

        [TestMethod]
        public void InputFile_NotEmpty()
        {
            var path = FindInputFile();
            var lines = File.ReadAllLines(path);
            Assert.IsTrue(lines.Length > 0, "input.txt should contain at least one line");
        }

        [TestMethod]
        public void FirstLine_IsValidInstruction()
        {
            var path = FindInputFile();
            var first = File.ReadLines(path).FirstOrDefault();
            Assert.IsFalse(string.IsNullOrWhiteSpace(first), "First line should not be empty");

            // Expect format like R22 or L7
            var m = Regex.Match(first!.Trim(), "^[RL]\\d+$", RegexOptions.IgnoreCase);
            Assert.IsTrue(m.Success, $"First line '{first}' does not match expected instruction format (R/L + digits)");
        }
    }
}
