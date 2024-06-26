using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Category
    {
        [Key]
        [DisplayName("CategoryId")]
        public int CategoryId { get; set; }
        [DisplayName("CategoryName")]
        public string? CategoryName { get; set; }
    }
}
