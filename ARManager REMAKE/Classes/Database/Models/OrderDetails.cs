namespace ARManager_REMAKE.Classes.Database.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
        public int TotalCost { get; set; }
    }
}
