using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public class ConfirmationDialog : Dialog
    {
        public ConfirmationDialog(string message) : base(message)
        {
            Icon = DialogIcon.Question;
            Button = DialogButton.Yes | DialogButton.No;
        }

        public ConfirmationDialog(string message, string title) : base(message, title)
        {
            Icon = DialogIcon.Question;
            Button = DialogButton.Yes | DialogButton.No;
        }
    }
}