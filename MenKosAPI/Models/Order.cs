namespace MenKosAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateOnly EntryDate {get; set;}
        public DateOnly OutDate { get; set; }
        public Occupant OccupantId { get; set; }

    }
}
