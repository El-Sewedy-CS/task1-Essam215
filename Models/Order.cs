using System.ComponentModel.DataAnnotations;

namespace Demo_2.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }
    }
}