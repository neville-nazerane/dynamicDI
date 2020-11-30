using manyservices.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manyservices
{
    public class ServiceSettingMiddleware
    {
        private readonly RequestDelegate _next;

        public ServiceSettingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ServiceForModelProvider provider)
        {
            var endpoint = context.GetEndpoint();
            var meta = endpoint.Metadata.GetMetadata<IModelMetadata>();
            if (meta is not null)
            {
                switch (meta.Source)
                {
                    case ModelNameSource.Route:
                        provider.SetService(context.Request.RouteValues["model"].ToString());
                        break;
                    case ModelNameSource.Query:
                        provider.SetService(context.Request.Query["model"].ToString());
                        break;
                }
            }
            await _next(context);
        }

    }
}
