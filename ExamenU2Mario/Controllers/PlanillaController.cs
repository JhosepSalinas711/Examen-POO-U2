using ExamenU2Mario.Services;
using ExamenU2Mario.Dtos.Planillas;
using Microsoft.AspNetCore.Mvc;

namespace ExamenU2Mario.Controllers
{
    [ApiController]
    [Route("api/planillas")]
    public class PlanillaController : ControllerBase
    {
        private readonly PlanillaService _service;

        public PlanillaController(PlanillaService service)
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

        [HttpGet("periodo/{periodo}")]
        public async Task<IActionResult> GetByPeriodo(string periodo)
            => Ok(await _service.GetByPeriodo(periodo));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlanillaCreateDto dto)
        {
            try { return Ok(await _service.Create(dto)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PlanillaCreateDto dto)
        {
            var ok = await _service.Update(id, dto);
            return ok ? Ok() : NotFound();
        }

        [HttpPut("{id}/estado")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] string estado)
        {
            var ok = await _service.UpdateEstado(id, estado);
            return ok ? Ok() : NotFound();
        }

        [HttpPost("generar")]
        public async Task<IActionResult> Generar([FromBody] string periodo)
        {
            try
            {
                await _service.GenerarPlanilla(periodo);
                return Ok("Planilla generada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ok = await _service.Delete(id);
                return ok ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}