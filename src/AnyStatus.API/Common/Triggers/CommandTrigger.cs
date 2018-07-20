using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [DisplayName("Run")]
    public class CommandTrigger : StateTrigger
    {
        [Required]
        [PropertyOrder(10)]
        [DisplayName("File Name")]
        [Description("")]
        [Editor(typeof(FileEditor), typeof(FileEditor))]
        public string FileName { get; set; }

        [PropertyOrder(11)]
        public string Arguments { get; set; }

        [PropertyOrder(12)]
        [DisplayName("Working Directory")]
        [Editor(typeof(FolderEditor), typeof(FolderEditor))]
        public string WorkingDirectory { get; set; }
    }
}
