namespace AnyStatus.API
{
    public class OpenFileDialog : FileDialog
    {
        public OpenFileDialog(string filter) : base(string.Empty, string.Empty, filter)
        {
            Filter = filter;
        }
    }
}