using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace AnyStatus.API
{
    public class DataGridEditor : ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            var grid = new DataGrid
            {
                MaxHeight = 400,
                CanUserAddRows = true,
                CanUserReorderColumns = false,
                CanUserDeleteRows = true,
                CanUserSortColumns = false,
                RowHeaderWidth = 20
            };

            var panel = new StackPanel();

            panel.Children.Add(grid);

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

            var binding = new Binding("Value")
            {
                Source = propertyItem,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
                Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay
            };

            BindingOperations.SetBinding(grid, ItemsControl.ItemsSourceProperty, binding);

            return button;
        }
    }

}
