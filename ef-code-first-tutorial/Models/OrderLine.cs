﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_code_first_tutorial.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;

        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        public int ItemId { get; set; }
        public virtual Item Item { get; set; } = null!;

        public OrderLine() { }
    }
}
