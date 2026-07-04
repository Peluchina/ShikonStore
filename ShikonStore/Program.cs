using ShikonStore.Infraestructure.Data;
using ShikonStore.Domain.Contracts;
using ShikonStore.Infraestructure.Repositories;
using ShikonStore.Application.Commands;
using ShikonStore.Application.Queries;
using FluentValidation;
using ShikonStore.Application.Validators;
using ShikonStore.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IConnectionSQL, ConnectionSQL>();

builder.Services.AddTransient<IProductRepositoryRO, ProductRepositoryRO>();
builder.Services.AddTransient<IProductRepositoryWR, ProductRepositoyWR>();

builder.Services.AddTransient<ProductCreateCommandHandler>();
builder.Services.AddTransient<ProductUpdateCommandHandler>();
builder.Services.AddTransient<ProductUpdateStatusCommandHandler>();
builder.Services.AddTransient<ProductDeleteCommandHandler>();
builder.Services.AddTransient<ProductGetListQueryHandler>();
builder.Services.AddTransient<ProductGetXIdQueryHandler>();

builder.Services.AddValidatorsFromAssemblyContaining<ProductCreateCommandValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
