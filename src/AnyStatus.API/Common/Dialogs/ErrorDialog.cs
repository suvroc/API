using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public class ErrorDialog : Dialog
    {
        public ErrorDialog(string message) : base(message)
        {
            Icon = DialogIcon.Error;
            Button = DialogButton.Ok;
        }

        public ErrorDialog(string message, string title) : base(message, title)
        {
            Icon = DialogIcon.Error;
            Button = DialogButton.Ok;
        }
    }
}