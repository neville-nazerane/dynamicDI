using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manyservices
{

    public enum ModelNameSource { Route, Query }

    public interface IModelMetadata 
    {
        ModelNameSource Source { get; }
    }

    public class ModelMetadata : IModelMetadata
    {
        public ModelNameSource Source { get; }

        public ModelMetadata(ModelNameSource source)
        {
            Source = source;
        }

        public ModelMetadata()
        {

        }

    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ModelServiceAttribute : Attribute, IModelMetadata
    {
        public ModelNameSource Source { get; set; }

        public ModelServiceAttribute(ModelNameSource source)
        {
            Source = source;
        }

        public ModelServiceAttribute()
        {

        }

    }

    public static class ConventionExtension
    {

        public static IEndpointConventionBuilder WithModelService(this IEndpointConventionBuilder builder, 
                                                                  ModelNameSource source = ModelNameSource.Route)
        {
            builder.Add(b => b.Metadata.Add(new ModelMetadata(source)));
            return builder;
        }

    }
}
