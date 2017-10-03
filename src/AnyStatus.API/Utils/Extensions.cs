using System;
using System.ComponentModel;
using System.Reflection;

namespace AnyStatus.API.Utils
{
    public static class Extensions
    {
        public static void SetAttributeFieldValue<T>(this object obj, string propertyName, string fieldName, object value) where T : Attribute
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException(nameof(fieldName));

            var desc = TypeDescriptor.GetProperties(obj.GetType())[propertyName];
            var attr = (T)desc.Attributes[typeof(T)];
            var field = attr.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

            field?.SetValue(attr, value);
        }
    }
}
