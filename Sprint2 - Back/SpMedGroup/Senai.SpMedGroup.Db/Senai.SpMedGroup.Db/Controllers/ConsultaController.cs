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

    public class ConsultaController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _consultaRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IConsultaRepository _consultaRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Uma lista de consultas e um status code 200 - Ok</returns>
        /// dominio/api/Consulta
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_consultaRepository.Listar());
        }

        /// <summary>
        /// Busca uma consulta através do seu ID
        /// </summary>
        /// <param name="id">ID da consulta que será buscada</param>
        /// <returns>Uma consulta buscada ou NotFound caso nenhuma seja encontrada</returns>
        /// dominio/api/Consulta/1
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _consultaRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Lista todas as consultas de um determinado usuário
        /// </summary>
        /// <returns>Uma lista de consultas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de consultas de um determinado usuário</response>
        /// <response code="400">Retorna o erro gerado com uma mensagem personalizada</response>
        /// dominio/api/Consulta/Minhas
        [Authorize(Roles = "1")]
        [HttpGet("Consultas")]
        public IActionResult GetAppointment()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_consultaRepository.ListarConsultasCompletas(idUsuario));
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
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta que será cadastrada</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Consulta
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            // Faz a chamada para o método .Cadastrar();
            _consultaRepository.Cadastrar(novaConsulta);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="id">ID da consulta que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto consultaAtualizada que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Consulta/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);

            // Verifica se clinicaBuscada é diferente de nulo
            if (consultaBuscada != null)
            {
                //Haverá uma tentativa de atulizar a clinica
                try
                {
                    //Caso seja, a consulta será atualizada
                    _consultaRepository.Atualizar(id, consultaAtualizada);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se consulta não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="id">ID da consulta que será deletada</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Consulta/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Consulta clinicaBuscada = _consultaRepository.BuscarPorId(id);

            //Verifica se consultaBuscada é igual a nulo
            if (clinicaBuscada == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta a consulta e retorna um StatusCode Accepted
            _consultaRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}