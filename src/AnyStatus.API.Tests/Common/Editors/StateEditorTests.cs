using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace AnyStatus.API.Tests.Editors
{
    [TestClass]
    public class StateEditorTests
    {
        [TestMethod]
        public void CreateStateEditorTest()
        {
            var editor = new StateEditor();

            var element = editor.CreateElement(new object(), BindingMode.Default);

            Assert.IsNotNull(element);

            Assert.IsTrue(BindingOperations.IsDataBound(element, Selector.SelectedValueProperty));
        }
    }
}
