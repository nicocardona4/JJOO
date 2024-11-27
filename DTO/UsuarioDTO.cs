using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "El mail es campo obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Rol")]
        public int IdRol { get; set; }

    }
}
