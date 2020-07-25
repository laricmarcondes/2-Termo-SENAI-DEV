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

    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _usuariosRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios e um status code 200 - Ok</returns>
        /// dominio/api/Usuario
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna um StatusCode e faz uma chamada para o método .Listar()
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um usuario através do seu ID
        /// </summary>
        /// <param name="id">ID do usuario que será buscado</param>
        /// <returns>Um usuario buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Usuario/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna os dados buscados e um status code 200 - Ok
            return StatusCode(200, _usuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novousuario">Objeto novousuario que será cadastrado</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Evento
        [Authorize(Roles ="1, 2")]
        [HttpPost]
        public IActionResult Post(Usuario novousuario)
        {
            // Faz a chamada para o método .Cadastrar();
            _usuarioRepository.Cadastrar(novousuario);

            // Retorna o status code 201 - Created com a URL e o objeto cadastrado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Usuario/1
        [Authorize(Roles = "1, 2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            // Verifica se usuarioBuscado é diferente de nulo
            if (usuarioBuscado != null)
            {
                //Haverá uma tentativa de atulizar o usuario
                try
                {
                    //Caso seja, o usuario será atualizado
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);

                    //E retornará um StatusCode Ok
                    return StatusCode(200);
                }
                //Ao tentar atualizar, se não for possível, retornará um StatusCode com erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            //Se usuario não for diferente de nulo, retornará um StatusCode NotFound
            return StatusCode(404);
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">ID do usuario que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Evento/1
        [Authorize(Roles = "1, 2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            //Verifica se usuarioBuscado é igual a nulo
            if (usuarioBuscado == null)
            {
                //Se for igual a nulo, retorna um NotFound
                return NotFound();
            }

            //Se não for, deleta o usuario e retorna um StatusCode Accepted
            _usuarioRepository.Deletar(id);

            return StatusCode(202);
        }

        /// <summary>
        /// Lista todos os usuarios com os tipos usuario
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        [Authorize(Roles = "1")]
        [HttpGet("TipoUsuario")]
        public IActionResult GetTipoEvento()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.ListarComTipoUsuario());
        }

        /// <summary>
        /// Lista todos os usuarios com as presencas
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        [Authorize(Roles = "1")]
        [HttpGet("Presenca")]
        public IActionResult GetPresenca()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.ListarComPresenca());
        }
    }
}