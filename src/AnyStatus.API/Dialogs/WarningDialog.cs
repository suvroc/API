using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    public class WarningDialog : Dialog
    {
        [ExcludeFromCodeCoverage]
        public WarningDialog(string message, string title) : base(message, title)
        {
        }
    }
}