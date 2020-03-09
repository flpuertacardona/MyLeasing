using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPaises.Models;

namespace WebApiPaises.Controllers
{
    [Produces("application/json")]
    [Route("api/Pais/{PaisId}/Provincia")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProvinciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Provincia> GetAll(int paisId)
        {
            return _context.Provincias.Where(p => p.PaisId == paisId) .ToList();
        }

        [HttpGet("{id}", Name = "provinciaCreada")]
        public IActionResult GetById(int id)
        {
            var provincia = _context.Provincias.FirstOrDefault(p => p.Id == id);

            if (provincia == null)
            {
                return NotFound("Provincia no encontrado en la base de datos. Excelente !!!!!!!");
            }
            return Ok(provincia);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _context.Provincias.Add(provincia);
                _context.SaveChanges();
                return new CreatedAtRouteResult("provinciaCreada", new { id = provincia.Id }, provincia);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Provincia provincia, int id)
        {
            if (provincia.Id != id)
            {
                return BadRequest("Provincia No exite");
            }

            _context.Entry(provincia).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok("Registro ingresado correctamnente");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var provincia = _context.Provincias.FirstOrDefault(p => p.Id == id);
            if (provincia == null)
            {
                return NotFound("El registro pais No existe");
            }
            _context.Provincias.Remove(provincia);
            _context.SaveChanges();
            return Ok("Registro borrado correctamente");
        }


    }
}