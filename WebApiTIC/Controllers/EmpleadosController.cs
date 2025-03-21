﻿using Microsoft.AspNetCore.Mvc;
using WebApiTIC.Application.Contracts;
using WebApiTIC.Application.DTOs.Empleados;
using WebApiTIC.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTIC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleados empleados;

        public EmpleadosController(IEmpleados _empleados)
        {
            empleados = _empleados;
        }

        // GET: api/<EquiposController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await empleados.GetAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var data = await empleados.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreacionEmpleadosDto empleadosDto)
        {
            var result = await empleados.AddAsync(empleadosDto);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateEmpleadosDto empleadosDto, int id)
        {
            var result = await empleados.UpdateAsync(empleadosDto, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await empleados.DeleteAsync(id);
            return Ok(result);
        }
    }
}
