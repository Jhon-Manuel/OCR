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
    public class PerfilRepository : IPerfilRepository
    {
        private readonly PatrimonioContext ctx;

        public PerfilRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Perfil Alterar(Perfil perfil)
        {
            ctx.Entry(perfil).State = EntityState.Modified;
            ctx.SaveChangesAsync();
            return perfil;
        }

        public Perfil Cadastrar(Perfil perfil)
        {
            ctx.Perfils.Add(perfil);
            ctx.SaveChangesAsync();

            return perfil;
        }

        public void Excluir(Perfil perfil)
        {
            ctx.Perfils.Remove(perfil);
            ctx.SaveChangesAsync();
        }
        public IEnumerable<Perfil> Listar()
        {
            return ctx.Perfils.ToList();
        }

        Perfil IPerfilRepository.BuscarPorID(int id)
        {
            return ctx.Perfils.Find(id);
        }

    }
}
