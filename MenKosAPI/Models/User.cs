namespace MenKosAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int OccupantId { get; set; }

        public int RoleId { get; set; }
        public Occupant occupant { get; set; }
        public Role role { get; set; }

    }
}
