using Asp.Versioning;
using MultiShop.Order.Application;
using MultiShop.Order.Infrastructure;
using MultiShop.Order.Infrastructure.Persistence;
using MultiShop.Order.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddLoggingConfiguration(builder.Configuration);
builder.Services.AddPersistenceService(builder.Configuration);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(https =>
    {
        https.SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13;
        https.CheckCertificateRevocation = false;
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
