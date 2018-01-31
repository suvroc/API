namespace AnyStatus.API
{
    public abstract class FileDialog : Dialog
    {
        public string Filter { get; set; }

        public string FileName { get; set; }
    }
}