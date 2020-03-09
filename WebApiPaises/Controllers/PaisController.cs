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
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            return _context.Paises.ToList();
        }

        [HttpGet("{id}",Name ="paisCreado")]
        public IActionResult GetById(int id)
        {
            var pais = _context.Paises.Include(p => p.Provincias).FirstOrDefault(x => x.Id == id);

            if (pais==null)
            {
                return NotFound("Pais no encontrado en la base de datos. Excelente !!!!!!!");
            }
            return Ok(pais);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pais pais)
        {
            if (ModelState.IsValid)
            {
                _context.Paises.Add(pais);
                _context.SaveChanges();
                return new CreatedAtRouteResult("paisCreado", new { id = pais.Id }, pais);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Pais pais, int id)
        {
            if (pais.Id != id)
            {
                return BadRequest("Pais No exite");
            }

            _context.Entry(pais).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok("Registro ingresado correctamnente");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pais = _context.Paises.FirstOrDefault(p => p.Id == id);
            if (pais == null)
            {
                return NotFound("El registro pais No existe");
            }
            _context.Paises.Remove(pais);
            _context.SaveChanges();
            return Ok("Registro borrado correctamente");
        }
    }
}