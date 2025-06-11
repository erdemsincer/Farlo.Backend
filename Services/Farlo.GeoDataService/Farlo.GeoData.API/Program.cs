using Farlo.GeoData.Application.Interfaces;
using Farlo.GeoData.Infrastructure.Messaging.Consumers;
using Farlo.GeoData.Infrastructure.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGeoDataService, GeoDataService>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<GeoQueryRequestedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("geo-query-requested-queue", e =>
        {
            e.ConfigureConsumer<GeoQueryRequestedConsumer>(context);
        });
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
