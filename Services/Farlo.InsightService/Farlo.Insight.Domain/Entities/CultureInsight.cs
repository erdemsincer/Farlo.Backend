namespace Farlo.Insight.Domain.Entities
{
    public class CultureInsight
    {
        public Guid Id { get; set; }
        public string RequestId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Summary { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
