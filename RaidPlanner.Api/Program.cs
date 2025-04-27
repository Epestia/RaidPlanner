using Microsoft.EntityFrameworkCore;
using RaidPlanner.DAL.Data;
using RaidPlanner.Bll.Mappers;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.Bll.Services;
using RaidPlanner.DAL.Repository.IRepository; 
using RaidPlanner.DAL.Repository; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IJobService, JobService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();


builder.Services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
builder.Services.AddScoped<IAvailabilityService, AvailabilityService>();


builder.Services.AddScoped<IExtensionRepository, ExtensionRepository>();
builder.Services.AddScoped<IExtensionService, ExtensionService>();


builder.Services.AddScoped<IRaidRepository, RaidRepository>();
builder.Services.AddScoped<IRaidService, RaidService>();


builder.Services.AddScoped<IRaidSessionRepository, RaidSessionRepository>();
builder.Services.AddScoped<IRaidSessionService, RaidSessionService>();


builder.Services.AddScoped<IRecompenseRepository, RecompenseRepository>();
builder.Services.AddScoped<IRecompenseService, RecompenseService>();


BllDalMappingConfig.ConfigureMappings();

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
