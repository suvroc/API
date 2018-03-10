using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public class WarningDialog : Dialog
    {
        public WarningDialog(string message) : base(message) { }

        public WarningDialog(string message, string title) : base(message, title) { }
    }
}