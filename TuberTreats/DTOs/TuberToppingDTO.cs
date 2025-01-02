namespace TuberTreats.DTOs
{
    public class TuberToppingDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ToppingName { get; set; }
    }

    public class CreateTuberToppingDTO
    {
        public int TuberOrderId { get; set; }
        public int ToppingId { get; set; }
    }
} 