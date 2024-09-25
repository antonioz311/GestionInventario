namespace GestionInventario.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        
        // Agregar required para que el compilador asegure que estas propiedades
        // no serán null
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string TipoDocumento { get; set; }
        public required string NumeroDocumento { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public bool EstadoActivo { get; set; }
        public required string Password { get; set; }
    }
}
