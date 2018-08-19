using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System.Xml.Serialization;

namespace AnyStatus.API
{
    public abstract class Sparkline : Metric
    {
        private double _value;
        private const string Category = "Sparkline";

        [Category(Category)]
        public Color Color { get; set; } = Colors.LimeGreen;

        [Category(Category)]
        public int Size { get; set; } = 20;

        [XmlIgnore]
        [Browsable(false)]
        public ObservableCollection<DataPoint> Points { get; } = new ObservableCollection<DataPoint>();

        [XmlIgnore]
        [Browsable(false)]
        public new double Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
    }
}
