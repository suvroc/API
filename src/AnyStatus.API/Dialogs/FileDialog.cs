namespace AnyStatus.API
{
    public abstract class FileDialog : Dialog
    {
        public FileDialog(string message, string title) : base(message, title)
        {
        }

        public FileDialog(string message, string title, string filter) : base(message, title)
        {
            Filter = filter;
        }

        public string Filter { get; set; }

        public string FileName { get; set; }
    }
}