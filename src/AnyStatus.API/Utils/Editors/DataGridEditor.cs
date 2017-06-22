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
            var panel = new StackPanel();

            //var toolbar = new ToolBar();
            //var addRowBtn = new Button() { Content = "Add" };
            //var deleteRowBtn = new Button() { Content = "Delete" };
            //toolbar.Items.Add(addRowBtn);
            //toolbar.Items.Add(deleteRowBtn);

            var grid = new DataGrid()
            {
                MaxHeight = 400,
                CanUserAddRows = true,
                CanUserReorderColumns = false,
                CanUserDeleteRows = true,
                CanUserSortColumns = false,
                RowHeaderWidth = 20
            };

            //panel.Children.Add(toolbar);
            panel.Children.Add(grid);

            var button = new DropDownButton()
            {
                Content = "(Collection)",
                DropDownContent = panel,
                IsTabStop = true,
                MinHeight = 22,
                SnapsToDevicePixels = true,
                Background = Brushes.White,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(2, 0, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };

            var _binding = new Binding("Value")
            {
                Source = propertyItem,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
                Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay
            };

            BindingOperations.SetBinding(grid, ItemsControl.ItemsSourceProperty, _binding);

            return button;
        }
    }

}
