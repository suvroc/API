using AnyStatus.API;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Additional
{
    [DisplayName("BC.HTTP Health Check")]
    [DisplayColumn("Health Checks")]
    [Description("HTTP monitoring enables you to test the availability of a web page.")]
    public class BcHttpStatus : Widget, IHealthCheck, ISchedulable, IWebPage
    {
        private const string Category = "HTTP";

        public BcHttpStatus()
        {
        }

        [Required]
        [DisplayName("URL")]
        [Category(Category)]
        public string Url { get; set; }

        [Browsable(false)]
        string IWebPage.URL => Url; //backward compatibility

        [Category(Category)]
        [DisplayName("Is HealthCheck")]
        public bool IsHealthCheck { get; set; }

        //[Category(Category)]
        //[DisplayName("Client Certificate Password")]
        //public string CertificatePassword { get; set; }
    }
}