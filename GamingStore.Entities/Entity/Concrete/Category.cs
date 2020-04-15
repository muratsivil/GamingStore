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
    public class Category : BaseEntity
    {
        [Required]
        [MinLength(2, ErrorMessage ="Minimum Lenght is 2..!")]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDescription { get; set; }

       
        public virtual ICollection<Product> Products { get; set; }
    }
}
