using System;
using StatsTracker.ComponentModel.Event;

namespace StatsTracker.Model {
    public abstract class Stat {
        #region MEMBERS

        public int Ordering { get; }
        public string Name { get; }
        protected object Value;

        #endregion

        protected Stat(int ordering, string name, object value) {
            Ordering = ordering;
            Name = name;
            Value = value;
        }

        #region EVENTS

        public event EventHandler<StatUpdatedEventArgs> Updated;

        protected void OnUpdated(object sender, StatUpdatedEventArgs args) {
            if (Updated == null)
                return;

            Updated.Invoke(sender, args);
        }

        #endregion
    }

    public class Stat<T> : Stat {
        #region MEMBERS

        /// <summary>
        ///     Value of statistic
        /// </summary>
        public new T Value {
            get => (T)base.Value;
            protected set => base.Value = value;
        }

        #endregion

        public Stat(int ordering, string name, T value) : base(ordering, name, value) {
            Value = value;
        }

        /// <summary>
        ///     Safe updates the Value member
        /// </summary>
        /// <param name="newValue"></param>
        internal void UpdateValue(T newValue) {
            if (Value.Equals(newValue))
                throw new ArgumentException("Value already equal to newly assigned value.");

            Value = newValue;

            OnUpdated(this, new StatUpdatedEventArgs(this));
        }
    }
}
