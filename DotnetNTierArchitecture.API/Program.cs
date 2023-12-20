using DotnetNTierArchitecture.Core.Repositories;
using DotnetNTierArchitecture.Core.UnitOfWorks;
using DotnetNTierArchitecture.Repository.Repositories;
using DotnetNTierArchitecture.Repository.UnitOfWork;
using DotnetNTierArchitecture.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DotnetNTierArchitecture.Service.Mapping;
using DotnetNTierArchitecture.Core.Services;
using DotnetNTierArchitecture.Service;
using FluentValidation.AspNetCore;
using DotnetNTierArchitecture.Service.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddControllers()
    .AddFluentValidation(x =>
    {
        x.RegisterValidatorsFromAssemblyContaining<TeamDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<UserProfileDtoValidator>();
    });

//AppDbContext iþlemleri
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
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

app.UseAuthorization();

app.MapControllers();

app.Run();
