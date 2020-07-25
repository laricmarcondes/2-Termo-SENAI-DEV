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

    public class InstituicaoController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _instituicaoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IInstituicaoRepository _instituicaoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Lista todas as instituicoes
        /// </summary>
        /// <returns>Uma lista de instituicoes e um status code 200 - Ok</returns>
        /// dominio/api/Instituicao
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_instituicaoRepository.Listar());
        }

        /// <summary>
        /// Busca uma  através do seu ID
        /// </summary>
        /// <param name="id">ID da instituicao que será buscada</param>
        /// <returns>Uma instituicao buscada ou NotFound caso nenhuma seja encontrado</returns>
        /// dominio/api/Instituicao/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _instituicaoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="novaInstituicao">Objeto novaInstituicao que será cadastrada</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Instituicao
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Instituicao novaInstituicao)
        {
            // Faz a chamada para o método .Cadastrar();
            _instituicaoRepository.Cadastrar(novaInstituicao);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será atualizado</param>
        /// <param name="instituicaoAtualizada">Objeto instituicaoAtualizada que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Instituicao/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

            // Verifica se instituicaoBuscada é diferente de nulo
            if (instituicaoBuscada != null)
            {
                //Haverá uma tentativa de atulizar a instituicao
                try
                {
                    //Caso seja, a instituicao será atualizada
                    _instituicaoRepository.Atualizar(id, instituicaoAtualizada);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se instituicao não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta uma instituicao
        /// </summary>
        /// <param name="id">ID da instituicao que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Instituicao/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

            //Verifica se instituicaoBuscada é igual a nulo
            if (instituicaoBuscada == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta a instituicao e retorna um StatusCode Accepted
            _instituicaoRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}