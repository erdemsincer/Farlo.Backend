using Farlo.Culture.Application.Interfaces;
using Farlo.Culture.Infrastructure.Messaging.Consumers;
using Farlo.Culture.Infrastructure.Persistence;
using Farlo.Culture.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL connection
builder.Services.AddDbContext<CultureDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository
builder.Services.AddScoped<IInsightRepository, EFInsightRepository>();

// MassTransit + RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CultureInsightGeneratedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("culture-insight-generated-event", e =>
        {
            e.ConfigureConsumer<CultureInsightGeneratedConsumer>(context);
        });
    });
});

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CultureDbContext>();
    db.Database.Migrate();
}
app.Run();
