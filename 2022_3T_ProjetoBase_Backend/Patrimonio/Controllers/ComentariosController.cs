using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;

namespace Patrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentariosController(IComentarioRepository repo)
        {
            _comentarioRepository = repo;
        }

        // GET: api/Comentarios
        [HttpGet]
        public ActionResult<IEnumerable<Comentario>> GetComentarios()
        {
            try
            {
                return Ok(_comentarioRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        // GET: api/Comentarios/5
        [HttpGet("{id}")]
        public ActionResult<Comentario> GetComentario(int id)
        {
            var comentario = _comentarioRepository.BuscarPorID(id);

            if (comentario == null)
                {
                    return NotFound();
                }

            try
            {

                return Ok(comentario);

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        // PUT: api/Comentarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutComentario(int id, Comentario comentario)
        {
            if (id != comentario.Id)
            {
                return BadRequest();
            }

            _comentarioRepository.Alterar(comentario);

            return NoContent();
        }

        // POST: api/Comentarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Comentario> PostComentario(Comentario comentario)
        {
            _comentarioRepository.Cadastrar(comentario);

            return CreatedAtAction("GetComentario", new { id = comentario.Id }, comentario);
        }

        // DELETE: api/Comentarios/5
        [HttpDelete("{id}")]
        public IActionResult DeleteComentario(int id)
        {
            var comentario = _comentarioRepository.BuscarPorID(id);

            if (comentario == null)
            {
                return NotFound();
            }

            _comentarioRepository.Excluir(comentario);

            return NoContent();
        }

        private bool ComentarioExists(int id)
        {
            var buscado = _comentarioRepository.BuscarPorID(id);

            if (buscado == null)
            {
                return false;
            }
            return true;
        }
    }
}
