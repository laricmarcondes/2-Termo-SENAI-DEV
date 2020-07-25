using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

    public class PresencaController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _presencaRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IPresencaRepository _presencaRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public PresencaController()
        {
            _presencaRepository = new PresencaRepository();
        }

        /// <summary>
        /// Lista todos as presencas
        /// </summary>
        /// <returns>Uma lista de presencas e um status code 200 - Ok</returns>
        /// dominio/api/Presenca
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_presencaRepository.Listar());
        }

        /// <summary>
        /// Busca uma  através do seu ID
        /// </summary>
        /// <param name="id">ID da presenca que será buscada</param>
        /// <returns>Uma presenca buscada ou NotFound caso nenhuma seja encontrado</returns>
        /// dominio/api/Presenca/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _presencaRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Lista todas as presenças de um determinado usuário
        /// </summary>
        /// <returns>Uma lista de presenças e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de presenças de um determinado usuário</response>
        /// <response code="400">Retorna o erro gerado com uma mensagem personalizada</response>
        /// dominio/api/Presencas/Minhas
        [HttpGet("Minhas")]
        public IActionResult GetMy()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_presencaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!",
                    error
                });
            }
        }

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="id">ID da presença que terá a situação alterada</param>
        /// <param name="status">Objeto com o parâmetro que atualiza o situação da presença para Confirmada, Não confirmada ou Recusada</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Presencas/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca status)
        {
            try
            {
                // Faz a chamada para o método
                _presencaRepository.AprovarRecusar(id, status.Situacao);

                // Retora a resposta da requisição 200 - Ok
                return StatusCode(200);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Convida um usuário para um evento
        /// </summary>
        /// <param name="convite">Objeto com as informações da nova presença</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Presencas/Convidar
        [HttpPost("Convidar")]
        public IActionResult Invite(Presenca convite)
        {
            try
            {
                // Faz a chamada para o método
                _presencaRepository.Convidar(convite);

                // Retora a resposta da requisição 201 - Created
                return StatusCode(201);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Inscreve o usuário logado em um evento
        /// </summary>
        /// <param name="idEvento">ID do evento que o usuário irá se inscrever</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado com uma mensagem personalizada</response>
        /// dominio/api/Presencas/Inscricao/idEvento
        [HttpPost("Inscricao/{idEvento}")]
        public IActionResult Join(int idEvento)
        {
            try
            {
                Presenca inscricao = new Presenca()
                {
                    // Armazena na propriedade IdUsuario da presenca recebida o ID do usuário logado
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),
                    // Armazena na propriedade IdEvento o ID do evento recebido pela URL
                    IdEvento = idEvento,
                    // Define a situação da presença como "Não confirmada"
                    Situacao = "Não confirmada"
                };

                // Faz a chamada para o método
                _presencaRepository.Inscrever(inscricao);

                // Retora a resposta da requisição 201 - Created
                return StatusCode(201);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível se inscrever se o usuário não estiver logado!",
                    error
                });
            }
        }

        /// <summary>
        /// Deleta uma presenca
        /// </summary>
        /// <param name="id">ID da presenca que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Presenca/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Presenca presencaBuscada = _presencaRepository.BuscarPorId(id);

            //Verifica se presencaBuscada é igual a nulo
            if (presencaBuscada == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta a instituicao e retorna um StatusCode Accepted
            _presencaRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}