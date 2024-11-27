using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObject;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class AtletaMapper
    {
        public static ListadoAtletasDTO FromAtleta(Atleta atl)
        {
            ListadoAtletasDTO dto = new ListadoAtletasDTO()
            {
                Id = atl.Id,
                Nombre = atl.Nombre,
                Apellido = atl.Apellido,
                Pais = atl.Pais.Nombre,
                Disciplinas = atl._disciplinas.Select(atl => atl.NombreDisciplina.Valor).ToList(),
            };

            return dto;
        }

        public static IEnumerable<ListadoAtletasDTO> FromAtletas(IEnumerable<Atleta> atletas)
        {
            List<ListadoAtletasDTO> dtos = new List<ListadoAtletasDTO>();

            foreach (Atleta atl in atletas)
            {
                dtos.Add(FromAtleta(atl));
            }

            return dtos;
        }

        public static Atleta FromDTO(AsignarDisciplinasAtletaDTO dto)
        {

            //if (dto != null)
            //Disciplina d = new Disciplina();
            //    Atleta a = new Atleta(dto.dtoAtleta.Nombre, dto.dtoAtleta.Apellido, dto.dtoAtleta.Sexo, dto.dtoAtleta.Pais, dto.dtoAtleta.Disciplinas);
            //    return a;
            //}

            return null;
        }

        public static ListadoAtletasDTO ToDTO(Atleta a)// SE USA PARA BUSCAR USU POR ID
        {
            ListadoAtletasDTO dto = null;

            if (a != null)
            {

                dto = new ListadoAtletasDTO()
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Apellido = a.Apellido,
                    Sexo = a.Sexo,
                    Pais = a.Pais.Nombre,
                    // Mapear cada Disciplina a su nombre (string)
                    Disciplinas = a._disciplinas.Select(a => a.NombreDisciplina.Valor).ToList()
                };
            }

            return dto;
        }
    }
}
