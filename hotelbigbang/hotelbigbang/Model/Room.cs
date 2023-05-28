using System.ComponentModel.DataAnnotations;

namespace hotelbigbang.Model

{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string? RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public int Price { get; set; }
        public bool Availability { get; set; }
        // other room properties
        public Hotel? hotel { get; set; }

    }
}