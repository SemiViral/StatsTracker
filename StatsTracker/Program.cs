using System;
using System.Collections.Generic;
using System.Linq;
using StatsTracker.Model;

namespace StatsTracker {
    public class Program {
        #region MEMBERS

        private static List<StatTable> Tables { get; set; }

        #endregion

        public static void Main(string[] args) {
            Tables = new List<StatTable>();

            Console.WriteLine("Loading all statistic tables.");

            // todo write code to load tables from database/file
            Tables.Add(new StatTable("Basic"));
            Tables[0].StatisticLines = new List<StatLine> {new StatLine(new List<Stat> {new Stat<int>(0, "BasicStat01", 1)})};
        }

        public static string GetUserInput() {
            string rawInput = string.Empty;

            do {
                rawInput = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(rawInput));

            return rawInput;
        }

        private static void ParseUserInput(string userInput) {
            string[] userInputSplit = userInput.Split(" ");

            switch (userInputSplit[0]) {
                case "create":
                    break;
                case "delete":
                    break;
                case "view":
                    break;
                case "modify":
                    break;
                default:
                    break;
            }
        }

        private static void CreateTable(string inputValues) {

        }

        private static void DeleteTable(StatTable table) {

        }

        private static StatTable GetTable(string tableName) {
            return Tables.SingleOrDefault(table => table.Name.Equals(tableName));
        }
    }
}
