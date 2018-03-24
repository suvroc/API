using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public class SaveFileDialog : FileDialog
    {
        public SaveFileDialog(string filter) : base(filter) { }
    }
}