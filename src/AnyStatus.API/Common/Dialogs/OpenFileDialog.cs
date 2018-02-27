using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    public class OpenFileDialog : FileDialog
    {
        [ExcludeFromCodeCoverage]
        public OpenFileDialog(string filter) : base(string.Empty, string.Empty, filter)
        {
            Filter = filter;
        }
    }
}