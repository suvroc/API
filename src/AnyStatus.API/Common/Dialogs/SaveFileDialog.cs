using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    public class SaveFileDialog : FileDialog
    {
        [ExcludeFromCodeCoverage]
        public SaveFileDialog(string filter) : base(string.Empty, string.Empty, filter)
        {
            Filter = filter;
        }
    }
}