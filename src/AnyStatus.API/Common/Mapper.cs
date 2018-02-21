using System;

namespace AnyStatus.API.Utils
{
    public static class Mapper
    {
        /// <summary>
        /// Copy object properties by name.
        /// </summary>
        public static void MapTo<Source, Target>(this Source source, Target target)
        {
            var sourceType = typeof(Source);
            var targetType = typeof(Target);

            try
            {
                foreach (var sourceProperty in sourceType.GetProperties())
                {
                    var targetProperty = targetType.GetProperty(sourceProperty.Name);

                    if (targetProperty != null && 
                        targetProperty.PropertyType == sourceProperty.PropertyType)
                    {
                        targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while mapping {sourceType.FullName} to {targetType.FullName}", ex);
            }
        }
    }
}