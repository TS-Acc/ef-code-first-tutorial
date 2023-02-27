using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_code_first_tutorial.Models
{
    public class Item
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        public Item() { }

    }
}
