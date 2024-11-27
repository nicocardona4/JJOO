using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AltaUsuarioDTO
    {
        [Required(ErrorMessage = "El mail es campo obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        [Required(ErrorMessage = "La contraseña es campo obligatorio")]
        public string Contrasenia { get; set; }

        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        public string Admin;

        public DateTime FechaRegistro { get; set; }
    }
}
