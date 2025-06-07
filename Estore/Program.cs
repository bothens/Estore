using Microsoft.OpenApi.Models;
using MediatR;
using Application_Layer.Interfaces.ProductInterfaces;
using Infrastructure_Layer.Repositories.Implementations;
using Application_Layer.Interfaces.UserInterface;
using Infrastructure_Layer.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application_Layer;
using Application_Layer.Interfaces.CartItemInterfaces;
using Application_Layer.Common.Behaviors;

var builder = WebApplication.CreateBuilder(args);

// DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();

// Application layer + MediatR
builder.Services.AddMediatR(typeof(ApplicationLayerAssemblyReference).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddAutoMapper(typeof(ApplicationLayerAssemblyReference).Assembly);

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Estore API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
