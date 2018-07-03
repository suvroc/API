using System.ComponentModel;

namespace AnyStatus.API.Triggers
{
    public class CmdTrigger : StateTrigger, IRequest
    {
        [Category("Run")]
        [DisplayName("File Name")]
        public string FileName { get; set; }

        [Category("Run")]
        public string Arguments { get; set; }

        [Category("Run")]
        [DisplayName("Working Directory")]
        public string WorkingDirectory { get; set; }
    }
}
