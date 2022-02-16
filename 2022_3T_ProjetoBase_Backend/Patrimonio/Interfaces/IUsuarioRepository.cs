using Patrimonio.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        Usuario Cadastrar(Usuario usuario);
        Usuario Alterar(Usuario usuario);
        void Excluir(Usuario usuario);
        IEnumerable<Usuario> Listar();
        Usuario BuscarPorID(int id);
    }
}
