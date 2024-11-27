using DTO;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IBuscarAtletaPorId
    {
        ListadoAtletasDTO Buscar(int id);

    }
}