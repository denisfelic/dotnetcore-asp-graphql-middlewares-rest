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
                .AllowAnyOrigin()
               //   .WithOrigins(["https://studio.apollographql.com", "http://localhost:5173", "*"])
               .AllowAnyHeader()
               .AllowAnyMethod();
       });
   })

.AddGraphQLServer()
.RegisterDbContext<MyAppDbContext>()
    .AddInMemorySubscriptions()
    .AddFiltering()
    .AddQueryType(q => q.Name("Query"))
    .AddMutationType(m => m.Name("Mutation"))
    .AddType<UploadType>()
    .AddType<BookMakerQuery>()
    .AddTypeExtension<BookMarkerExtension>()
    .AddType<UpdateBookmarkerFaviconMutation>()
    .AddType<BookMakerMutations>();


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.UseRouting().UseEndpoints(endpoints =>
{

    app.UseWebSockets();
    endpoints.MapGraphQL();
});

app.MapGet("/", () => "Open /graphql");

app.Run();

