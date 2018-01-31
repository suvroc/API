namespace AnyStatus.API
{
    public class SaveFileDialog : FileDialog
    {
        public SaveFileDialog(string message, string title) : base(message, title)
        {
        }

        public SaveFileDialog(string message, string title, string filter) : base(message, title, filter)
        {
        }
    }
}