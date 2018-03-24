using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Data;

namespace AnyStatus.API.Tests.Editors
{
    [TestClass]
    public class MultilineTextBoxEditorTests
    {
        [TestMethod]
        public void MultilineTextBoxEditor_Should_CreateElement_When_ResolveEditor()
        {
            var source = new object();

            var element = MultilineTextBoxEditor.CreateElement(source, BindingMode.Default);

            Assert.IsNotNull(element);
        }
    }
}