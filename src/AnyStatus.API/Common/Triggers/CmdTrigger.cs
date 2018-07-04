using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [DisplayName("Run")]
    public class CmdTrigger : StateTrigger, IRequest<TriggerResult>
    {
        [Required]
        [Category("Run")]
        [PropertyOrder(0)]
        [DisplayName("File Name")]
        public string FileName { get; set; }

        [Category("Run")]
        [PropertyOrder(1)]
        public string Arguments { get; set; }

        [Category("Run")]
        [PropertyOrder(2)]
        [DisplayName("Working Directory")]
        public string WorkingDirectory { get; set; }
    }
}
