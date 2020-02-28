using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data.Entities
{
    public class BusinessType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(25, ErrorMessage = "El campo {0}, no puede tener mas de {1} caracteres de longitud")]
        [Display(Name = "Business Type")]
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }

    }
}
