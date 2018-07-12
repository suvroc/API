namespace AnyStatus.API.Demo
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Widget = new WidgetDemo();
        }

        public Widget Widget { get; set; }
    }
}
