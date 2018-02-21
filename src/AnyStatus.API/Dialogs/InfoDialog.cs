using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    public class InfoDialog : Dialog
    {
        [ExcludeFromCodeCoverage]
        public InfoDialog(string message, string title) : base(message, title)
        {
        }
    }
}