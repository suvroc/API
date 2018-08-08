using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [DisplayName("Batch Script")]
    public class BatchScriptTrigger : StateTrigger
    {
        [Required]
        [PropertyOrder(10)]
        [DisplayName("File Name")]
        [Description("Path of the cmd or bat script to execute. Should be fully qualified path or relative to the default working directory.")]
        [Editor(typeof(FileEditor), typeof(FileEditor))]
        public string FileName { get; set; }

        [PropertyOrder(11)]
        [Description("Arguments passed to the cmd or bat script.")]
        public string Arguments { get; set; }

        [PropertyOrder(12)]
        [DisplayName("Working Directory")]
        [Editor(typeof(FolderEditor), typeof(FolderEditor))]
        public string WorkingDirectory { get; set; }
    }
}
