using Microsoft.AspNetCore.Mvc;
using APINoticiasFic.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APINoticiasFic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        // GET: api/<NoticiasController>
        [HttpGet]
        public IEnumerable<Noticia> Get()
        {
            return Noticia.ObtenerNoticias();
        }


        // GET api/<NoticiasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Noticia encontrado = Noticia.ObtenerNoticia(id);
            if (encontrado == null)
            {
                return NotFound(null);
            }
            return Ok(encontrado);
        }


        // POST api/<NoticiasController>
        [HttpPost]
        public void Post([FromBody] Noticia value)
        {
            Noticia.AgregarNoticia(value);
        }

        // POST api/<NoticiasController>/Autorizar/5
        [HttpPost]
        [Route("Autorizar/{id}")]
        public IActionResult PostAutorizar(string id)
        {
            bool resultado = Noticia.AutorizarNoticia(id);
            if (!resultado)
            {
                return NotFound();
            }
            return Ok();
        }


        // PUT api/<NoticiasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Noticia value)
        {
            bool resultado = Noticia.ActualizarNoticia(id, value);
            if (!resultado)
            {
                return NotFound();
            }
            return Ok();
        }


        // DELETE api/<NoticiasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            bool resultado = Noticia.EliminarNoticia(id);
            if (!resultado)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
