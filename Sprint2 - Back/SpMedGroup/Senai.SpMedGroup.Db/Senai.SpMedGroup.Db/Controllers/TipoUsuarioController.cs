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

    public class TipoUsuarioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _tipoUsuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos usuarios
        /// </summary>
        /// <returns>Uma lista de tipos usuarios e um status code 200 - Ok</returns>
        /// dominio/api/TipoUsuario
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_tipoUsuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo usuario através do seu ID
        /// </summary>
        /// <param name="id">ID do tipo usuario que será buscado</param>
        /// <returns>Um tipo usuario buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/TipoUsuario/1
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _tipoUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/TipoUsuario
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            // Faz a chamada para o método .Cadastrar();
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo usuario existente
        /// </summary>
        /// <param name="id">ID do tipo usuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/TipoUsuario/1
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            // Verifica se tipoUsuarioBuscado é diferente de nulo
            if (tipoUsuarioBuscado != null)
            {
                //Haverá uma tentativa de atulizar o tipo usuario
                try
                {
                    //Caso seja, o tipoUsuario será atualizado
                    _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            //Se tipoUsuario não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta um tipousuario
        /// </summary>
        /// <param name="id">ID do tipoUsuario que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/TipoUsuario/1
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            //Verifica se tipousuarioBuscado é igual a nulo
            if (tipoUsuarioBuscado == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta o tipoUsuario e retorna um StatusCode Accepted
            _tipoUsuarioRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}