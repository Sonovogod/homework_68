using CountriesInformer.Models;
using CountriesInformer.Services;
using CountriesInformer.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CountriesDbContext>(o => o.UseNpgsql(connection));
builder.Services.AddControllers();
builder.Services.AddCors(o => 
    o.AddPolicy("AllowAllOrigin", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
    }));
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ICountryService, CountryService>();

var app = builder.Build();

app.Map("/", () => Results.LocalRedirect("/swagger"));

app.UseCors("AllowAllOrigin");
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Countries Api V1");
});

app.UseStaticFiles();
app.MapControllers();
app.Run();