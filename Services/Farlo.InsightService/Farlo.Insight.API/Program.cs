using Farlo.Insight.Application.Interfaces;
using Farlo.Insight.Infrastructure.Messaging.Consumers;
using Farlo.Insight.Infrastructure.Repositories;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInsightRepository, InMemoryInsightRepository>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AIInsightGeneratedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("ai-insight-generated-queue", e =>
        {
            e.ConfigureConsumer<AIInsightGeneratedConsumer>(context);
        });
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
