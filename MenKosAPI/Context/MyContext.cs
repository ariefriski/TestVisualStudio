using MenKosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MenKosAPI.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Occupant> Occupants{ get; set; }
        public DbSet<Order> Orders{ get; set; }

        public DbSet<Payment> Payments{ get; set; }

        public DbSet<Room> Rooms{ get; set; }
        public DbSet<RoomFacility> RoomFacilities{ get; set; }

        public DbSet<RoomPicture> RoomPictures{ get; set; }

        public DbSet<User> Users  { get; set; }

    }
}
