using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTIC.Application.Contracts;
using WebApiTIC.Application.DTOs.Asignaciones;
using WebApiTIC.Application.DTOs.Equipos;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesController : ControllerBase
    {
        private readonly IAsignaciones asignaciones;

        public AsignacionesController(IAsignaciones _asignaciones)
        {
            asignaciones = _asignaciones;
        }

        // GET: api/<EquiposController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await asignaciones.GetASync();
            return Ok(data);
        }

        // GET api/<EquiposController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var data = await asignaciones.GetByIdAsync(id);
            return Ok(data);
        }

        // POST api/<EquiposController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAsignacionDto asignacionesDto)
        {
            var result = await asignaciones.AddASync(asignacionesDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await asignaciones.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("ByCedula/{cedula}")]
        public async Task<IActionResult> GetByCedula(string cedula)
        {
            var result = await asignaciones.GetByCedulaAsync(cedula);
            return Ok(result);
        }
    }
}
