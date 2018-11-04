using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using POC.EntityFramework.OData.Domain.Entities;

namespace POC.EntityFramework.OData.Infrastructure.Context
{
    /// <summary>
    /// Classe de configuração de odata.
    /// </summary>
    public static class ODataContext
    {
        /// <summary>
        /// Método de configuração de odata na aplicação.
        /// </summary>
        /// <param name="routeBuilder"></param>
        public static void ConfigureOData(IRouteBuilder routeBuilder)
        {
            routeBuilder.DefaultHandler = routeBuilder.ApplicationBuilder.ApplicationServices.GetRequiredService<MvcRouteHandler>();
            routeBuilder.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            routeBuilder.MapODataServiceRoute("ODataRoute", "odata", GetEdmModel(routeBuilder.ApplicationBuilder), new DefaultODataBatchHandler());
            routeBuilder.EnableDependencyInjection();
        }

        private static IEdmModel GetEdmModel(IApplicationBuilder app)
        {
            var builder = new ODataConventionModelBuilder(app.ApplicationServices);

            builder.EntitySet<Person>("Person");
            builder.EntitySet<Address>("Address");

            return builder.GetEdmModel();
        }
    }
}