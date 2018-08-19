using System.ComponentModel;
using System.Xml.Serialization;

namespace AnyStatus.API
{
    public abstract class Metric : Widget, IMetricValue
    {
        private object _value;

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

        public string Symbol { get; set; }
    }
}