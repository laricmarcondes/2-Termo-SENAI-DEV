
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.webapi.Domains;
using senai.Filmes.webapi.Interfaces;
using senai.Filmes.webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace senai.Filmes.webapi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }
        
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }
        
        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            return _filmeRepository.Listar();
        }
        
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);
            
            return StatusCode(201);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);
            
            if (filmeBuscado == null)
            {
                return NotFound("Nenhum filme encontrado");
            }
            
            return Ok(filmeBuscado);
        }
        
        [HttpPut]
        public IActionResult PutIdCorpo(FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filmeAtualizado.IdFilme);
            
            if (filmeBuscado != null)
            {
                try
                {
                    _filmeRepository.AtualizarIdCorpo(filmeAtualizado);
                    
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }
            
            return NotFound
                (
                    new
                    {
                        mensagem = "Filme não encontrado",
                        erro = true
                    }
                );
        }
        
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);
            
            if (filmeBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Filme não encontrado",
                            erro = true
                        }
                    );
            }
            
            try
            {
                _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);
                
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            // Verifica se o filme foi encontrado
            if (filmeBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                _filmeRepository.Deletar(id);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O filme {id} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum filme encontrado para o identificador informado");
        }

        /// <summary>
        /// Lista todos os filmes através de uma palavra-chave
        /// </summary>
        /// <param name="busca">Palavra-chave que será utilizada na busca</param>
        /// <returns>Retorna uma lista de filmes encontrados</returns>
        /// dominio/api/Filmes/pesquisar/palavra-chave
        [HttpGet("pesquisar/{busca}")]
        public IActionResult GetByTitle(string busca)
        {
            // Faz a chamada para o método .BuscarPorTitulo()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_filmeRepository.BuscarPorTitulo(busca));
        }
    }
}
