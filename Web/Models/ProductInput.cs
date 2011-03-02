using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ProductInput
    {
        public int Id { get; set; }
        public  string Name { get; set; }

        public  decimal Price { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }
    }
}