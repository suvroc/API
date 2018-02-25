using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    public class ConfirmationDialog : Dialog
    {
        [ExcludeFromCodeCoverage]
        public ConfirmationDialog(string message, string title) : base(message, title)
        {
        }
    }
}