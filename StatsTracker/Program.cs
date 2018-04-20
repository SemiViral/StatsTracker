using System;

namespace StatsTracker {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Loading all statistic tables.");
        }

        public static string GetUserInput() {
            string rawInput = string.Empty;

            do {
                rawInput = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(rawInput));

            return rawInput;
        }
    }
}
