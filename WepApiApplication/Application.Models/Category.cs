using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage="The name is required")]
        public string Name { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        public virtual ICollection<Place> Places { get; set; }

        public Category()
        {
            this.Places = new HashSet<Place>();
        }
    }
}
