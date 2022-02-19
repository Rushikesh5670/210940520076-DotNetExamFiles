using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetExam.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please enter product name")]
        public string ProductName { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter product rate")]
        public decimal Rate { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter product description")]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter product category")]
        public string CategoryName { get; set; }

    }
}