using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    public class ErrorDialog : Dialog
    {
        [ExcludeFromCodeCoverage]
        public ErrorDialog(string message, string title) : base(message, title)
        {
        }
    }
}