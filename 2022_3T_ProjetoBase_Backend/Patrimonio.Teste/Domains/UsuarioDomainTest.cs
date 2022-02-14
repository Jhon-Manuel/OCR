

using Patrimonio.Domains;
using Xunit;

namespace Patrimonio.Teste.Domains
{
    public class UsuarioDomainTest
    {
        [Fact] //Descrição
        public void Deve_Retorna_rUsuario()
        {
            //Pré-condição
            Usuario usuario = new Usuario();
            usuario.Email = "jhon@email.com";
            usuario.Senha = "123456";

            //Procedimento
            bool resultado =  true;

            if (usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }

            //Resultado
            Assert.True(resultado);
        }
    }
}
