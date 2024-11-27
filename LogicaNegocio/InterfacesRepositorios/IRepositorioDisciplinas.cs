﻿using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioDisciplinas: IRepositorio<Disciplina>
    {
        Disciplina BuscarPorNombre(string nombre);

        Disciplina BuscarPorCodigo(int codigo);


    }
}
