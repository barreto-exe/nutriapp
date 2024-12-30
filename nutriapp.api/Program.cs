using Microsoft.EntityFrameworkCore;
using nutriapp.business.AutoMapper;
using nutriapp.business.Base;
using nutriapp.business.Interfaces;
using nutriapp.business.Services;
using nutriapp.business.Users;
using nutriapp.infrastructure.Data;
using nutriapp.infrastructure.Interfaces;
using nutriapp.infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("SqlConnectionString");
builder.Services.AddDbContext<NutriAppContext>(options =>
{
    options.UseSqlServer(connString);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IWaterMeasureService, WaterMeasureService>();
builder.Services.AddTransient<IWaterConsumedService, WaterConsumedService>();

//Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUserHandler>());

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
