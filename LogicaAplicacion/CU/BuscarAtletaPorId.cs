using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class BuscarAtletaPorId : IBuscarAtletaPorId
    {
        public IRepositorioAtletas Repo { get; set; }

        public BuscarAtletaPorId(IRepositorioAtletas repo)
        {
            Repo = repo;
        }

        public ListadoAtletasDTO Buscar(int id)
        {
            return AtletaMapper.ToDTO(Repo.FindById(id));
        }

        public void Borrar(int id)
        {
            Repo.Remove(id);
        }
    }
}

