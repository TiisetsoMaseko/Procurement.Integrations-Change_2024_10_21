

using AspNetCoreRateLimit;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
   .AddReverseProxy()
   .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("customPolicy", opt =>
    {
        opt.PermitLimit = 5;
        opt.Window = TimeSpan.FromSeconds(30);
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opt.QueueLimit = 2;
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("secure", policy =>
    policy.RequireAuthenticatedUser());
});

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseRateLimiter();
app.MapReverseProxy();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
