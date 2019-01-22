using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace AnyStatus.API
{
    public class PasswordEditor : ITypeEditor
    {
        private PropertyItem _propertyItem;
        private Func<string> _getPassword;
        private Action<string> _setPassword;

        [ExcludeFromCodeCoverage]
        public PasswordEditor()
        {
        }

        public PasswordEditor(Func<string> getPassword, Action<string> setPassword)
        {
            _getPassword = getPassword;
            _setPassword = setPassword;
        }

        [ExcludeFromCodeCoverage]
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            //Workaround. PropertyItem internal ctor can't be used by unit tests

            _propertyItem = propertyItem;

            _getPassword = () => _propertyItem?.Value?.ToString();

            _setPassword = pws =>
            {
                if (_propertyItem != null) _propertyItem.Value = pws;
            };

            return CreateElement();
        }

        public FrameworkElement CreateElement()
        {
            if (_setPassword == null || _getPassword == null)
                throw new InvalidOperationException();

            var passwordBox = new PasswordBox
            {
                Password = _getPassword(),
                BorderThickness = new Thickness(0),
            };

            passwordBox.LostFocus += OnLostFocus;

            return passwordBox;
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender != null && sender is PasswordBox passwordBox && passwordBox.Password != _getPassword())
            {
                _setPassword(passwordBox.Password);
            }

            e.Handled = true;
        }
    }
}