using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Proyecto_Nomisoft.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly Conexion _conexion = new Conexion();

        // GET api/empleados
        [HttpGet]
        public IActionResult Get([FromQuery] string departamento = null, [FromQuery] string salarioRange = null)
        {
            var dt = _conexion.ObtenerResumenEmpleados(departamento: null, documento: null, departamento: departamento, cargo: null, estadoCivil: null, salarioRange: salarioRange);
            var list = dt.AsEnumerable()
                .Select(r => new {
                    Nombre = r.Field<string>("Nombre"),
                    Documento = r.Field<string>("Documento"),
                    Cargo = r.Field<string>("Cargo"),
                    Salario = r.Field<object>("Salario"),
                    Estado = r.Field<object>("Estado")
                }).ToList();
            return Ok(list);
        }

        // GET api/empleados/{numero}
        [HttpGet("{numero}")]
        public IActionResult GetOne(string numero)
        {
            var emp = _conexion.Buscar_Empleado(numero);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        // POST api/empleados
        [HttpPost]
        public IActionResult Create([FromBody] Conexion.Empleado empleado)
        {
            // Basic validation omitted for brevity
            try
            {
                _conexion.Agregar_Empleado(
                    empleado.Primer_Nombre, empleado.Segundo_Nombre, empleado.Primer_Apellido, empleado.Segundo_Apellido,
                    empleado.Tipo_Documento, empleado.Numero_Documento, empleado.Fecha_Nacimiento ?? System.DateTime.Now,
                    empleado.Telefono, empleado.Correo, empleado.Direccion, empleado.Estado_Civil,
                    empleado.Numero_Hijos ?? 0, empleado.Cargo, empleado.Departamento, empleado.Fecha_Ingreso ?? System.DateTime.Now,
                    empleado.Tipo_Contrato, empleado.Salario_Base?.ToString(), empleado.Estado);
                return CreatedAtAction(nameof(GetOne), new { numero = empleado.Numero_Documento }, empleado);
            }
            catch (System.Exception ex) { return BadRequest(ex.Message); }
        }
    }
}