using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using Senai.Senatur.WebApi.DatabaseFirst.Interfaces;
using Senai.Senatur.WebApi.DatabaseFirst.Repositories;

namespace Senai.Senatur.WebApi.DatabaseFirst.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    [Authorize]
    public class PacotesController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _pacotesRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IPacoteRepository _pacotesRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public PacotesController()
        {
            _pacotesRepository = new PacoteRepository();
        }

        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns>Uma lista de pacotes e um status code 200 - Ok</returns>
        /// dominio/api/Pacotes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacotesRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="novoPacote">Objeto novoPacote que será cadastrado</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Pacotes
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            // Faz a chamada para o método .Cadastrar();
            _pacotesRepository.Cadastrar(novoPacote);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Busca um pacote através do seu ID
        /// </summary>
        /// <param name="id">ID do pacote que será buscado</param>
        /// <returns>Um pacote buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Pacotes/1
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return Ok(_pacotesRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza um pacote existente
        /// </summary>
        /// <param name="id">ID do pacote que será atualizado</param>
        /// <param name="pacoteAtualizado">Objeto pacoteAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Pacotes/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacotes pacoteAtualizado)
        {
            // Faz a chamada para o método .Atualizar();
            _pacotesRepository.Atualizar(id, pacoteAtualizado);

            // Retorna um status code 204 - No Content
            return NoContent();
        }

        /// <summary>
        /// Deleta um pacote
        /// </summary>
        /// <param name="id">ID do pacote que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Pacotes/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Faz uma chamada para o método .Deletar()
            _pacotesRepository.Deletar(id);

            // Retorna um status code 200 - Ok com uma mensagem de sucesso
            return Ok("O pacote foi deletado com sucesso");
        }

        /// <summary>
        /// Busca os pacotes ativos e não ativos ao digitar 'true' ou 'false' no final da url
        /// </summary>
        /// <param name="pacotesAtivos"></param>
        /// <returns>Uma lista dos pacotes ativos e não ativos ao digitar 'true' ou 'false' no final da url</returns>
        [Authorize(Roles = "1")]
        [HttpGet("Ativos/{pacotesAtivos}")]
        public IActionResult PacotesAtivos(bool pacotesAtivos)
        {
            // Retorna a lista e um status code 200 - Ok
            return Ok(_pacotesRepository.PacotesAtivos(pacotesAtivos));
        }

        /// <summary>
        /// Lista todos os pacotes de acordo com a cidade buscada
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Uma lista dos pacotes de acordo com a cidade desejada</returns>
        [HttpGet("Cidades/{cidade}")]
        [Authorize(Roles = "1")]
        public IActionResult PacotesCidades(string cidade)
        {
            // Retorna a lista e um status code 200 - Ok
            return Ok(_pacotesRepository.ListarPorCidade(cidade));
        }

        /// <summary>
        /// Ordena todos os pacotes em ordem crescente ou decrescente
        /// </summary>
        /// <param name="ordem"> a ordem em que os pacotes serão listados</param>
        /// <returns>Uma lista dos pacotes de acordo com o desejado</returns>
        [HttpGet("Ordenacao/{ordem}")]
        [Authorize(Roles = "1")]
        public IActionResult GetOrderBy(string ordem)
        {
            // Verifica se os pacotes foram encontrados
            if (ordem != "ASC" && ordem != "DESC")
            {
                // Caso não seja, retorna um BadRequest com uma mensagem
                return BadRequest("Não foi possível ordenar os pacotes. Por favor insira ASC ou DESC na URL");
            }

            // Caso seja, retorna a lista e um status code 200 - Ok
            return Ok(_pacotesRepository.ListarOrdenado(ordem));
        }
    }
}