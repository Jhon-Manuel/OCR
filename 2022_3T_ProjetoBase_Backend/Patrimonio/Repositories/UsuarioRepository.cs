using Microsoft.EntityFrameworkCore;
using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PatrimonioContext ctx;

        public UsuarioRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Usuario Login(string email, string senha)
        {

            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if(usuario != null)
            {
                bool confere = criptografia.Comparar(senha, usuario.Senha);
                if (confere)
                    return usuario;
            }

            return null;
        }

        public Usuario Alterar(Usuario usuario)
        {
            ctx.Entry(usuario).State = EntityState.Modified;
            ctx.SaveChangesAsync();
            return usuario;
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChangesAsync();

            return usuario;
        }

        public void Excluir(Usuario usuario)
        {
            ctx.Usuarios.Remove(usuario);
            ctx.SaveChangesAsync();
        }
        public IEnumerable<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        Usuario IUsuarioRepository.BuscarPorID(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        public Usuario Criptografia(string senhaCRI)
        {
            var senha = ctx.Usuarios.FirstOrDefault(s => s.Senha == senhaCRI);

            ctx.Add.()

            return 
        }
    }
}
