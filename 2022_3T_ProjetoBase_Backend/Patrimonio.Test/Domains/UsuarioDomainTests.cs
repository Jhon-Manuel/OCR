using Patrimonio.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.Test.Domains
{
    public class UsuarioDomainTests
    {
        [Fact] //Descrição
        public void Deve_Retornar_Usuario()
        {
            //Pré-Condição
            Usuario usuario = new Usuario();
            usuario.Email = "hugo@email.com";
            usuario.Senha = "hugo12345";

            //Procedimento
            bool resultado = true;

            if (usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }

            //Resultado esperado
            Assert.True(resultado);
        }
    }
}
