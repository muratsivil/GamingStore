using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingStore.Entities.Entity.Concrete
{
    public class Product : BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage ="Minimum lenght is 3..!")]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
