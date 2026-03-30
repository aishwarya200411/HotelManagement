public class Room
{
    public int Id { get; set; }
    public string RoomType { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
}