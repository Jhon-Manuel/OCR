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
using Patrimonio.Repositories;

namespace Patrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilsController : ControllerBase
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilsController(PerfilRepository repo)
        {
            _perfilRepository = repo;
        }

        // GET: api/Perfis
        [HttpGet]
        public ActionResult<IEnumerable<Perfil>> GetPerfils()
        {
            return Ok(_perfilRepository.Listar());
        }

        // GET: api/Perfis/5
        [HttpGet("{id}")]
        public ActionResult<Perfil> GetPerfil(int id)
        {
            var perfil = _perfilRepository.BuscarPorID(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        // PUT: api/Perfis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutPerfil(int id, Perfil perfil)
        {
            if (id != perfil.Id)
            {
                return BadRequest();
            }

            try
            {
                var novoPerfil = _perfilRepository.BuscarPorID(id);

                _perfilRepository.Alterar( novoPerfil);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Perfis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Perfil> PostPerfil(Perfil perfil)
        {
            _perfilRepository.Cadastrar(perfil);

            return CreatedAtAction("GetPerfil", new { id = perfil.Id }, perfil);
        }

        // DELETE: api/Perfis/5
        [HttpDelete("{id}")]
        public IActionResult DeletePerfil(int id)
        {
            var perfil = _perfilRepository.BuscarPorID(id);
            if (perfil == null)
            {
                return NotFound();
            }

            _perfilRepository.Excluir(perfil);

            return NoContent();
        }

        private bool PerfilExists(int id)
        {
            var buscado = _perfilRepository.BuscarPorID(id);

            if (buscado == null)
            {
                return false;
            }

            return true;
        }
    }
}
