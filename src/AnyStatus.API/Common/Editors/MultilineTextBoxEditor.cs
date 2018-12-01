using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace AnyStatus.API
{
    public class MultilineTextBoxEditor : ITypeEditor
    {
        [ExcludeFromCodeCoverage]
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            var bindingMode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;

            return CreateElement(propertyItem, bindingMode);
        }

        public static FrameworkElement CreateElement(object bindingSource, BindingMode bindingMode)
        {
            var panel = new StackPanel();

            var button = new DropDownButton
            {
                Content = "(Edit)",
                DropDownContent = panel,
                IsTabStop = true,
                MinHeight = 22,
                SnapsToDevicePixels = true,
                Background = Brushes.White,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(2, 0, 0, 0),
                HorizontalContentAlignment = HorizontalAlignment.Left,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
            };

            var textBox = new TextBox
            {
                MinWidth = 350,
                MinHeight = 200,
                AcceptsReturn = true,
                TextWrapping = TextWrapping.NoWrap,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
            };

            panel.Children.Add(textBox);

            var binding = new Binding("Value")
            {
                Mode = bindingMode,
                Source = bindingSource,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
            };

            BindingOperations.SetBinding(textBox, TextBox.TextProperty, binding);

            return button;
        }
    }
}