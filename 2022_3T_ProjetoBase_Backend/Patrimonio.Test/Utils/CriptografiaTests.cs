
using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.Test.Utils
{
    public class CriptografiaTests
    {

		[Fact]
		public void Deve_Retornar_Hash_em_BCrypt()
		{
			// Pré-condição / Arrange
			var senha = criptografia.GerarHash("123456");
			var regex = new Regex(@"^\$2[ayb]\$.{ 56 }$");

			// Procedimento / Act
			var retorno = regex.IsMatch(senha);

			// Resultado / Assert
			Assert.True(retorno);
		}

		[Fact]
		public void Deve_Retornar_Comparar_Valida()
		{
			// Pré-condição / Arrange
			var senha = "123456";
			var hashBanco = "utilizar hash gerado ou do banco";

			// Proedimento / Act
			var comparacao = criptografia.Comparar(senha, hashBanco);

			// Resultado / Assert
			Assert.True(comparacao);
		}
	}
}
