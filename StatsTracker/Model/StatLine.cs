using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using StatsTracker.ComponentModel.Event;

namespace StatsTracker.Model {
    public class StatLine {
        #region MEMBERS

        public DateTime Creation { get; }
        public DateTime Updated { get; set; }

        public ReadOnlyCollection<Stat> Statistics { get; }

        #endregion

        public StatLine(IList<Stat> statisticArray) {
            foreach (Stat stat in statisticArray)
                stat.Updated += OnStatUpdated;

            Statistics = new ReadOnlyCollection<Stat>(statisticArray);

            Creation = DateTime.Now;
            Updated = Creation;

            StatUpdated += StatUpdatedNotified;
        }

        #region OVERRIDE METHODS

        public override string ToString() {
            return string.Join(" ", Statistics.OrderBy(stat => stat.Ordering));
        }

        #endregion

        #region EVENTS

        public event EventHandler<StatUpdatedEventArgs> StatUpdated;

        private void OnStatUpdated(object sender, StatUpdatedEventArgs args) {
            if (StatUpdated == null)
                return;

            StatUpdated.Invoke(sender, args);
        }

        private void StatUpdatedNotified(object sender, StatUpdatedEventArgs args) {
            Updated = args.UpdateTime;
        }

        #endregion
    }
}
