using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.Repo
{
    using System.Collections.Generic;
    using IRepo;
    using AutoMapper;

    /// <summary>
    /// Implementation of wrapper service for Auto-mapper which is mainly designed for handling mapping of collections.
    /// </summary>
    public class MappingService : IMappingService
    {
        /// <summary>
        /// Instance of service that is used for automatic mappings.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingService"/> class.
        /// </summary>    
        /// <param name="mapper">Instance of AutoMapper.</param>    
        public MappingService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// Execute a mapping from the source object to a new destination object. The source type is inferred from the source object.
        /// </summary>
        /// <typeparam name="TDestination">Destination type to create.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>
        /// Mapped destination object.
        /// </returns>
        public TDestination Map<TDestination>(object source)
        {
            return this.mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// Execute a mapping from the source object to a new destination object.
        /// </summary>
        /// <typeparam name="TSource">Source type to use, regardless of the runtime type.</typeparam>
        /// <typeparam name="TDestination">Destination type to create.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>
        /// Mapped destination object.
        /// </returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return this.mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Execute a mapping from the source collection to a new destination collection. The source type is inferred from the source object.
        /// </summary>
        /// <typeparam name="TDestination">Destination type to create.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>
        /// Mapped destination collection.
        /// </returns>
        public List<TDestination> MapList<TDestination>(List<object> source)
        {
            List<TDestination> result = new List<TDestination>();

            if (source != null)
            {
                foreach (var item in source)
                {
                    result.Add(this.mapper.Map<TDestination>(item));
                }
            }

            return result;
        }

        /// <summary>
        /// Execute a mapping from the source collection to a new destination collection.
        /// </summary>
        /// <typeparam name="TSource">Source type to use, regardless of the runtime type.</typeparam>
        /// <typeparam name="TDestination">Destination type to create.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>
        /// Mapped destination collection.
        /// </returns>
        public List<TDestination> MapList<TSource, TDestination>(List<TSource> source)
        {
            List<TDestination> result = new List<TDestination>();

            if (source != null)
            {
                foreach (var item in source)
                {
                    result.Add(this.mapper.Map<TSource, TDestination>(item));
                }
            }

            return result;
        }
    }
}
