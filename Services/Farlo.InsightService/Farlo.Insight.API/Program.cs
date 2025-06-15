using Farlo.Insight.Application.Interfaces;
using Farlo.Insight.Infrastructure.Messaging.Consumers;
using Farlo.Insight.Infrastructure.Persistence;
using Farlo.Insight.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ PostgreSQL
builder.Services.AddDbContext<InsightDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Repositories
builder.Services.AddScoped<IInsightRepository, EFInsightRepository>();

// ✅ MassTransit + RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AIInsightGeneratedConsumer>();
    x.AddConsumer<CultureInsightGeneratedConsumer>();

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

        cfg.ReceiveEndpoint("culture-insight-generated-queue", e =>
        {
            e.ConfigureConsumer<CultureInsightGeneratedConsumer>(context);
        });
    });
});

// ✅ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000") // Vite/React frontend için Docker dışında
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// ✅ API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Middleware sırası
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// ✅ Otomatik migration
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<InsightDbContext>();
    db.Database.Migrate();
}

app.Run();
