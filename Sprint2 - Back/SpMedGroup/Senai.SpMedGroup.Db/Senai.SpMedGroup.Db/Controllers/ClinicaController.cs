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

    public class ClinicaController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _clinicaRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IClinicaRepository _clinicaRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Uma lista de clinicas e um status code 200 - Ok</returns>
        /// dominio/api/Clinica
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_clinicaRepository.Listar());
        }

        /// <summary>
        /// Busca uma clinica através do seu ID
        /// </summary>
        /// <param name="id">ID da clinica que será buscada</param>
        /// <returns>Uma clinica buscada ou NotFound caso nenhuma seja encontrada</returns>
        /// dominio/api/Evento/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _clinicaRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">Objeto novaClinica que será cadastrada</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Clinica
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            // Faz a chamada para o método .Cadastrar();
            _clinicaRepository.Cadastrar(novaClinica);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="id">ID da clinica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto clinicaAtualizada que será alterada</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Clinica/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(id);

            // Verifica se clinicaBuscada é diferente de nulo
            if (clinicaBuscada != null)
            {
                //Haverá uma tentativa de atulizar a clinica
                try
                {
                    //Caso seja, a clinica será atualizada
                    _clinicaRepository.Atualizar(id, clinicaAtualizada);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se clinica não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta uma clinica
        /// </summary>
        /// <param name="id">ID da clinica que será deletada</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Clinica/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(id);

            //Verifica se clinicaBuscada é igual a nulo
            if (clinicaBuscada == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta a clinica e retorna um StatusCode Accepted
            _clinicaRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}