namespace Farlo.History.Domain.Entities;

public class GeoQueryHistory
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string RequestId { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
