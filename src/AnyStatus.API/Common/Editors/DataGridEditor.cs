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
    public class DataGridEditor : ITypeEditor
    {
        [ExcludeFromCodeCoverage]
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            var bindingMode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;

            return CreateElement(propertyItem, bindingMode);
        }

        public static FrameworkElement CreateElement(object bindingSource, BindingMode bindingMode)
        {
            var grid = CreateDataGrid();

            var panel = new StackPanel();

            panel.Children.Add(grid);

            var button = CreateDropDownButton(panel);

            var binding = new Binding("Value")
            {
                Mode = bindingMode,
                Source = bindingSource,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
            };

            BindingOperations.SetBinding(grid, ItemsControl.ItemsSourceProperty, binding);

            return button;
        }

        private static DataGrid CreateDataGrid()
        {
            return new DataGrid
            {
                MaxHeight = 400,
                CanUserAddRows = true,
                CanUserReorderColumns = false,
                CanUserDeleteRows = true,
                CanUserSortColumns = false,
                RowHeaderWidth = 20
            };
        }

        private static DropDownButton CreateDropDownButton(StackPanel panel)
        {
            return new DropDownButton
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
        }
    }
}