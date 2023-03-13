using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Shared.Entities
{
    public class Country
    {
        // Para la base de datos
        public int Id { get; set; }
        [Display(Name = "País")]
        [MaxLength(100, ErrorMessage = "Cuidado, el campo {0} solo puede contener {1} caracteres")]
        [Required(ErrorMessage = "* El campo {0} es obligatorio")]
        public string Name { get; set; } = null!;


        
    }
}
