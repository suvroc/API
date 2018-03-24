using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public class ConfirmationDialog : Dialog
    {
        public ConfirmationDialog(string message) : base(message) { }

        public ConfirmationDialog(string message, string title) : base(message, title) { }
    }
}