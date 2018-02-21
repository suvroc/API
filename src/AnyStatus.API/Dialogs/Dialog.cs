using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    public abstract class Dialog : IDialog
    {
        [ExcludeFromCodeCoverage]
        public Dialog(string message, string title)
        {
            Title = title;
            Message = message;
        }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}