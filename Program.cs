using dotnetcore_asp.Core.Database;
using dotnetcore_asp.Core.Handlers;
using dotnetcore_asp.GraphQL.Mutations;
using dotnetcore_asp.GraphQL.Queries;

var builder = WebApplication.CreateBuilder(args);

// Database configuration
builder.Services.AddDbContext<MyAppDbContext>();

// Cors configuration
builder.Services.AddCors(options =>
   {
       options.AddDefaultPolicy(builder =>
       {
           builder
                .AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
       });
   });

// Graph QL Configurations
builder.Services.AddGraphQLServer()
.RegisterDbContext<MyAppDbContext>()
    .AddInMemorySubscriptions()
    .AddFiltering()
    .AddQueryType(q => q.Name("Query"))
    .AddMutationType(m => m.Name("Mutation"))
    .AddType<BookMakerQuery>()
    .AddTypeExtension<BookMarkerExtension>()
    .AddType<BookMakerMutations>();


// Http Configurations
builder.Services.AddControllers();

// Swagger Configurations
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Custom middleware examples
app.Use(async (context, next) =>
{
    Console.WriteLine("My custom middleware Runs!");
    await next();
});

app.UseMiddleware<FullHostMiddleware>();


// Dev only configurations
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cors Configurations
app.UseCors();

// Static files configurations
app.UseStaticFiles();

// Configure the HTTP request pipeline.
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

