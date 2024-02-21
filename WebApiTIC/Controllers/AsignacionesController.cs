using Microsoft.AspNetCore.Mvc;
using WebApiTIC.Application.Contracts;
using WebApiTIC.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<AsignacionesController>
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var data = await asignaciones.GetAsync();
            return Ok(data);
        }


    }
}
