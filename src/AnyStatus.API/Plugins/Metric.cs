using System.ComponentModel;

namespace AnyStatus.API
{
    public abstract class Metric : Plugin
    {
        private object _value;

        [Browsable(false)]
        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
    }
}
