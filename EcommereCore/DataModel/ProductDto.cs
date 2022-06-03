using EcommereCore.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EcommereCore.DataModel
{
    public class ProductDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public IFormFile? Image { get; set; }
        //public string Img { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Quantity { get; set; }
       
        public int Categid { get; set; }
    }
}
