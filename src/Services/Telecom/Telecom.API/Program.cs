using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using System.Configuration;
using System.Reflection;
using System.Text.Json.Serialization;
using Telecom.API;
using Telecom.API.Data;
using Telecom.API.Entities;
using Telecom.API.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddJsonOptions(options=>options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddTelecomInfos(builder);
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Telecom.API", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseHttpsRedirection();
app.Run();

