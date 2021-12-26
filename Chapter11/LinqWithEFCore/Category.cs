using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema; //needed for [column]
using System.ComponentModel.DataAnnotations;


namespace WorkingWithEFCore
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
