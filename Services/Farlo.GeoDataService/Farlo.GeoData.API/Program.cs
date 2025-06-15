using Farlo.GeoData.Application.Interfaces;
using Farlo.GeoData.Infrastructure.Messaging.Consumers;
using Farlo.GeoData.Infrastructure.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controllerlar
builder.Services.AddControllers();

// ✅ CORS Ayarları
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000") // Vite frontend docker’da 3000:8080 portuna maplenmiş
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // Eğer token veya cookie ile işlem varsa
    });
});

// Uygulama servisleri
builder.Services.AddScoped<IGeoDataService, GeoDataService>();

// ✅ MassTransit + RabbitMQ
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

// ✅ CORS Middleware mutlaka MapControllers’tan ÖNCE
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
