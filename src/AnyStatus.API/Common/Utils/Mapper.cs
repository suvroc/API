using System;

namespace AnyStatus.API.Utils
{
    public static class Mapper
    {
        /// <summary>
        /// Copies all properties with similar type and name to target object instance.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="source">The source instance.</param>
        /// <param name="target">The target instance.</param>
        public static void CopyTo<TSource, TTarget>(this TSource source, TTarget target)
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);

            try
            {
                foreach (var sourceProperty in sourceType.GetProperties())
                {
                    var targetProperty = targetType.GetProperty(sourceProperty.Name);

                    if (targetProperty != null && targetProperty.PropertyType == sourceProperty.PropertyType)
                    {
                        targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error mapping {sourceType.FullName} to {targetType.FullName}", ex);
            }
        }

        /// <summary>
        /// Copies all properties with similar type and name to target object instance.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="source">The source instance.</param>
        /// <param name="target">The target instance.</param>
        [Obsolete("Use CopyTo instead.")]
        public static void MapTo<TSource, TTarget>(this TSource source, TTarget target)
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);

            try
            {
                foreach (var sourceProperty in sourceType.GetProperties())
                {
                    var targetProperty = targetType.GetProperty(sourceProperty.Name);

                    if (targetProperty != null && targetProperty.PropertyType == sourceProperty.PropertyType)
                    {
                        targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error mapping {sourceType.FullName} to {targetType.FullName}", ex);
            }
        }
    }
}