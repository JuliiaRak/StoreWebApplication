using System;
using System.Collections.Generic;

namespace StoreWebApplication
{
    public partial class CustomerÀdress
    {
        public int CustomerAdressId { get; set; }
        public int CustomerId { get; set; }
        public string Adress { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
    }
}
