using System;
using System.Collections.Generic;
using System.Linq;

namespace AnyStatus.API
{
    /// <summary>
    /// Synchronize changes between two collections.
    /// </summary>
    /// <typeparam name="TSource">The source collection (not changed).</typeparam>
    /// <typeparam name="TDestination">The destination collection.</typeparam>
    public class CollectionSynchronizer<TSource, TDestination>
    {
        public Func<TSource, TDestination, bool> Compare { get; set; }
        public Action<TDestination> RemoveAction { get; set; }
        public Action<TSource> AddAction { get; set; }
        public Action<TSource, TDestination> UpdateAction { get; set; }

        /// <summary>
        /// Synchronize changes from source to destination collection.
        /// Source collection is not changed.
        /// </summary>
        public void Synchronize(ICollection<TSource> sourceItems, ICollection<TDestination> destinationItems)
        {
            RemoveItems(sourceItems, destinationItems);

            AddOrUpdateItems(sourceItems, destinationItems);
        }

        /// <summary>
        /// Remove items from destination collection.
        /// </summary>
        private void RemoveItems(ICollection<TSource> sourceCollection, ICollection<TDestination> destinationCollection)
        {
            foreach (var destinationItem in destinationCollection.ToArray())
            {
                var sourceItem = sourceCollection.FirstOrDefault(item => Compare(item, destinationItem));

                if (sourceItem == null)
                {
                    RemoveAction(destinationItem);
                }
            }
        }

        /// <summary>
        /// Add or update item in destination collection.
        /// </summary>
        /// <param name="sourceCollection"></param>
        /// <param name="destinationCollection"></param>
        private void AddOrUpdateItems(ICollection<TSource> sourceCollection, ICollection<TDestination> destinationCollection)
        {
            var destinationList = destinationCollection.ToList();

            foreach (var sourceItem in sourceCollection)
            {
                var destinationItem = destinationList.FirstOrDefault(item => Compare(sourceItem, item));

                if (destinationItem == null)
                {
                    AddAction(sourceItem);
                }
                else
                {
                    UpdateAction(sourceItem, destinationItem);
                }
            }
        }
    }
}
