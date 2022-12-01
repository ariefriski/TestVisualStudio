namespace MenKosAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime OutDate { get; set; }
        public int OccupantId { get; set; }
        public Occupant occupant { get; set; }
    }
}
