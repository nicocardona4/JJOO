using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class ParticipacionesMapper
    {
        public static Participaciones FromDTO(ParticipacionDTO dto)
        {
            Participaciones p = new Participaciones(dto.idAtleta,dto.nombrePrueba,dto.puntuacion);
            return p;
        }
    }
}
