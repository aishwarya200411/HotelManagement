namespace HotelManagement.Models
{
    public class Room
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public string RoomType { get; set; }

        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}