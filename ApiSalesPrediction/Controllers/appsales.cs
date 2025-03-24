using ApiSalesPrediction.model;
using ApiSalesPrediction.Negocio;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using models.models;

namespace ApiSalesPrediction.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class appsales : ControllerBase  
    {
        private readonly SalesNegocio _context;

        public appsales(SalesNegocio negocio) { 
            this._context = negocio;
        }

        [HttpGet("ventasporcliente")]
        public Task<response> ventasporcliente(int CustomerID)
        {
            return _context.ventasporcliente(CustomerID);
        }

        [HttpGet("{spNombre}")]
        public async Task<ActionResult<List<Dictionary<string, object>>>> ObtenerDatos(string spNombre)
        {
            var datos = await _context.ObtenerDatosDinamicos(spNombre,null);
            return Ok(datos);
        }

        [HttpPost("{spNombre}")]
        public async Task<IActionResult> EjecutarSP(string spNombre, [FromBody] Dictionary<string, object> parametros)
        {
            try
            {
                var resultado = await _context.ObtenerDatosDinamicos(spNombre, parametros);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error en la ejecución", error = ex.Message });
            }
        }
    }
}
