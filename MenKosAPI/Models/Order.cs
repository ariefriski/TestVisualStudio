namespace MenKosAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string EntryDate { get; set; }
        public string OutDate { get; set; }
        public int OccupantId { get; set; }
        public Occupant occupant { get; set; }
    }
}
