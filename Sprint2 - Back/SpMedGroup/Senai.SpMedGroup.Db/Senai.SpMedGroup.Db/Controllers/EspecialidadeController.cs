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

    public class EspecialidadeController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _especialidadeRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEspecialidadeRepository _especialidadeRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Lista todos as especialidades
        /// </summary>
        /// <returns>Uma lista de especialidades e um status code 200 - Ok</returns>
        /// dominio/api/Especialidade
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_especialidadeRepository.Listar());
        }

        /// <summary>
        /// Busca uma especialidade através do seu ID
        /// </summary>
        /// <param name="id">ID da especialidade que será buscado</param>
        /// <returns>Uma especialidade buscada ou NotFound caso nenhuma seja encontrada</returns>
        /// dominio/api/Especialidade/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _especialidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto novaEspecialidade que será cadastrada</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Especialidade
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Especialidades novaEspecialidade)
        {
            // Faz a chamada para o método .Cadastrar();
            _especialidadeRepository.Cadastrar(novaEspecialidade);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma especialidade existente
        /// </summary>
        /// <param name="id">ID da especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">Objeto especialidadeAtualizada que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Especialidade/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Especialidades especialidadeAtualizada)
        {
            Especialidades especialidadeBuscada = _especialidadeRepository.BuscarPorId(id);

            // Verifica se especialidadeBuscada é diferente de nulo
            if (especialidadeBuscada != null)
            {
                //Haverá uma tentativa de atulizar a especialidade
                try
                {
                    //Caso seja, a especialidade será atualizada
                    _especialidadeRepository.Atualizar(id, especialidadeAtualizada);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se especialidade não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta uma especialidade
        /// </summary>
        /// <param name="id">ID da especialidade que será deletada</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Especialidade/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Especialidades especialidadeBuscada = _especialidadeRepository.BuscarPorId(id);

            //Verifica se especialidadeBuscada é igual a nulo
            if (especialidadeBuscada == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta especialidade e retorna um StatusCode Accepted
            _especialidadeRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}