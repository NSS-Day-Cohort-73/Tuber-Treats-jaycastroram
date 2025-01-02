namespace TuberTreats.Models
{
    public class Customer
    {
        public int Id { get; set; }  // Primary Key
        public string Name { get; set; } = string.Empty;  // Customer name
        public string Address { get; set; } = string.Empty;  // Customer address
        public List<TuberOrder> TuberOrders { get; set; } = new List<TuberOrder>();  // Orders placed by the customer
    }
}
