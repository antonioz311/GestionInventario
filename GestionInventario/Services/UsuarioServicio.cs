using GestionInventario.Models;
using GestionInventario.Repositories;

namespace GestionInventario.Services
{
    public class UsuarioServicio
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // Validar usuario
        public bool ValidarUsuario(string email, string password)
        {
            var usuario = _usuarioRepositorio.ObtenerUsuarioPorEmail(email);
            if (usuario != null && usuario.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
