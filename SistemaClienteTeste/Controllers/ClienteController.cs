using Microsoft.AspNetCore.Mvc;
using SistemaClienteTeste.Models;
using SistemaClienteTeste.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaClienteTeste.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio; 
        }

        public IActionResult Index()
        {
            List<ClienteModel> clientes =  _clienteRepositorio.BuscarTodos();

            return View(clientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ClienteModel cliente =  _clienteRepositorio.BuscarPorID(id);
            return View(cliente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ClienteModel cliente =  _clienteRepositorio.BuscarPorID(id);
            return View(cliente);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado =  _clienteRepositorio.Apagar(id);

                if(apagado) TempData["MensagemSucesso"] = "Cliente apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu cliente, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu cliente, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel clienteModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(clienteModel);

                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(clienteModel);
            }
            catch (Exception erro)
            { 
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu cliente, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteModel =  _clienteRepositorio.Atualizar(clienteModel);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(clienteModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu cliente, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
