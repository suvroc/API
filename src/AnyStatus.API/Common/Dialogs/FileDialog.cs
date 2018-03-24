using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public abstract class FileDialog : Dialog
    {
        public FileDialog(string filter) : base(string.Empty, string.Empty)
        {
            Filter = filter;
        }

        public string Filter { get; set; }

        public string FileName { get; set; }
    }
}