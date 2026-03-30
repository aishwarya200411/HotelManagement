namespace HotelManagement.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime ExpiryDate { get; set; }
    }
}
