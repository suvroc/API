using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Controls;

namespace AnyStatus.API.Tests.Editors
{
    [TestClass]
    public class PasswordEditorTests
    {
        [TestMethod]
        public void PasswordEditor_Should_CreateElement_When_ResolveEditor()
        {
            void set(string v) { };
            string get() => string.Empty;

            var element = new PasswordEditor(get, set).CreateElement();

            Assert.IsNotNull(element);
            Assert.IsInstanceOfType(element, typeof(PasswordBox));
        }

        [TestMethod]
        public void PasswordEditor_Should_UpdatePassword_When_LostFocus()
        {
            var pws = "pws1";

            string get() => pws;
            void set(string value) => pws = value;

            var passwordBox = new PasswordEditor(get, set).CreateElement() as PasswordBox;

            passwordBox.Password = "pws2";

            passwordBox.RaiseEvent(new RoutedEventArgs(UIElement.LostFocusEvent, passwordBox));

            Assert.AreEqual(passwordBox.Password, pws);
        }
    }
}