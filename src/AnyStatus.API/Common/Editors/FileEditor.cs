using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace AnyStatus.API
{
    public class FileEditor : ITypeEditor
    {
        [ExcludeFromCodeCoverage]
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            var grid = new Grid();

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var textBox = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalContentAlignment = VerticalAlignment.Center,
                Padding = new Thickness(3),
            };

            var defaultBorderBrush = textBox.BorderBrush;

            textBox.BorderBrush = Brushes.Transparent;
            textBox.MouseEnter += (s, e) => ((TextBox) s).BorderBrush = defaultBorderBrush;
            textBox.MouseLeave += (s, e) => ((TextBox) s).BorderBrush = Brushes.Transparent;

            var binding = new Binding("Value")
            {
                Source = propertyItem,
                Mode = BindingMode.TwoWay
            };

            BindingOperations.SetBinding(textBox, TextBox.TextProperty, binding);

            var button = new Button
            {
                Content = " ... ",
                Tag = propertyItem,
            };

            button.Click += OnButtonClick;

            Grid.SetColumn(button, 1);

            grid.Children.Add(textBox);
            grid.Children.Add(button);

            return grid;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var pi = (PropertyItem)button.Tag;

            pi.Value = GetPath();
        }

        protected virtual string GetPath()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.ShowDialog();

            return openFileDialog.FileName;
        }
    }
}