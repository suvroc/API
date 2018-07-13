using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [DisplayName("Run")]
    public class CmdTrigger : StateTrigger
    {
        [Required]
        [PropertyOrder(10)]
        [DisplayName("File Name")]
        public string FileName { get; set; }

        [PropertyOrder(11)]
        public string Arguments { get; set; }

        [PropertyOrder(12)]
        [DisplayName("Working Directory")]
        public string WorkingDirectory { get; set; }
    }
}
