using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema; //needed for [column]

namespace WorkingWithEFCore
{
    public class Category
    {
        //the prop. map to columns in the database
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        [Column(TypeName ="ntext")]
        public string? Description { get; set; }

        //defines a navigation property for related rows
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}
