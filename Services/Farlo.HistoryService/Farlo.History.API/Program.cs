using Farlo.History.Application.Interfaces;
using Farlo.History.Infrastructure.Data;
using Farlo.History.Infrastructure.Messaging.Consumers;
using Farlo.History.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Swagger ve Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext + Repository
builder.Services.AddDbContext<HistoryDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IHistoryRepository, PostgresHistoryRepository>();

// MassTransit + RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<GeoQueryCompletedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("geo-query-completed-history-queue", e =>
        {
            e.ConfigureConsumer<GeoQueryCompletedConsumer>(context);
        });
    });
});

var app = builder.Build();

// 🚀 Otomatik migration işlemi
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HistoryDbContext>();
    db.Database.Migrate();
}

// Swagger UI (Development için)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
