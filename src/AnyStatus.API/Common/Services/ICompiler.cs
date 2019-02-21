using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AnyStatus.API
{
    public interface ICompiler
    {
        /// <summary>
        /// Compile a C# or VB.NET file at run-time.
        /// </summary>
        /// <param name="sourceFile">The source code file path.</param>
        /// <param name="references"></param>
        /// <param name="treatWarningsAsErrors"></param>
        /// <returns></returns>
        Assembly Compile(FileInfo sourceFile, List<string> references, bool treatWarningsAsErrors);
    }
}