namespace PruebaTecnicaSMX.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre de Usuario es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string CorreoElectronico { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
