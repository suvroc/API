namespace AnyStatus.API
{
    public class OpenFileDialog : FileDialog
    {
        public OpenFileDialog(string message, string title) : base(message, title)
        {
        }

        public OpenFileDialog(string message, string title, string filter) : base(message, title, filter)
        {
        }
    }
}