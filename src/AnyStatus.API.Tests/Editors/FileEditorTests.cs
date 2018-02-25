using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace AnyStatus.API.Tests.Editors
{
    [TestClass]
    public class FileEditorTests
    {
        [TestMethod]
        public void FileEditor_Should_CreateElement_When_ResolveEditor()
        {
            var source = new object();
            var editor = new FileEditor();

            var element = editor.CreateElement(source);

            Assert.IsNotNull(element);
        }

        [TestMethod]
        public void FileEditor_Button_Should_OpenFileDialog()
        {
            var source = new object();
            var editor = new FileEditor();

            var element = editor.CreateElement(source);

            var grid = element as Grid;

            foreach (var child in grid.Children)
            {
                if (child is Button button)
                {
                    button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent, button));
                }
            }
        }
    }
}