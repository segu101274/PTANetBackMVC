using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAPI.Models;
using WebAppAPI.DataConecton;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        [HttpGet("listar")]
        public async Task<ActionResult> Get()
        {
            var result = await Task.Run(() => new CountryDA().listado());
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("ubicar")]
        public async Task<IActionResult> Get(Int32 id)
        {
            var result = await Task.Run(() => new CountryDA().Ubicar(id));
            if (result == null)
                return NotFound();
            return Ok(result);

        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Post(Country obj)
        {
            var result = await Task.Run(() => new CountryDA().Registrar(obj));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Put(Country obj)
        {
            var result = await Task.Run(() => new CountryDA().Actualizar(obj));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Delete(Int32 id)
        {
            var result = await Task.Run(() => new CountryDA().Eliminar(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
