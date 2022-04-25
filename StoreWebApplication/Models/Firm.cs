using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreWebApplication
{
    public partial class Firm
    {
        public Firm()
        {
            Products = new HashSet<Product>();
        }

        
        public int FirmId { get; set; }

        [Required(ErrorMessage = "Поле не повинне бути порожнім")]
        [Display(Name = "Фірма")]
        public string Name { get; set; } = null!;

        [Display(Name = "Рік створення")]
        public int YearOfFondation { get; set; }

        [Required(ErrorMessage = "Поле не повинне бути порожнім")]
        [Display(Name = "Власник")]
        public string Owner { get; set; } = null!;

        [Display(Name = "Капітал")]
        public decimal? Capital { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
