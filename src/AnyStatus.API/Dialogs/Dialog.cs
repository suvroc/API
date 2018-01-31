namespace AnyStatus.API
{
    public abstract class Dialog : IDialog
    {
        public Dialog(string message, string title)
        {
            Title = title;
            Message = message;
        }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}