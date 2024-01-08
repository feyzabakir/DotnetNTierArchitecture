using DotnetNTierArchitecture.Core.Repositories;
using DotnetNTierArchitecture.Core.UnitOfWorks;
using DotnetNTierArchitecture.Repository.Repositories;
using DotnetNTierArchitecture.Repository.UnitOfWork;
using DotnetNTierArchitecture.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DotnetNTierArchitecture.Service.Mapping;
using DotnetNTierArchitecture.Core.Services;
using FluentValidation.AspNetCore;
using DotnetNTierArchitecture.Service.Validations;
using DotnetNTierArchitecture.Service.Services;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using DotnetNTierArchitecture.API.Modules;
using DotnetNTierArchitecture.API.MiddleWares;
using Microsoft.OpenApi.Models;
using DotnetNTierArchitecture.Service.Authorization.Abstraction;
using DotnetNTierArchitecture.Service.Authorization.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region swagger islemleri
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

#endregion

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IJwtAuthenticationManager, JwtAuthenticationManager>();

// JWT Kutuphanesi
builder.Services.AddControllers().AddFluentValidation(x => { x.RegisterValidatorsFromAssemblyContaining<TeamDtoValidator>();});

//AppDbContext islemleri
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//Buradan Autofac kullanarak yazdığımız RepoServiceModule'ü dahil ediyoruz.
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoModuleService()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.Run();
