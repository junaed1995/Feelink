using ConvoX;
using ConvoX.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services for SignalR
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline for SignalR
app.UseRouting();
app.UseCors();

// SignalR Hub
app.MapHub<ChatHub>("/chatHub");

app.Run();
