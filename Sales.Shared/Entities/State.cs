using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }
        [Display(Name = "Departamento")]
        [MaxLength(100)]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]

        public string Name { get; set; } = null!;

        public Country? Country { get; set; }

        public ICollection<City>? Cities { get; set; }
        public int CitiesNumber => Cities == null ? 0 : Cities.Count();

        public int CountryId { get; set; }
    }
}
