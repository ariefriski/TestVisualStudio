namespace MenKosAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Floor { get; set; }

        public RoomPrice RoomPriceId { get; set; }

        public Payment PaymentId { get; set; }
      

        public bool Status { get; set; }

        public string Description { get; set; }
    }
}
