using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductInput
    {
        public int Id { get; set; }
        [Required]
        public  string Name { get; set; }

        [Required]
        public  decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}