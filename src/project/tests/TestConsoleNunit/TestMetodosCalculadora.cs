using NUnit.Framework;
using Calculadora;

namespace TestConsoleNunit
{
    public class TestMetodosCalculadora
    {

        //Arrange
        Calcular _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new Calcular();
        }

        [Test]
        public void TestOperacaoSomar()
        {
            var valor_1 = 1;
            var valor_2 = 1;
            
            //Act
            var resultado = _calc.Somar(valor_1, valor_2);

            //Assert
            Assert.AreEqual(2, resultado);
        }
    }
}