﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data.Entities
{
    public class Lessee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(25, ErrorMessage = "El campo {0}, no puede tener mas de {1} caracteres de longitud")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(25, ErrorMessage = "El campo {0}, no puede tener mas de {1} caracteres de longitud")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(25, ErrorMessage = "El campo {0}, no puede tener mas de {1} caracteres de longitud")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(20)]
        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }

        [MaxLength(20)]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [Display(Name = "Lessee Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Nombre Documento")]
        public string FullNameDoc => $"{FullName} - {Document}";
        public ICollection<Contract> Contracts { get; set; }

    }
}
