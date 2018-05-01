using System;
using System.Collections.Generic;
using System.Linq;
using StatsTracker.ComponentModel.Event;
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
            CreateTableFromValues(inputValues.Split(" "));
        }

        private static void CreateTable(string[] inputValues) {
            CreateTableFromValues(inputValues);
        }

        private static void CreateTableFromValues(string[] parsedInputValues) {
            if (!parsedInputValues[0].ToLower().Equals("create"))
                return;

            StatTable table = new StatTable(string.Empty);

            table.Name = parsedInputValues[1].Contains(":") ? string.Empty : parsedInputValues[1];
        }

        private static void DeleteTable(StatTable table) {
            if (GetTable(table.Name) == null)
                return;

            Tables.Remove(table);
        }

        private static void ModifyStat(string tableName, int statLineId, string statName) {
            StatTable selectedTable = Tables.SingleOrDefault(table => table.Name.Equals(tableName));
            if (selectedTable == null)
                return;

            StatLine selectedLine = selectedTable.StatisticLines.OrderBy(line => line.Creation).ToList()[statLineId];
            if (selectedLine == null)
                return;

            Stat selectedStat = selectedLine.Statistics.SingleOrDefault(stat => stat.Name.Equals(statName));
            if (selectedStat == null)
                return;
        }

        private static void ViewTable(StatTable table) { }

        private static StatTable GetTable(string tableName) {
            return Tables.SingleOrDefault(table => table.Name.Equals(tableName));
        }

        #region EVENTS

        public event EventHandler<TableDeletedEventArgs> TableDeleted;

        private void OnTableDeleted(object sender, TableDeletedEventArgs args) {
            if (TableDeleted == null)
                return;

            TableDeleted.Invoke(sender, args);
        }

        #endregion
    }
}
