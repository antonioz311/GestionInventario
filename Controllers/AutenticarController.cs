using GestionInventario.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        private readonly UsuarioServicio _usuarioServicio;

        public AutenticarController(UsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpPost("ValidarUsuario")]
        public ActionResult ValidarUsuario([FromBody] dynamic data)
        {
            string email = data.email;
            string password = data.password;

            bool esValido = _usuarioServicio.ValidarUsuario(email, password);

            if (esValido)
            {
                // Ahora obtenemos el usuario desde el servicio
                var usuario = _usuarioServicio.ObtenerUsuarioPorEmail(email);
                return Ok(new
                {
                    autenticacionExitosa = true,
                    jwt = Guid.NewGuid().ToString(),
                    mensaje = $"Bienvenido {usuario.Nombre} {usuario.Apellido}"
                });
            }

            return BadRequest(new
            {
                autenticacionExitosa = false,
                jwt = (string)null,
                mensaje = "Error al autenticar el usuario."
            });
        }
    }
}