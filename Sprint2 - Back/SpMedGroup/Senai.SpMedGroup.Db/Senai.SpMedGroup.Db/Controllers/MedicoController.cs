using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
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

    public class MedicoController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _medicoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IMedicoRepository _medicoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>Uma lista de medicos e um status code 200 - Ok</returns>
        /// dominio/api/Medico
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_medicoRepository.Listar());
        }

        /// <summary>
        /// Busca um medico através do seu ID
        /// </summary>
        /// <param name="id">ID do medico que será buscado</param>
        /// <returns>Um medico buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Medico/1
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _medicoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Lista todas as consultas de um usuário
        /// </summary>
        /// <returns>Uma lista de consultas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de consultas de um determinado usuário</response>
        /// <response code="400">Retorna o erro gerado com uma mensagem personalizada</response>
        /// dominio/api/Medico/Minhas
        [HttpGet("Minhas")]
        public IActionResult GetMy()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_medicoRepository.ListarMinhasConsultas(idUsuario));
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
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico que será cadastrada</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Medico
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            // Faz a chamada para o método .Cadastrar();
            _medicoRepository.Cadastrar(novoMedico);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um medico existente
        /// </summary>
        /// <param name="id">ID do medico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto medicoAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Medico/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico medicoAtualizado)
        {
            Medico medicoBuscado = _medicoRepository.BuscarPorId(id);

            // Verifica se medicoBuscado é diferente de nulo
            if (medicoBuscado != null)
            {
                //Haverá uma tentativa de atulizar a especialidade
                try
                {
                    //Caso seja, o medico será atualizado
                    _medicoRepository.Atualizar(id, medicoAtualizado);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se medico não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta um medico
        /// </summary>
        /// <param name="id">ID do medico que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Medico/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Medico medicoBuscado = _medicoRepository.BuscarPorId(id);

            //Verifica se medicoBuscado é igual a nulo
            if (medicoBuscado == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta medico e retorna um StatusCode Accepted
            _medicoRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}