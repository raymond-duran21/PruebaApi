using Microsoft.AspNetCore.Mvc;
using WebApiTIC.Application.Contracts;
using WebApiTIC.Application.DTOs.Equipos;
using WebApiTIC.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTIC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly IEquipos equipos;

        public EquiposController(IEquipos _equipos)
        {
            equipos = _equipos;
        }

        // GET: api/<EquiposController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await equipos.GetAsync();
            return Ok(data);
        }

        // GET api/<EquiposController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var data = await equipos.GetByIdAsync(id);
            return Ok(data);
        }

        // POST api/<EquiposController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateEquiposDto equiposDto)
        {
            var result = await equipos.AddAsync(equiposDto);
            return Ok(result);
        }

        // PUT api/<EquiposController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateEquiposDto equiposDto, int id)
        {
            var result = await equipos.UpdateAsync(equiposDto, id);
            return Ok(result);
        }

        // DELETE api/<EquiposController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await equipos.DeleteAsync(id);
            return Ok(result);
        }
    }
}
