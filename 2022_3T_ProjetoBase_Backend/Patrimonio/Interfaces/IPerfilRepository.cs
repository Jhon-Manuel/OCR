using Patrimonio.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Interfaces
{
    interface IPerfilRepository
    {
        Perfil Cadastrar(Perfil perfil);
        Perfil Alterar(Perfil perfil);
        void Excluir(Perfil perfil);
        IEnumerable<Perfil> Listar();
        Perfil BuscarPorID(int id);

    }
}
