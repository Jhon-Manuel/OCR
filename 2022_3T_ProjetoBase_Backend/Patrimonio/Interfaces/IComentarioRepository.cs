using Patrimonio.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Interfaces
{
    public interface IComentarioRepository
    {
        Comentario Cadastrar(Comentario comentario);
        Comentario Alterar(Comentario comentario);
        void Excluir(Comentario comentario);
        IEnumerable<Comentario> Listar();
        Comentario BuscarPorID(int id);
    }
}
