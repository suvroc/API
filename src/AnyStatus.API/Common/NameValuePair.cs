using System;
using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [Obsolete("Make sure this is used")]
    [ExcludeFromCodeCoverage]
    public class NameValuePair
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}