using System;
using Xunit;
using Calculadora;

namespace TestConsoleXUnit
{
    public class TestMetodosCalculadora
    {
        //Arrange
        Calcular _calc =  new Calcular();
        [Fact]
        public void TestOperacaoSomar()
        {
            var valor_1 = 1;
            var valor_2 = 1;
            
            //Act
            var resultado = _calc.Somar(valor_1, valor_2);

            //Assert
            Assert.Equal(2, resultado);
        }
    }
}
