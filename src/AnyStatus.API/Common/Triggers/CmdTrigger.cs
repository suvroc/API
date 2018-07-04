using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [DisplayName("Run")]
    public class CmdTrigger : StateTrigger, IRequest
    {
        [PropertyOrder(1)]
        [Category("Run")]
        [DisplayName("File Name")]
        public string FileName { get; set; }

        [PropertyOrder(2)]
        [Category("Run")]
        public string Arguments { get; set; }

        [PropertyOrder(3)]
        [Category("Run")]
        [DisplayName("Working Directory")]
        public string WorkingDirectory { get; set; }
    }
}
