namespace TuberTreats.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderPlacedOnDate { get; set; }
        public int CustomerId { get; set; }
        public int? TuberDriverId { get; set; }
        public DateTime? DeliveredOnDate { get; set; }
        public List<string> ToppingNames { get; set; } = new List<string>();
    }
} 