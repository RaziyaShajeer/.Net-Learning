using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebMvc.Models
{
    public enum ProductStatus
    {
        OutOfStock,
        Available
    }
    public class ProductModel
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        [NotMapped]
        public IFormFile? MyFile { get; set; }
        public string? Image{ get; set; }
        public int Stock{ get; set; }
        public Double Price { get; set; }
        public ProductStatus Status { get; set; }
        [DisplayName("Catagory")]
        public int  CategoryId { get; set; }
        public catagoryModel?  Category { get; set; }

        public string? UserId { get; set; }

        public IdentityUser? AppUser { get; set; }

    }
}
