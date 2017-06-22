using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace AnyStatus.API
{
    public class FileEditor : ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            var grid = new Grid();

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            var textBox = new TextBox()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch
            };

            var binding = new Binding("Value")
            {
                Source = propertyItem,
                Mode = BindingMode.TwoWay
            };

            BindingOperations.SetBinding(textBox, TextBox.TextProperty, binding);

            var button = new Button()
            {
                Content = "...",
                Tag = propertyItem
            };

            button.Click += Button_Click;

            Grid.SetColumn(button, 1);

            grid.Children.Add(textBox);
            grid.Children.Add(button);

            return grid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
                return;

            var item = button.Tag as PropertyItem;

            if (item == null)
                return;

            var openFileDialog = new OpenFileDialog();

            openFileDialog.ShowDialog();

            item.Value = openFileDialog.FileName;
        }
    }

}
