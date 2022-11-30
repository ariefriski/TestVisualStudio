namespace MenKosAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Occupant OccupantId { get; set; }
        public Role RoleId { get; set; }

    }
}
