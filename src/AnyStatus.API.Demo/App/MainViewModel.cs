namespace AnyStatus.API.Demo
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Widget = new MyWidget();
        }

        public Widget Widget { get; set; }
    }
}
