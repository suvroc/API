namespace AnyStatus.API.Tests.Widgets.Features
{
    public class TestWidget : Widget,
        IMetricValue, IHealthCheck, IInitializable, IStartable, IStoppable, IRestartable, IWebPage
    {
        public object Value { get; set; }

        public string URL { get; set; } = "https://www.anystat.us";
    }
}
