namespace TuberTreats.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int OrderCount { get; set; }
    }

    public class CreateCustomerDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
} 