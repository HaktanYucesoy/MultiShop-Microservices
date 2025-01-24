using Asp.Versioning;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.Extensions.DependencyResolvers;
using MultiShop.Catalog.Handlers.Exception;
using MultiShop.Catalog.Settings;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCatalogDependencies();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
        Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
        context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
        context.ProblemDetails.Extensions.TryAdd("moreDetails", context.Exception!=null?context.Exception!.StackTrace:"");
        context.ProblemDetails.Extensions.TryAdd("details", context.Exception!.Message != null ? context.Exception.Message : "");
    };
});

builder.Services.AddApiVersioning(x =>
{
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.DefaultApiVersion = ApiVersion.Default;
    x.ReportApiVersions = true;
    x.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("api-version"),
        new UrlSegmentApiVersionReader()
        );
}).AddApiExplorer(x =>
{
    x.GroupNameFormat = "'v'V";
    x.SubstituteApiVersionInUrl = true;
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStatusCodePages();
app.MapControllers();
app.Run();
