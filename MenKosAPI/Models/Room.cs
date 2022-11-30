namespace MenKosAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Floor { get; set; }

        public int RoomPriceId { get; set; }
        public int PaymentId { get; set; }         
        public RoomPrice roomPrice{ get; set; }

        public Payment payment { get; set; }
      

        public bool Status { get; set; }

        public string Description { get; set; }
    }
}
