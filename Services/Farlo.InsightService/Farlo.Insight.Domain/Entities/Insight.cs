namespace Farlo.Insight.Domain.Entities;

public class Insight
{
    public Guid Id { get; set; }
    public string RequestId { get; set; }
    public string Summary { get; set; }
    public DateTime CreatedAt { get; set; }
}
