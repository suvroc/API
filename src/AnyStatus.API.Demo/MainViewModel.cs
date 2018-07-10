namespace AnyStatus.API.Demo
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Widget = new Folder();
        }

        public Widget Widget { get; set; }
    }
}
