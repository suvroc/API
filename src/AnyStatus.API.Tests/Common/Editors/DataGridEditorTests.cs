using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Data;

namespace AnyStatus.API.Tests.Editors
{
    [TestClass]
    public class DataGridEditorTests
    {
        [TestMethod]
        public void DataGridEditor_Should_CreateElement_When_ResolveEditor()
        {
            var source = new object();

            var element = DataGridEditor.CreateElement(source, BindingMode.Default);

            Assert.IsNotNull(element);
        }
    }
}