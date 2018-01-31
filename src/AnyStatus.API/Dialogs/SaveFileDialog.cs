namespace AnyStatus.API
{
    public class SaveFileDialog : FileDialog
    {
        public SaveFileDialog(string filter) : base(string.Empty, string.Empty, filter)
        {
            Filter = filter;
        }
    }
}