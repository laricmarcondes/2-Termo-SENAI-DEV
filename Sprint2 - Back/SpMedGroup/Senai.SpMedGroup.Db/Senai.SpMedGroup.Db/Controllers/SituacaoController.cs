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

    public class SituacaoController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _situacaoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private ISituacaoRepository _situacaoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public SituacaoController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Uma lista de situacao e um status code 200 - Ok</returns>
        /// dominio/api/Situacao
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_situacaoRepository.Listar());
        }

        /// <summary>
        /// Busca uma situacao através do seu ID
        /// </summary>
        /// <param name="id">ID da situacao que será buscada</param>
        /// <returns>Uma situacao buscada ou NotFound caso nenhuma seja encontrada</returns>
        /// dominio/api/Situacao/1
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _situacaoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaSituacao">Objeto novaSituacao que será cadastrada</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Situacao
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Situacao novaSituacao)
        {
            // Faz a chamada para o método .Cadastrar();
            _situacaoRepository.Cadastrar(novaSituacao);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma situacao existente
        /// </summary>
        /// <param name="id">ID da situacao que será atualizada</param>
        /// <param name="situacaoAtualizada">Objeto situacaoAtualizada que será alterada</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Situacao/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Situacao situacaoAtualizada)
        {
            Situacao situacaoBuscada = _situacaoRepository.BuscarPorId(id);

            // Verifica se clinicaBuscada é diferente de nulo
            if (situacaoBuscada != null)
            {
                //Haverá uma tentativa de atulizar a situacao
                try
                {
                    //Caso seja, a situacao será atualizada
                    _situacaoRepository.Atualizar(id, situacaoAtualizada);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se situacao não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta uma situacao
        /// </summary>
        /// <param name="id">ID da situacao que será deletada</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Situacao/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Situacao situacaoBuscada = _situacaoRepository.BuscarPorId(id);

            //Verifica se situacaoBuscada é igual a nulo
            if (situacaoBuscada == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta a situacao e retorna um StatusCode Accepted
            _situacaoRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}