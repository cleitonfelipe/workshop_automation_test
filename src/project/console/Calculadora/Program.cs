using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("===== Escolha a operação\n 1 = Soma \n 2 = Subtração");
            var Operacao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("===== Digite com o primeiro valor!");
            var Primeiro = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("===== Digite com o segundo valor!");
            var Segundo = Convert.ToInt32(Console.ReadLine());

            var calc = new Calcular(Operacao, Primeiro, Segundo);

            Console.WriteLine(calc);

        }
    }
}
