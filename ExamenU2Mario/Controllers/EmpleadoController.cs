using ExamenU2Mario.Services;
using ExamenU2Mario.Dtos.Empleados;
using Microsoft.AspNetCore.Mvc;

namespace ExamenU2Mario.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _service;

        public EmpleadoController(EmpleadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetById(id);
            return data == null ? NotFound() : Ok(data);
        }

        [HttpGet("activos")]
        public async Task<IActionResult> GetActivos()
            => Ok(await _service.GetActivos());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpleadoCreateDto dto)
        {
            try { return Ok(await _service.Create(dto)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmpleadoCreateDto dto)
        {
            try
            {
                var ok = await _service.Update(id, dto);
                return ok ? Ok() : NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.Delete(id);
            return ok ? Ok() : NotFound();
        }
    }
}