using System;
using System.Collections.Generic;
using System.Text;
using StatsTracker.Model;

namespace StatsTracker.ComponentModel.Event
{
    public class TableDeletedEventArgs {
        public StatTable Table { get; }

        public TableDeletedEventArgs(StatTable table) {
            Table = table;
        }
    }
}
