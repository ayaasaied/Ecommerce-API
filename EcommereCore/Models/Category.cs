using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommereCore.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
