using System;
using System.Collections.Generic;
using StatsTracker.Model;

namespace StatsTracker {
    public class Program {
        #region MEMBERS

        private static Dictionary<string, StatTable> Tables { get; set; }

        #endregion

        public static void Main(string[] args) {
            Tables = new Dictionary<string, StatTable>();

            Console.WriteLine("Loading all statistic tables.");

            // todo write code to load tables from database/file
            Tables.Add("Basic", new StatTable("Basic"));
            Tables["Basic"].StatisticLines = new List<StatLine> {new StatLine(new List<Stat> {new Stat<int>(0, "BasicStat01", 1)})};
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
