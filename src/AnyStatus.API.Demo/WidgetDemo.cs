using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AnyStatus.API.Demo
{
    public class MyWidget : Widget, IHealthCheck
    {
        [DisplayName("My Property")]
        [Category("My Category")]
        public string MyProperty { get; set; }

        [Browsable(false)] //Use [Browsable] attribute to show or hide a property.
        [XmlIgnore] // Use [XmlIgnore] to ignore a property when saving. All properties are saved by default.
        public string MyHiddenProperty { get; set; }
    }

    public class MyWidget_HealthCheck : ICheckHealth<MyWidget>
    {
        public Task Handle(HealthCheckRequest<MyWidget> request, CancellationToken cancellationToken)
        {
            request.DataContext.State = State.Ok; // change widget status.

            return Task.CompletedTask;
        }
    }
}