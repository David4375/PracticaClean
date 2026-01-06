using Aplication.DTOs;
using Aplication.UseCases;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioRepo;
        private readonly CrearUsuario _crearUsuario;
        private readonly IMapper _mapper;

        public UsuarioController(
            IUsuario usuarioRepo,
            CrearUsuario crearUsuario,
            IMapper mapper)
        {
            _usuarioRepo = usuarioRepo;
            _crearUsuario = crearUsuario;
            _mapper = mapper;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioRepo.All();

            if (!usuarios.Any())
            {
                return NotFound(new { mensaje = "No hay usuarios registrados." });
            }

            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDTOs>>(usuarios);
            return Ok(usuariosDto);
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var usuario = await _usuarioRepo.ObtenerId(id);

            if (usuario == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado." });
            }

            var usuarioDto = _mapper.Map<UsuarioDTOs>(usuario);
            return Ok(usuarioDto);
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioDTOs usuarioDTO)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDTO);
                await _crearUsuario.EjecutarAsync(usuario);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = usuario.Id },
                    usuarioDTO
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}