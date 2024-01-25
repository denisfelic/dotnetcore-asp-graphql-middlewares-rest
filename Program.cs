using dotnetcore_asp.Core.Database;
using dotnetcore_asp.GraphQL.Mutations;
using dotnetcore_asp.GraphQL.Queries;

var builder = WebApplication.CreateBuilder(args);
builder.Services

.AddDbContext<MyAppDbContext>()

.AddCors(options =>
   {
       options.AddDefaultPolicy(builder =>
       {
           builder
               .WithOrigins("https://studio.apollographql.com")
               .AllowAnyHeader()
               .AllowAnyMethod();
       });
   })

.AddGraphQLServer()
.RegisterDbContext<MyAppDbContext>()
    .AddInMemorySubscriptions()
    .AddQueryType(q => q.Name("Query"))
    .AddMutationType(m => m.Name("Mutation"))
    .AddType<MutateMusicCollection>()
    .AddType<MutateTodoCollection>()
    .AddType<QueryTodoCollection>()
    .AddType<QueryMusicCollection>();

var app = builder.Build();

app.UseCors();
app.UseRouting().UseEndpoints(endpoints =>
{

    app.UseWebSockets();
    endpoints.MapGraphQL();
});

app.MapGet("/", () => "Open /graphql");

app.Run();

