namespace HotelBooking.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool IsFirstTime { get; set; }
    }
}