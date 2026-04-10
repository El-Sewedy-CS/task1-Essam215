using System.ComponentModel.DataAnnotations;

namespace Demo_2.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        
        public List<MenuItem>? MenuItems { get; set; }
        
    }
}
