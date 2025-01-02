namespace TuberTreats.DTOs
{
    public class DriverDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeliveryCount { get; set; }
    }

    public class CreateDriverDTO
    {
        public string Name { get; set; }
    }
} 