using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApiFirst.Domains;
using Senai.InLock.WebApiFirst.Interfaces;
using Senai.InLock.WebApiFirst.Repositories;

namespace Senai.InLock.WebApiFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository;

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public List<Jogos> Get()
        {
            return _jogoRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_jogoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Jogos novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogos jogoAtualizado)
        {
            Jogos jogoBuscado = _jogoRepository.BuscarPorId(id);
            
            if (jogoBuscado != null)
            {
                try
                {
                    _jogoRepository.Atualizar(id, jogoAtualizado);
                    
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
                        mensagem = "Jogo não encontrado",
                        erro = true
                    }
                );
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Jogos jogoBuscado = _jogoRepository.BuscarPorId(id);
            
            if (jogoBuscado != null)
            {
                _jogoRepository.Deletar(id);
                
                return Ok($"O jogo {id} foi deletado com sucesso!");
            }
            
            return NotFound("Nenhum jogo encontrado para o identificador informado");
        }

        [HttpGet("Estudios")]
        public IActionResult GetJogosEstudios()
        {
            return Ok(_jogoRepository.ListarComEstudio());
        }

        [HttpGet("Estudios/{id}")]
        public IActionResult GetUmEstudio(int id)
        {
            return Ok(_jogoRepository.ListarPorEstudio(id));
        }
    }
}
    
