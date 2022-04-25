using System;
using System.Collections.Generic;

namespace StoreWebApplication
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
            OrderStatuses = new HashSet<OrderStatus>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerAdressId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }
    }
}
