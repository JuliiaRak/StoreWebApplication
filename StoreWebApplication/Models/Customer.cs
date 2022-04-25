using System;
using System.Collections.Generic;

namespace StoreWebApplication
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerÀdresses = new HashSet<CustomerÀdress>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? YearOfBirth { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<CustomerÀdress> CustomerÀdresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
