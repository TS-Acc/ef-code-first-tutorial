using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.ComponentModel.DataAnnotations; // [StringLength]
using System.ComponentModel.DataAnnotations.Schema; // [Column]

namespace ef_code_first_tutorial.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [StringLength(80)]
        public string? Description { get; set; } = null;
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Total { get; set; }

        public int? CustomerId { get; set; } // EF assumes this is a foreign key (FK)
        public virtual Customer? Customer { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public Order() { }
    }
}
