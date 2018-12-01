using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace AnyStatus.API
{
    public class StateEditor : ITypeEditor
    {
        private static readonly Lazy<List<KeyValuePair<string, int>>> States = new Lazy<List<KeyValuePair<string, int>>>(() =>
        {
            var states = new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>("Any", -1) };

            states.AddRange(State.GetAll().Select(state => new KeyValuePair<string, int>(state.Metadata.DisplayName, state.Value)));

            return states;
        });

        [ExcludeFromCodeCoverage]
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            return CreateElement(propertyItem, propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay);
        }

        public FrameworkElement CreateElement(object bindingSource, BindingMode bindingMode)
        {
            var comboBox = new ComboBox
            {
                ItemsSource = States.Value,
                DisplayMemberPath = "Key",
                SelectedValuePath = "Value",
            };

            var binding = new Binding("Value")
            {
                Source = bindingSource,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true,
                Mode = bindingMode
            };

            BindingOperations.SetBinding(comboBox, Selector.SelectedValueProperty, binding);

            return comboBox;
        }
    }
}
