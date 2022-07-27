using StockApi.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApi.Dto
{
    public class ProductDto : BaseDto
    {
        [Required]
        [Display(Name = "ProductId")]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "ProductPrice")]
        public double ProductPrice { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "ProductCount")]
        public int ProductCount { get; set; }
    }
}
