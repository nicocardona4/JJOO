using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class DisciplinaMapper
    {
        public static Disciplina FromDTO(AltaDisciplinaDTO dto)
        {
            if (dto != null)
            {
                NombreDisciplina nombreDisciplina = new NombreDisciplina(dto.NombreDisciplina);
                Codigo cod = new Codigo(dto.Codigo);
                Anio a = new Anio(dto.Anio);
                Disciplina dis = new Disciplina(nombreDisciplina,a ,cod);
                return dis;
            }

            return null;
        }

        public static Disciplina FromListado(ListadoDisciplinasDTO dto)
        {
            if (dto != null)
            {
                NombreDisciplina nombreDisciplina = new NombreDisciplina(dto.Nombre);
                Codigo cod = new Codigo(dto.Codigo);
                Anio a = new Anio(dto.Anio);
                Disciplina dis = new Disciplina(nombreDisciplina, a, cod);
                return dis;
            }

            return null;
        }

        public static ListadoDisciplinasDTO FromDisciplina(Disciplina d)
        {
            ListadoDisciplinasDTO dto = new ListadoDisciplinasDTO()
            {
                Id = d.Id,
                Nombre = d.NombreDisciplina.Valor,
                Anio = d.Anio.Valor,
                Codigo = d.Codigo.Valor,
                Atletas = d._atletas.Select(d => d.Apellido).ToList(),
            };
            return dto;
        }

        public static IEnumerable<ListadoDisciplinasDTO> FromDisciplinas(IEnumerable<Disciplina> disciplinas)
        {
            List<ListadoDisciplinasDTO> dtos = new List<ListadoDisciplinasDTO>();
            foreach (Disciplina d in disciplinas)
            {
                dtos.Add(FromDisciplina(d));
            }
            return dtos;
        }
    }
}
