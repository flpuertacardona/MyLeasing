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

        [MaxLength(50,ErrorMessage ="El campo {0}, debe tener una longitud maxima de {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Neighborhood { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0}, debe tener una longitud maxima de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayFormat(DataFormatString ="{0:C2}", ApplyFormatInEditMode =false)]
        public decimal Price { get; set; }

        [Display(Name ="Square Meters")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int SquareMeters { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Rooms { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Stratum { get; set; }

        [Display(Name ="Has Parking Lot ?")]
        public bool HasParkingLot { get; set; }

        [Display(Name = "Is Available ?")]
        public bool IsAvailable { get; set; }

        public string Remarks { get; set; }

        public PropertyType propertyType { get; set; }

        public Owner Owner { get; set; }

        public ICollection<PropertyImage> PropertyImages { get; set; }
        public ICollection<Contract> Contracts { get; set; }


    }
}
