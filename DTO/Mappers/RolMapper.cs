using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class RolMapper
    {
        public static RolDTO ToDTO(Rol rol)
        {
            RolDTO dto = new RolDTO() {Id = rol.Id, Nombre = rol.Nombre};
            return dto;
        }

        public static IEnumerable<RolDTO> FromRoles(IEnumerable<Rol> roles) {
            List<RolDTO> dtos = new List<RolDTO>();
            foreach (Rol rol in roles)
            {
                dtos.Add(ToDTO(rol));
            }
            return dtos;
        }
    }
}
