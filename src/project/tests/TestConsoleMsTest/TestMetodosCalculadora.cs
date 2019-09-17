using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculadora;

namespace TestConsoleMsTest
{
    [TestClass]
    public class TestMetodosCalculadora
    {
        //Arrange
        Calcular _calc;

        [TestMethod]
        public void TestOperacaoSomar()
        {
            var valor_1 = 1;
            var valor_2 = 1;
            
            //Act
            _calc = new Calcular();

            //Assert
            Assert.AreEqual(2, _calc.Somar(valor_1, valor_2));
        }
    }
}
