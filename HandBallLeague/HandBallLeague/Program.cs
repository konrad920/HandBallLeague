using HandBallLeague.AplicationServices.API.Domain;
using HandBallLeague.AplicationServices.API.Mappings;
using HandBallLeague.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();

builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();

builder.Services.AddAutoMapper(typeof(PlayersProfile).Assembly);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddMediatR(typeof(ResponseBase<>));

var connectionString = builder.Configuration.GetConnectionString("HandBallLeagueConnection");
builder.Services.AddDbContext<HandBallLeagueContext>(opt => opt.UseSqlServer(connectionString));

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
