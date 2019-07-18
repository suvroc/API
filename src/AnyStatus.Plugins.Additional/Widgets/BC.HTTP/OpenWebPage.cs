using AnyStatus.API;

namespace AnyStatus.Plugins.Additional
{
    public class BcOpenHttpWebPage : OpenWebPage<BcHttpStatus>
    {
        public BcOpenHttpWebPage(IProcessStarter ps) : base(ps)
        {
        }
    }
}