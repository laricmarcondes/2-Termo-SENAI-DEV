using System;
using System.Collections.Generic;
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

    public class EnderecoClinicaController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _enderecoClinicaRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEnderecoClinicaRepository _enderecoClinicaRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EnderecoClinicaController()
        {
            _enderecoClinicaRepository = new EnderecoClinicaRepository();
        }

        /// <summary>
        /// Lista todos os endereços da clinica
        /// </summary>
        /// <returns>Uma lista de endereços das clinicas e um status code 200 - Ok</returns>
        /// dominio/api/EnderecoClinica
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_enderecoClinicaRepository.Listar());
        }

        /// <summary>
        /// Busca um endereco de clinica através do seu ID
        /// </summary>
        /// <param name="id">ID do endereco da clinica que será buscado</param>
        /// <returns>Um endereco da clinica buscada ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/EnderecoClinica/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _enderecoClinicaRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novoEnderecoClinica">Objeto novoEnderecoClinica que será cadastrada</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/EnderecoClinica
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(EnderecoClinica novoEnderecoClinica)
        {
            // Faz a chamada para o método .Cadastrar();
            _enderecoClinicaRepository.Cadastrar(novoEnderecoClinica);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um endereco de clinica existente
        /// </summary>
        /// <param name="id">ID do endereco da clinica que será atualizada</param>
        /// <param name="enderecoClinicaAtualizado">Objeto enderecoClinicaAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/EnderecoClinica/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, EnderecoClinica enderecoClinicaAtualizado)
        {
            EnderecoClinica enderecoClinicaBuscado = _enderecoClinicaRepository.BuscarPorId(id);

            // Verifica se enderecoClinicaBuscada é diferente de nulo
            if (enderecoClinicaBuscado != null)
            {
                //Haverá uma tentativa de atulizar o endereço da clinica
                try
                {
                    //Caso seja, o endereco da clinica será atualizado
                    _enderecoClinicaRepository.Atualizar(id, enderecoClinicaAtualizado);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se endereco de clinica não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta um endereco de clinica
        /// </summary>
        /// <param name="id">ID do endereco da clinica que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/EnderecoClinica/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EnderecoClinica enderecoClinicaBuscado = _enderecoClinicaRepository.BuscarPorId(id);

            //Verifica se enderecoClinicaBuscado é igual a nulo
            if (enderecoClinicaBuscado == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta o endereco da clinica e retorna um StatusCode Accepted
            _enderecoClinicaRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}