using DotNetEnv;
using Farlo.AI.Application.Interfaces;
using Farlo.AI.Infrastructure.Messaging.Consumers;
using Farlo.AI.Infrastructure.Services;
using Farlo.AI.Infrastructure.Settings;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// 🌍 .env dosyasını yükle
DotNetEnv.Env.Load();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔐 Environment'tan ayarları oku
builder.Services.Configure<OpenAISettings>(options =>
{
    options.ApiKey = Environment.GetEnvironmentVariable("OPENAI__APIKEY")!;
    options.Model = Environment.GetEnvironmentVariable("OPENAI__MODEL")!;
});

// DI
builder.Services.AddScoped<IAIService, AIService>();

// RabbitMQ
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
