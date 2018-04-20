using System;
using System.Collections.Generic;
using System.Linq;

namespace StatsTracker.Model {
    public class StatTable {
        #region MEMBERS

        public string Name { get; set; }
        public DateTime Creation { get; }
        public List<StatLine> StatisticLines { get; }

        #endregion

        public StatTable(string name, IEnumerable<StatLine> statLines) {
            Creation = DateTime.Now;

            Name = name;
            StatisticLines = statLines.ToList();
        }
    }
}
