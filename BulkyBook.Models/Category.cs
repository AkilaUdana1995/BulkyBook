using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        [DisplayName("display Order")]
        // [UIHint("UnitsInStock")]
        [Range(1, 100, ErrorMessage = "plese enter only between 1 to 100")]

        public int displayOrder { get; set; }
        public DateTime createdDateTime { get; set; } = DateTime.Now;


    }
}
