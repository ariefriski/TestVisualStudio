namespace MenKosAPI.Models
{
    public class RoomFacility
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Room RoomId { get; set; }

    }
}
