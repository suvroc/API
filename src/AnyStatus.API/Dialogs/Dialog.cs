namespace AnyStatus.API
{
    public abstract class Dialog : IDialog
    {
        public string Title { get; set; }

        public string Message { get; set; }
    }
}