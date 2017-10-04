using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public class NameValuePair
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
