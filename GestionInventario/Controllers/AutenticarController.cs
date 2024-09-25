using Microsoft.AspNetCore.Mvc;
using GestionInventario.Models;
using GestionInventario.Services;

namespace GestionInventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticarController : ControllerBase
    {
        private readonly UsuarioServicio _usuarioServicio;

        public AutenticarController(UsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpPost("validarUsuario")]
        public IActionResult ValidarUsuario([FromBody] Usuario usuario)
        {
            var usuarioValido = _usuarioServicio.ValidarUsuario(usuario.NumeroDocumento, usuario.Password);

            if (usuarioValido)
            {
                var jwt = Guid.NewGuid().ToString(); // Simulando el JWT
                return Ok(new
                {
                    AutenticacionExitosa = true,
                    Jwt = jwt,
                    Mensaje = $"Bienvenido {usuario.Nombre} {usuario.Apellido}"
                });
            }

            return Unauthorized(new
            {
                AutenticacionExitosa = false,
                Jwt = string.Empty,
                Mensaje = "Error al autenticar el usuario."
            });
        }
    }
}
