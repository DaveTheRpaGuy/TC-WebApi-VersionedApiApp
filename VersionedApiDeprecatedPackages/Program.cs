using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opts =>
{
    var title = "Our Versioned API";
    var description = "This is a Web API that demonstrates versioning.";
    var terms = new Uri("https://localhost:7266/terms");
    var license = new OpenApiLicense()
    {
        Name = "This is my full license information or a link to it."
    };
    var contact = new OpenApiContact()
    {
        Name = "Dave Morris Helpdesk",
        Email = "dave@davetherpaguy.com",
        Url = new Uri("https://davetherpaguy.com")
    };

    opts.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = $"{title} v1 (deprecated)",
        Description = description,
        TermsOfService = terms,
        License = license,
        Contact = contact
    });

    opts.SwaggerDoc("v2", new OpenApiInfo
    {
        // Could make changes to the terms of service or license or whatever for v2
        Version = "v2",
        Title = $"{title} v2",
        Description = description,
        TermsOfService = terms,
        License = license,
        Contact = contact
    });
});

builder.Services.AddApiVersioning(opts =>
{
    opts.DefaultApiVersion = new ApiVersion(2, 0);
    opts.AssumeDefaultVersionWhenUnspecified = true;
    opts.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(opts =>
{
    opts.GroupNameFormat = "'v'VVV";
    opts.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
