using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }
        //propiedades de los campos de la tabla
        [MaxLength(100)]
        [Display(Name = "Pais")]
        [Required(ErrorMessage ="El campo {0} es Obligatorio")]
        public string Name { get; set; } = null!;

        public ICollection<State>? States { get; set; }
        public int StatesNumber => States ==null ?0 : States.Count;
    }
}
