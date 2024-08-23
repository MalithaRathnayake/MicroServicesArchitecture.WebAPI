namespace KooBits.MicroServices.OrderServices.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
