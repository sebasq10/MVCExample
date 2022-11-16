using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace MVC_Example.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage = "Display Order must be a number between 1 and 100")]
        public int DisplayOrden { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
