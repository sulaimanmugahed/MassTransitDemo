using MassTransit;
using MassTransitDemo.Api.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDriverNotificationPublisher,DriverNotificationPublisher>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(busConfig=>
{
  
    busConfig.UsingRabbitMq((context,config) => 
    {
        config.Host("localhost", "/", host =>
        {
            host.Username("myuser");
            host.Password("mypass");
        });
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

app.MapPost("driver", async ([FromQuery]Guid id,[FromQuery]string name, [FromServices] IDriverNotificationPublisher DriverNotificationPublisher) =>
{
   await DriverNotificationPublisher.SentNotification(id, name);

});

app.Run();

