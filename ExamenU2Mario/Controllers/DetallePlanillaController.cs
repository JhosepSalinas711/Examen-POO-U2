using ExamenU2Mario.Services;
using ExamenU2Mario.Dtos.Detalles;
using Microsoft.AspNetCore.Mvc;

namespace ExamenU2Mario.Controllers
{
    [ApiController]
    [Route("api/detallesplanilla")]
    public class DetallePlanillaController : ControllerBase
    {
        private readonly DetallePlanillaService _service;

        public DetallePlanillaController(DetallePlanillaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetById(id);
            return data == null ? NotFound() : Ok(data);
        }

        [HttpGet("planilla/{planillaId}")]
        public async Task<IActionResult> GetByPlanilla(int planillaId)
        {
            return Ok(await _service.GetByPlanilla(planillaId));
        }

        [HttpGet("empleado/{empleadoId}")]
        public async Task<IActionResult> GetByEmpleado(int empleadoId)
        {
            return Ok(await _service.GetByEmpleado(empleadoId));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetallePlanillaCreateDto dto)
        {
            try
            {
                var data = await _service.Create(dto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DetallePlanillaCreateDto dto)
        {
            try
            {
                var ok = await _service.Update(id, dto);
                return ok ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.Delete(id);
            return ok ? Ok() : NotFound();
        }
    }
}