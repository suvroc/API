namespace AnyStatus.API
{
    public interface IDialog
    {
        string Title { get; set; }

        string Message { get; set; }

        DialogIcon Icon { get; set; }

        DialogButton Button { get; set; }
    }
}