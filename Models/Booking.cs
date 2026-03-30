namespace HotelManagement.Models
{

    public class Booking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int RoomId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status { get; set; } = "Confirmed";
    }
}