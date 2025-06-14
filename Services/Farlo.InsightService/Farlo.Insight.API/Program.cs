using Farlo.Insight.Application.Interfaces;
using Farlo.Insight.Infrastructure.Messaging.Consumers;
using Farlo.Insight.Infrastructure.Persistence;
using Farlo.Insight.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInsightRepository, InMemoryInsightRepository>();
builder.Services.AddDbContext<InsightDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<InsightDbContext>();
    dbContext.Database.Migrate();
}
app.Run();
