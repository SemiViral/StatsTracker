using System;
using System.Collections.Generic;
using System.Linq;

namespace StatsTracker.Model {
    public class StatTable {
        #region MEMBERS

        public string Name { get; set; }
        public DateTime Creation { get; }
        public List<StatLine> StatisticLines { get; set; }

        #endregion

        public StatTable(string name) {
            Creation = DateTime.Now;

            Name = name;
        }
    }
}
