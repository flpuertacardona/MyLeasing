using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[]
            { 
                "value1", "value2", "Soy Francisco Puerta : Bienvenido a mi primera API, que berraquera ...",
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int valor)
        {
            int[] serie1 = new int[200];
            int[] serie2 = new int[200];
            var cabeza1 = 480;
            var cabeza2 = 450;
            serie1[0] = cabeza1;
            serie2[0] = cabeza2;
            var dato2 = 0;

            for (int i = 0; serie1[i] <= 20000; i++)
            {

                var ancho1 = serie1[i].ToString().Length;
                var suma1 = 0;
                var suma2 = 0;
                for (int j = 0; j < ancho1; j++)
                {
                    string dato1 = serie1[i].ToString().Substring(j, 1);
                    suma1 += int.Parse(dato1);
                }
                serie1[i+1] = serie1[i]+suma1;

                var ancho2 = serie2[i].ToString().Length;
                for (int j = 0; j < ancho2; j++)
                {
                    string dato1 = serie2[i].ToString().Substring(j, 1);
                    suma2 += int.Parse(dato1);
                }
                serie2[i+1] = serie2[i]+suma2;

                if (serie1[i+1] == serie2[i+1])
                {
                    dato2 = serie2[i+1];
                    return "Punto de intersección: " + dato2.ToString();
                }
            }

            return "Punto de intersección: " + dato2.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
