using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [ExcludeFromCodeCoverage]
    [DisplayName("Run")]
    public class CommandTrigger : StateTrigger
    {
        [Required]
        [PropertyOrder(10)]
        [DisplayName("File Name")]
        [Description("Path of the executable file to run. Should be fully qualified path or relative to the default working directory.")]
        [Editor(typeof(FileEditor), typeof(FileEditor))]
        public string FileName { get; set; }

        [PropertyOrder(11)]
        [Description("Arguments passed to the executable file.")]
        public string Arguments { get; set; }

        [PropertyOrder(12)]
        [DisplayName("Working Directory")]
        [Editor(typeof(FolderEditor), typeof(FolderEditor))]
        public string WorkingDirectory { get; set; }
    }
}
