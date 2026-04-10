using Demo_2.Models;

namespace Demo_2.ViewModels
{
    public class ResturantVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int MenuItemId { get; set; }
        public List<MenuItem>? MenuItems { get; set; }
    }
}
