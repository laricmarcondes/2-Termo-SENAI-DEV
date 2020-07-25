using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.Db.Domains;
using Senai.SpMedGroup.WeabApi.Db.Interfaces;
using Senai.SpMedGroup.WeabApi.Db.Repositories;

namespace Senai.SpMedGroup.Db.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class ProntuarioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _prontuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IProntuarioRepository _prontuarioRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        /// <summary>
        /// Lista todos os prontuarios
        /// </summary>
        /// <returns>Uma lista de prontuarios e um status code 200 - Ok</returns>
        /// dominio/api/Prontuario
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_prontuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um prontuario através do seu ID
        /// </summary>
        /// <param name="id">ID do prontuario que será buscado</param>
        /// <returns>Um prontuario buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Prontuario/1
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _prontuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Lista todas as consultas de um usuário
        /// </summary>
        /// <returns>Uma lista de consultas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de consultas de um determinado usuário</response>
        /// <response code="400">Retorna o erro gerado com uma mensagem personalizada</response>
        /// dominio/api/Prontuario/Minhas
        [HttpGet("Minhas")]
        public IActionResult GetMy()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_prontuarioRepository.ListarMinhasConsultas(idUsuario));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    error
                });
            }
        }

        /// <summary>
        /// Cadastra um novo prontuario
        /// </summary>
        /// <param name="novoProntuario">Objeto novoProntuario que será cadastrada</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Prontuario
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Prontuario novoProntuario)
        {
            // Faz a chamada para o método .Cadastrar();
            _prontuarioRepository.Cadastrar(novoProntuario);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um prontuario existente
        /// </summary>
        /// <param name="id">ID do prontuario que será atualizado</param>
        /// <param name="prontuarioAtualizado">Objeto prontuarioAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Prontuario/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Prontuario prontuarioAtualizado)
        {
            Prontuario prontuarioBuscado = _prontuarioRepository.BuscarPorId(id);

            // Verifica se prontuarioBuscado é diferente de nulo
            if (prontuarioBuscado != null)
            {
                //Haverá uma tentativa de atulizar a especialidade
                try
                {
                    //Caso seja, o prontuario será atualizado
                    _prontuarioRepository.Atualizar(id, prontuarioAtualizado);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se prontuario não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta um prontuario
        /// </summary>
        /// <param name="id">ID do prontuario que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Prontuario/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Prontuario prontuarioBuscado = _prontuarioRepository.BuscarPorId(id);

            //Verifica se prontuarioBuscado é igual a nulo
            if (prontuarioBuscado == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta prontuario e retorna um StatusCode Accepted
            _prontuarioRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}