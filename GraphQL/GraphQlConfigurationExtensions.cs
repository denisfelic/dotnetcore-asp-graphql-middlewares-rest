using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Database;
using dotnetcore_asp.GraphQL.Mutations;
using dotnetcore_asp.GraphQL.Queries;

namespace dotnetcore_asp.GraphQL
{
    public static class GraphConfigurationExtensions
    {
        public static void UseGraphQLServiceConfiguration(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                .RegisterDbContext<MyAppDbContext>()
                .AddInMemorySubscriptions()
                .AddFiltering()
                .AddQueryType(q => q.Name("Query"))
                .AddMutationType(m => m.Name("Mutation"))
                .AddType<BookMakerQuery>()
                .AddTypeExtension<BookMarkerExtension>()
                .AddType<BookMakerMutations>();

        }

        public static void UseGraphQlAppConfiguration(this WebApplication app)
        {
            app.UseWebSockets();
            app.MapGraphQL();
        }
    }
}