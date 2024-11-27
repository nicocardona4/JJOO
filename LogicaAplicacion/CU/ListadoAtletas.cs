using DTO;
using DTO.Mappers;
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
    public class ListadoAtletas: IListadoAtletas
    {
        public IRepositorioAtletas Repositorio { get; set; }

        public ListadoAtletas(IRepositorioAtletas repo)
        {
            Repositorio = repo;
        }

        public IEnumerable<ListadoAtletasDTO> ObtenerListado()
        {
            IEnumerable<Atleta> atletas = Repositorio.FindAll();
            return AtletaMapper.FromAtletas(atletas);
        }

        public IEnumerable<ListadoAtletasDTO> ObtenerAtletasPorId(IEnumerable<int> ids)
        {
            List<Atleta> atletas = new List<Atleta>();
            foreach (int id in ids) 
            { 
                var atleta = Repositorio.FindById(id);
                if (atleta != null)
                {
                    atletas.Add(atleta);
                }
            }
            return AtletaMapper.FromAtletas(atletas);
        }
    }

    }

