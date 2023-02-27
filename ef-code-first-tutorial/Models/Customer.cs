using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.ComponentModel.DataAnnotations; // for attributes such as [StringLength()]
using System.ComponentModel.DataAnnotations.Schema; // for the [Column] attribute

namespace ef_code_first_tutorial.Models
{
    public class Customer // entity model class for a table called Customer
    {
        // entity class properties representing the columns in a table
        public int Id { get; set; } = 0;
        [StringLength(50)] // setting the maximum string length for the property below
        [Required] // stating that this property below cannot be null
        public string Name { get; set; } = string.Empty;
        [StringLength(30), Required]
        public string City { get; set; } = string.Empty;
        [StringLength(2)] // don't have to use the [Required] attribute because the system knows if there's no ? after the type it cannot be null
        public string StateCode { get; set; } = "OH";
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Sales { get; set; }
        public bool Active { get; set; } = true;

        public Customer() { }
    }
}
