using Dapper;
using Microsoft.Extensions.Configuration;
using SistemaClienteTeste.Data;
using SistemaClienteTeste.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClienteTeste.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            cliente.CPF = cliente.CPF.Replace(".", "").Replace("-", "");
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;
        }

        public bool Apagar(int id)
        {
            ClienteModel clienteDB = BuscarPorID(id);
            if (clienteDB == null) throw new Exception("Houve um erro ao deletar o cliente");

            _bancoContext.Clientes.Remove(clienteDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel clienteDB = BuscarPorID(cliente.Id);
            if (clienteDB == null) throw new Exception("Houve um erro na atualização do cliente");

            clienteDB.CPF = cliente.CPF.Replace(".","").Replace("-","");
            clienteDB.Nome = cliente.Nome;
            clienteDB.DataNascimento = cliente.DataNascimento;
            clienteDB.Sexo = cliente.Sexo;
            clienteDB.Cep = cliente.Cep;
            clienteDB.Logradouro = cliente.Logradouro;
            clienteDB.Cidade = cliente.Cidade;
            clienteDB.UF = cliente.UF;
            clienteDB.DataAtualizacao = cliente.DataAtualizacao;

            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();

            return clienteDB;
        }

        public ClienteModel BuscarPorID(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }     

       
    }
}
