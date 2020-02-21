using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data.Entities
{
    public class PropertyImage
    {
        public int Id  { get; set; }

        [Display(Name ="Image")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string ImageUrl { get; set; }

        //TODO : Cambia el path al publicar
        public string ImageFullPath => $"https://TBD.azurewebsites.net{ImageUrl.Substring(1)}";

        public Property Property { get; set; }

    }
}
