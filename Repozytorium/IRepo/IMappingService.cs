using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.IRepo
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines service which provides mapping operation between objects.
    /// </summary>
    public interface IMappingService
    {
        /// <summary>
        /// Execute a mapping from the source object to a new destination object. The source type is inferred from the source object.
        /// </summary>
        /// <typeparam name="TDestination">Destination type to create.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>Mapped destination object.</returns>
        TDestination Map<TDestination>(object source);

        /// <summary>
        /// Execute a mapping from the source object to a new destination object.
        /// </summary>
        /// <typeparam name="TSource">Source type to use, regardless of the runtime type.</typeparam>
        /// <typeparam name="TDestination">Destination type to create.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>Mapped destination object.</returns>
        TDestination Map<TSource, TDestination>(TSource source);

        /// <summary>
        /// Execute a mapping from the source collection to a new destination collection. The source type is inferred from the source object.
        /// </summary>
        /// <typeparam name="TDestination">Destination type to create.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>Mapped destination collection.</returns>
        List<TDestination> MapList<TDestination>(List<object> source);

        /// <summary>
        /// Execute a mapping from the source collection to a new destination collection.
        /// </summary>
        /// <typeparam name="TSource">Source type to use, regardless of the runtime type.</typeparam>
        /// <typeparam name="TDestination">Destination type to create.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>Mapped destination collection.</returns>
        List<TDestination> MapList<TSource, TDestination>(List<TSource> source);
    }
}
