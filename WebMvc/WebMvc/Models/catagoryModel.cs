using System.ComponentModel.DataAnnotations;
using WebMvc.Areas.Admin.Controllers;

namespace WebMvc.Models
{
    public class catagoryModel
    {
        [Key]
        public int CatagoryId { get; set; }
      

        public string CatagoryName { get; set; }
        public string CatagoryDetails { get; set; }



        public ICollection<ProductModel>? Products { get; set; }

    }
}
