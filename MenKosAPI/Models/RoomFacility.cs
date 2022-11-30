namespace MenKosAPI.Models
{
    public class RoomFacility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Room RoomId { get; set; }
        public string Description { get; set; }

    }
}
