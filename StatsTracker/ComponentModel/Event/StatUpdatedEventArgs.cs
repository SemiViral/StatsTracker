using System;
using StatsTracker.Model;

namespace StatsTracker.ComponentModel.Event {
    public class StatUpdatedEventArgs {
        #region MEMBERS

        public Stat Value { get; }
        public DateTime UpdateTime { get; }

        #endregion

        public StatUpdatedEventArgs(Stat updatedStat) {
            Value = updatedStat;
            UpdateTime = DateTime.Now;
        }
    }
}
