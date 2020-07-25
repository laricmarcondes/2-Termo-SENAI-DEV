using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.CodeFirst.Interfaces;
using Senai.InLock.WebApi.CodeFirst.Repositories;
using Senai.InLocl.WebApi.CodeFirst.Domains;

namespace Senai.InLock.WebApi.CodeFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public List<Estudios> Get()
        {
            return _estudioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_estudioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Estudios novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Estudios estudioAtualizado)
        {
            Estudios estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado != null)
            {
                try
                {
                    _estudioRepository.Atualizar(id, estudioAtualizado);

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
                        mensagem = "Estudio não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Estudios estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado != null)
            {
                _estudioRepository.Deletar(id);

                return Ok($"O Estudio {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum estudio encontrado para o identificador informado");
        }

        [HttpGet("Jogos")]
        public IActionResult GetJogos()
        {
            return Ok(_estudioRepository.ListarPorJogos());
        }
    }
}