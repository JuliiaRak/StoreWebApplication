using System;
using System.Collections.Generic;

namespace StoreWebApplication
{
    public partial class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string OrderStatus1 { get; set; } = null!;
        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
