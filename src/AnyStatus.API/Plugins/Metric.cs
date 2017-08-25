using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    public abstract class Metric : Plugin
    {
        private object _value;

        [Browsable(false)]
        [ExcludeFromCodeCoverage]
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
