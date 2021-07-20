using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class Category:Base
    {
        public int ParentId { get; set; } = 0;
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Product> Products { get; set; }



    }
}