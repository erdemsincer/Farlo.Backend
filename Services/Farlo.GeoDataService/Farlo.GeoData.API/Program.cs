using Farlo.GeoData.Infrastructure.Messaging.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 📡 MassTransit + RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<GeoQueryRequestedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
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
