using MyLeasing.Web.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data.Entities
{
    public class Property
    {
        public int Id { get; set; }

        [Display(Name = "Sector / Barrio")]
        [MaxLength(50,ErrorMessage ="El campo {0}, debe tener una longitud maxima de {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Neighborhood { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(50, ErrorMessage = "El campo {0}, debe tener una longitud maxima de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Address { get; set; }

        [Display(Name = "Escritura")]
        [MaxLength(50, ErrorMessage = "El campo {0}, debe tener una longitud maxima de {1} caracteres")]
        public string Escritura { get; set; }

        [Display(Name = "Estado Físico")]
        [MaxLength(50, ErrorMessage = "El campo {0}, debe tener una longitud maxima de {1} caracteres")]
        public string Status { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayFormat(DataFormatString ="{0:C2}", ApplyFormatInEditMode =false)]
        public decimal Price { get; set; }

        [Display(Name ="Square Meters")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int SquareMeters { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Rooms { get; set; }

        [Display(Name = "Baños")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int BathRooms { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Stratum { get; set; }

        [Display(Name ="Has Parking Lot ?")]
        public bool HasParkingLot { get; set; }

        [Display(Name = "Is Available ?")]
        public bool IsAvailable { get; set; }

        public string Remarks { get; set; }

        public PropertyType PropertyType { get; set; }

        public BusinessType BusinessType { get; set; }
        public Agent Agent { get; set; }

        public Owner Owner { get; set; }

        public ICollection<PropertyImage> PropertyImages { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
