using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public class InfoDialog : Dialog
    {
        public InfoDialog(string message) : base(message)
        {
            Button = DialogButton.Ok;
            Icon = DialogIcon.Information;
        }

        public InfoDialog(string message, string title) : base(message, title)
        {
            Button = DialogButton.Ok;
            Icon = DialogIcon.Information;
        }
    }
}