using Microsoft.EntityFrameworkCore;
using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        
            private readonly PatrimonioContext ctx;

            public ComentarioRepository(PatrimonioContext appContext)
            {
                ctx = appContext;
            }

            public Comentario Alterar(Comentario comentario)
            {
                ctx.Entry(comentario).State = EntityState.Modified;
                ctx.SaveChangesAsync();
                return comentario;
            }

            public Comentario Cadastrar(Comentario comentario)
            {
                ctx.Comentarios.Add(comentario);
                ctx.SaveChangesAsync();

                return comentario;
            }

            public void Excluir(Comentario comentario)
            {
                ctx.Comentarios.Remove(comentario);
                ctx.SaveChangesAsync();
            }
            public IEnumerable<Comentario> Listar()
            {
                return ctx.Comentarios.ToList();
            }

            Comentario IComentarioRepository.BuscarPorID(int id)
            {
                return ctx.Comentarios.Find(id);
            }

    }
}
