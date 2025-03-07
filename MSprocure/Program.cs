using MSprocure.Middleware;
using MSprocure.Service;
using MSprocure.Service.Authorize;
using MSprocure.Service.Authorize.IAuthorize;
using MSprocure.Service.Client;
using MSprocure.Service.Client.IClients;
using MSprocure.Service.IService;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFilter("Microsoft.*", LogLevel.Warning);
builder.Logging.AddFilter("System.*", LogLevel.Warning);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IClient, Client>();
builder.Services.AddScoped<IPOservice, POservice>();
builder.Services.AddScoped<IASNService, ASNService>();
builder.Services.AddScoped<IinvoiceService, InvoiceService>();
builder.Services.AddScoped<IAuthorization, Authorization>();
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Logging.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());

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

//app.UseHttpsRedirection();

app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
//app.UseMiddleware(typeof(ApiKeyMiddleware));
//app.UseAuthorization();

app.MapControllers();

app.Run();
