using System.ComponentModel.DataAnnotations;

namespace KooBits.MicroServices.OrderServices.Models
{
    public class Order
    {

        public int OrderID { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Product is required.")]
        [StringLength(100, ErrorMessage = "Product can't be longer than 100 characters.")]
        public string Product { get; set; }

        [Required(ErrorMessage = "Quantity is required.")] 
        public int Quantity { get; set; }
    }
}
