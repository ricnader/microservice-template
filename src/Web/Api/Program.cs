using Serilog;
using Distribuitor.Api.Configurations;
using Ioc;
using FluentValidation.AspNetCore;
using System.Reflection;
using FluentValidation;
using Application.Validations;

var builder = WebApplication.CreateBuilder(args);

SerilogConfiguration.AddSerilogApi(builder.Configuration);
builder.Host.UseSerilog(Log.Logger);

// Add services to the container.
builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<DistribuitorValidator>();
builder.Services.AddKeyVaultConfigurations(builder);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiConfiguration(app.Environment);

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

