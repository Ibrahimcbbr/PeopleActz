using Microsoft.EntityFrameworkCore;
using PeopleActz.API.Extensions;
using PeopleActz.Application.Helpers.AutoMapperProfiels;
using PeopleActz.Application.Helpers.Settings;
using PeopleActz.Application.Implementation.HelperServices;
using PeopleActz.Application.Implementation.ServiceManagers;
using PeopleActz.Application.Interfaces.HelperServices;
using PeopleActz.Application.Interfaces.Services;
using PeopleActz.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureIdentity();
// Register the Mapping Profiles
builder.Services.AddAutoMapper(typeof(Maps).Assembly);
builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddAuthentication();
var settings = new JwtSettings();
builder.Configuration.GetSection("Jwt").Bind(settings);
// Add customized Authentication to the services container.
builder.Services.AddCustomizedAuthentication(settings);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddDbContext<PeopleActzDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PeopleConn"));

});
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
app.UseAuthentication();
app.MapControllers();

app.Run();
