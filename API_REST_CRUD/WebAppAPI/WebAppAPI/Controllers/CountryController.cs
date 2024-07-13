using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAPI.Models;
using WebAppAPI.DataConecton;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        [HttpGet("listar")]
        public async Task<IActionResult> GetListadoContry()
        {
            return Ok(await Task.Run(() => new CountryDA().listado()));
        }

        [HttpGet("ubicar")]
        public async Task<IActionResult> GetUbicarCountry(Int32 IdCountry)
        {
            return Ok(await Task.Run(() => new CountryDA().Ubicar(IdCountry)));
        }
        //[HttpPut("actualizar")]
        //public async Task<IActionResult> PutActualizar(Solicitud reg)
        //{
        //    return Ok(await Task.Run(() => new solicitudDLAC().actualizar(reg)));
        //}
        //[HttpPost("registrar")]
        //public async Task<IActionResult> PostRegistrar(Solicitud reg)
        //{
        //    return Ok(await Task.Run(() => new solicitudDLAC().insertar(reg)));
        //}
    }
}
