using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace AnyStatus.API
{
    public abstract class Metric : Widget
    {
        private object _value;

        [XmlIgnore]
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
