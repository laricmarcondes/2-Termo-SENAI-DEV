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

    public class TiposEventoController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _tipoEventoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private ITipoEventoRepository _tipoEventoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public TiposEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Lista todos os tipos eventos
        /// </summary>
        /// <returns>Uma lista de tipos eventos e um status code 200 - Ok</returns>
        /// dominio/api/TipoEvento
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_tipoEventoRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo evento através do seu ID
        /// </summary>
        /// <param name="id">ID do tipo evento que será buscado</param>
        /// <returns>Um tipo evento buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/TipoEvento/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _tipoEventoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto novoTipoEvento que será cadastrado</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/TipoEvento
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            // Faz a chamada para o método .Cadastrar();
            _tipoEventoRepository.Cadastrar(novoTipoEvento);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo evento existente
        /// </summary>
        /// <param name="id">ID do tipo evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Objeto tipoEventoAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/TipoEvento/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoEvento tipoEventoAtualizado)
        {
            TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

            // Verifica se tipoEventoBuscado é diferente de nulo
            if (tipoEventoBuscado != null)
            {
                //Haverá uma tentativa de atulizar o tipo evento
                try
                {
                    //Caso seja, o tipoEvento será atualizado
                    _tipoEventoRepository.Atualizar(id, tipoEventoAtualizado);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            //Se tipoEvento não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta um tipoEvento
        /// </summary>
        /// <param name="id">ID do tipoEvento que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/TipoEvento/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

            //Verifica se tipoEventoBuscado é igual a nulo
            if (tipoEventoBuscado == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta o tipoEvento e retorna um StatusCode Accepted
            _tipoEventoRepository.Deletar(id);

            return StatusCode(202);
        }

        /// <summary>
        /// Lista todos os tipos evento com os eventos
        /// </summary>
        /// <returns>Uma lista de tipos evento</returns>
        [Authorize(Roles = "1")]
        [HttpGet("Evento")]
        public IActionResult GetTipoEvento()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoEventoRepository.ListarComEvento());
        }
    }
}