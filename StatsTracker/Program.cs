using System;
using System.Collections.Generic;
using StatsTracker.Model;

namespace StatsTracker {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Loading all statistic tables.");

            // todo write code to load tables from database/file
            Tables = new Dictionary<string, StatTable>();
        }

        public static string GetUserInput() {
            string rawInput = string.Empty;

            do {
                rawInput = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(rawInput));

            return rawInput;
        }

        private static Dictionary<string, StatTable> Tables { get; set; }
    }
}
