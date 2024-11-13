using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public State? State { get; set; }
        public int StateId { get; set; }
    }
}
