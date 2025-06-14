namespace Farlo.Culture.Domain.Entities;

public class CultureInsight
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string RequestId { get; set; } = default!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Summary { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
