using InventoryManager.Api;
using InventoryManager.Api.Authentication;
using InventoryManager.Api.HostedServices;
using InventoryManager.Application;
using InventoryManager.Application.Contracts.Infrastructure;
using InventoryManager.Infrastructure;
using InventoryManager.Persistence;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureInfrastructureServices();

builder.Services.AddControllers();

builder.Services.AddHostedService<ProcessingItemExpiredHostedService>();
builder.Services.AddScoped<IProcessingItemExpiredService, ProcessingItemExpiredService>();

// configure basic authentication 
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationService>("BasicAuthentication", null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

SampleData.Initialize(app);

app.Run();

