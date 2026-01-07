using Aplication.DTOs;
using Aplication.UseCases;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly AgregarMedicamento _crearMedicamento;
        private readonly IMapper _mapper;

        public MedicamentoController(AgregarMedicamento crearMedicamento, IMapper mapper)
        {
            _crearMedicamento = crearMedicamento;
            _mapper = mapper;
        }

        // POST: api/Medicamento
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MedicamentoDTOs medicamentoDTO)
        {
            try
            {
                var medicamento = _mapper.Map<Medicamento>(medicamentoDTO);

                await _crearMedicamento.EjecutarAsync(medicamento);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = medicamento.Id },
                    medicamentoDTO
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // GET: api/Medicamento/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            // Aquí implementarías la búsqueda por ID real usando el repo
            return Ok();

        }
        [HttpGet("vencidos")]
        public async Task<IActionResult> GetVencidos([FromServices] ObtenerMedicamentosVencidos useCase)
        {
            var resultado = await useCase.EjecutarAsync();
            return Ok(resultado);
        }

        [HttpGet("stock-bajo/{limite}")]
        public async Task<IActionResult> GetBajoStock(int limite, [FromServices] ObtenerBajoStock useCase)
        {
            var resultado = await useCase.EjecutarAsync(limite);
            return Ok(resultado);
        }
    }

}
