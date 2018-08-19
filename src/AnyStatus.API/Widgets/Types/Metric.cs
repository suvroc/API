using System.ComponentModel;
using System.Xml.Serialization;

namespace AnyStatus.API
{
    public abstract class Metric : Widget, IMetricValue
    {
        private object _value;
        private string _symbol;

        [XmlIgnore]
        [Browsable(false)]
        public object Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        [XmlIgnore]
        [Browsable(false)]
        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                OnPropertyChanged();
            }
        }
    }
}