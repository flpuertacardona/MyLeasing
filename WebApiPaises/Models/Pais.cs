using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPaises.Models
{
    public class Pais
    {
        public Pais()
        {
            Provincias = new List<Provincia>();
        }
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage ="El campo {0}, debe contener una longitud maxima de {1} caracteres")]
        public string Nombre {get; set; }
        public List<Provincia> Provincias { get; set; }
    }
}
