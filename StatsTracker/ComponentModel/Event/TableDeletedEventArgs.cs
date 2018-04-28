using StatsTracker.Model;

namespace StatsTracker.ComponentModel.Event {
    public class TableDeletedEventArgs {
        #region MEMBERS

        public StatTable Table { get; }

        #endregion

        public TableDeletedEventArgs(StatTable table) {
            Table = table;
        }
    }
}
