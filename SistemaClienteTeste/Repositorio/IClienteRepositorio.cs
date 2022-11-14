using SistemaClienteTeste.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaClienteTeste.Repositorio
{
    public interface IClienteRepositorio
    {
        List<ClienteModel> BuscarTodos();
        ClienteModel BuscarPorID(int id);
        ClienteModel Adicionar(ClienteModel cliente);
        ClienteModel Atualizar(ClienteModel cliente);
        bool Apagar (int id);
    }
}
