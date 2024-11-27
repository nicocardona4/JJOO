using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class AsignarDisciplinaAtleta : IAsignarDisciplinaAtleta
    {
        public IRepositorioAtletas Repo { get; set; }

        public AsignarDisciplinaAtleta(IRepositorioAtletas repo)
        {
            Repo = repo;
        }


        public Atleta AsignarDisciplina(AsignarDisciplinasAtletaDTO dto)
        {
            // Buscar al atleta directamente desde el repositorio.
            Atleta atl = Repo.FindById(dto.dtoAtleta.Id);

            if (atl == null)
            {
                throw new KeyNotFoundException("El atleta no existe.");
            }

            // Verificar si la disciplina ya está asignada.
            bool yaAsignada = atl._disciplinas.Any(d => d.Id == dto.IdDisciplina);
            if (yaAsignada)
            {
                throw new DisciplinaInvalidaException("El atleta ya tiene asignada la disciplina.");
            }

            // Asignar la disciplina.
            Repo.AsignarDiscplina(atl.Id, dto.IdDisciplina);

            return atl;
        }

    }
}
