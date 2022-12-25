using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.NETCore.Solutions.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Please Provide Product Name")]
        [Display(Name="Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Provide Product Code")]
        [Display(Name = "Product Code")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Provide Description")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

    }
}
