using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class EventoController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _eventosRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEventoRepository _eventoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Uma lista de eventos e um status code 200 - Ok</returns>
        /// dominio/api/Evento
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_eventoRepository.Listar());
        }

        /// <summary>
        /// Busca um evento através do seu ID
        /// </summary>
        /// <param name="id">ID do evento que será buscado</param>
        /// <returns>Um evento buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Evento/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _eventoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto novoEvento que será cadastrado</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Evento
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Evento novoEvento)
        {
            // Faz a chamada para o método .Cadastrar();
            _eventoRepository.Cadastrar(novoEvento);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será atualizado</param>
        /// <param name="eventoAtualizado">Objeto eventoAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Evento/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento eventoAtualizado)
        {
            Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

            // Verifica se eventoBuscado é diferente de nulo
            if (eventoBuscado != null)
            {
                //Haverá uma tentativa de atulizar o evento
                try
                {
                    //Caso seja, o evento será atualizado
                    _eventoRepository.Atualizar(id, eventoAtualizado);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se evento não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
         }

        /// <summary>
        /// Deleta um evento
        /// </summary>
        /// <param name="id">ID do evento que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Evento/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

            //Verifica se eventoBuscado é igual a nulo
            if (eventoBuscado == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta o evento e retorna um StatusCode Accepted
            _eventoRepository.Deletar(id);

            return StatusCode(202);
        }

        /// <summary>
        /// Lista todos os eventos com as presencas
        /// </summary>
        /// <returns>Uma lista de eventos</returns>
        [Authorize(Roles = "1")]
        [HttpGet("Presenca")]
        public IActionResult GetEvento()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_eventoRepository.ListarComPresenca());
        }
    }
}