using Farlo.AI.Application.Interfaces;
using Farlo.AI.Infrastructure.Messaging.Consumers;
using Farlo.AI.Infrastructure.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAIService, AIService>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<GeoQueryCompletedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("geo-query-completed-queue", e =>
        {
            e.ConfigureConsumer<GeoQueryCompletedConsumer>(context);
        });
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
