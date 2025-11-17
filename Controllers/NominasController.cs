using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Nomisoft.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NominasController : ControllerBase
    {
        private readonly Conexion _conexion = new Conexion();

        // GET api/nominas?estado=Por%20liquidar
        [HttpGet]
        public IActionResult GetByEstado([FromQuery] string estado = "Por liquidar")
        {
            var dt = _conexion.ObtenerResumenNominasTablaPorEstado(estado);
            var list = dt.AsEnumerable()
                .Select(r => new {
                    Numero_Documento = r.Field<string>("Numero_Documento"),
                    Periodo = r.Field<string>("Periodo"),
                    Neto_Pagar = r.Field<object>("Neto_Pagar"),
                    Estado = r.Table.Columns.Contains("Estado") ? r.Field<object>("Estado") : null
                }).ToList();
            return Ok(list);
        }

        // GET api/nominas/{numero}/{periodo}
        [HttpGet("{numero}/{periodo}")]
        public IActionResult GetNomina(string numero, string periodo)
        {
            var n = _conexion.Buscar_Nomina(numero, periodo);
            if (n == null) return NotFound();
            return Ok(n);
        }

        // PUT api/nominas
        [HttpPut]
        public IActionResult Update([FromBody] Conexion.Nomina nomina)
        {
            try
            {
                _conexion.Editar_Nomina(nomina);
                return NoContent();
            }
            catch (System.Exception ex) { return BadRequest(ex.Message); }
        }
    }
}