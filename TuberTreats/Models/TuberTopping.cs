namespace TuberTreats.Models
{
    public class TuberTopping
    {
        public int Id { get; set; }  // Primary Key
        public int TuberOrderId { get; set; }  // Foreign Key
        public int ToppingId { get; set; }  // Foreign Key
    }
}
