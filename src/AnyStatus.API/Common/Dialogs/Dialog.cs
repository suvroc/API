using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public abstract class Dialog : IDialog
    {
        protected Dialog(string message, string title = "AnyStatus")
        {
            Title = title;
            Message = message;
        }

        public string Title { get; set; }

        public string Message { get; set; }

        public DialogIcon Icon { get; set; }

        public DialogButton Button { get; set; }
    }
}