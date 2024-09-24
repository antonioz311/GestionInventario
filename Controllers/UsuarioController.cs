using GestionInventario.Models;
using GestionInventario.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("GetByEmail/{email}")]
        public ActionResult<Usuario> GetByEmail(string email)
        {
            var usuario = _usuarioRepositorio.ObtenerUsuarioPorEmail(email);
            if (usuario == null)
            {
                return NotFound(new { Message = "Usuario no encontrado." });
            }
            return Ok(usuario);
        }

        [HttpGet("GetAllUsers")]
        public ActionResult<List<Usuario>> GetAllUsers()
        {
            return Ok(_usuarioRepositorio.ObtenerUsuarios());
        }

        [HttpPost("CrearUsuario")]
        public ActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.CrearUsuario(usuario);
                return Ok(new { Message = "Usuario creado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("ModificarUsuario")]
        public ActionResult ModificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.ModificarUsuario(usuario);
                return Ok(new { Message = "Usuario modificado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("CambiarEstadoUsuario/{id}/{estado}")]
        public ActionResult CambiarEstadoUsuario(int id, bool estado)
        {
            try
            {
                _usuarioRepositorio.CambiarEstadoUsuario(id, estado);
                return Ok(new { Message = "Estado del usuario modificado." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
