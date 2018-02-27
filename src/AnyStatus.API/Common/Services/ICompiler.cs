using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AnyStatus.API
{
    public interface ICompiler
    {
        Assembly Compile(FileInfo sourceFile, List<string> references, bool treatWarningsAsErrors);
    }
}