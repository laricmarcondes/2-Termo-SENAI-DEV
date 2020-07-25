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

    public class EnderecoProntuarioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _enderecoProntuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEnderecoProntuarioRepository _enderecoProntuarioRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EnderecoProntuarioController()
        {
            _enderecoProntuarioRepository = new EnderecoProntuarioRepository();
        }

        /// <summary>
        /// Lista todos os endereços do prontuario
        /// </summary>
        /// <returns>Uma lista de endereços dos prontuarios e um status code 200 - Ok</returns>
        /// dominio/api/Enderecoprontuario
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_enderecoProntuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um endereco de prontuario através do seu ID
        /// </summary>
        /// <param name="id">ID do endereco do prontuario que será buscado</param>
        /// <returns>Um endereco do prontuario buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/EnderecoProntuario/1
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _enderecoProntuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo prontuario
        /// </summary>
        /// <param name="novoEnderecoProntuario">Objeto novoEnderecoProntuario que será cadastrada</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/EnderecoProntuario
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(EnderecoProntuario novoEnderecoProntuario)
        {
            // Faz a chamada para o método .Cadastrar();
            _enderecoProntuarioRepository.Cadastrar(novoEnderecoProntuario);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um endereco de prontuario existente
        /// </summary>
        /// <param name="id">ID do endereco do protuario que será atualizado</param>
        /// <param name="enderecoProntuarioAtualizado">Objeto enderecoClinicaAtualizada que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/EnderecoProntuario/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, EnderecoProntuario enderecoProntuarioAtualizado)
        {
            EnderecoProntuario enderecoProntuarioBuscado = _enderecoProntuarioRepository.BuscarPorId(id);

            // Verifica se enderecoProntuarioBuscado é diferente de nulo
            if (enderecoProntuarioBuscado != null)
            {
                //Haverá uma tentativa de atulizar o endereço
                try
                {
                    //Caso seja, o endereco do prontuario será atualizado
                    _enderecoProntuarioRepository.Atualizar(id, enderecoProntuarioAtualizado);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se endereco de prontuario não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta um endereco de prontuario
        /// </summary>
        /// <param name="id">ID do endereco do prontuario que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/EnderecoProntuario/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EnderecoProntuario enderecoProntuarioBuscado = _enderecoProntuarioRepository.BuscarPorId(id);

            //Verifica se enderecoProntuarioBuscado é igual a nulo
            if (enderecoProntuarioBuscado == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta o endereco do prontuario e retorna um StatusCode Accepted
            _enderecoProntuarioRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}