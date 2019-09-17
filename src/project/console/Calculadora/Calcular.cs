using System;

namespace Calculadora
{
    public class Calcular : ICalcular
    {
        private int _primeiro;
        public int Primeiro
        {
            get { return _primeiro; }
            set { _primeiro = value; }
        }

        private int _segundo;
        public int Segundo
        {
            get { return _segundo; }
            set { _segundo = value; }
        }

        private int _operacao;
        public int Operacao
        {
            get { return _operacao; }
            set { _operacao = value; }
        }
        
        private string _retorno;
        public string Retorno
        {
            get { return _retorno; }
            set { _retorno = value; }
        }               
        public Calcular(params int[] values)
        {
            Primeiro = values[1];
            Segundo = values[2];
            Operacao = values[0];
            
            switch(Operacao)
            {
                case 1:
                    Retorno = $"O resultado é: { Somar(Primeiro, Segundo) }";
                    break;
                case 2:
                    Retorno = $"O resultado é: { Subtrair(Primeiro, Segundo) }";
                    break;
                case 3:
                    Retorno = $"O resultado é: { Multiplicar(Primeiro, Segundo) }";
                    break;
                case 4:
                    var divisao = Dividir(Primeiro, Segundo) == 0 ? "Não é permitido divisão por zero." : Dividir(Primeiro, Segundo).ToString();
                    Retorno = $"O resultado é: { divisao }";
                    break;
                default:
                    Retorno = "Fatal error";
                    break;
            }

            Console.WriteLine(Retorno);

        }

        public int Somar(int primeiro, int segundo)
        {
            return primeiro + segundo;
        }

        public int Subtrair(int primeiro, int segundo)
        {
            return primeiro - segundo;
        }

        public int Multiplicar(int primeiro, int segundo)
        {
            return primeiro * segundo;
        }

        public int Dividir(int primeiro, int segundo)
        {
            if ((primeiro == 0) || (segundo == 0))
            {
                return 0;
            }
            return primeiro / segundo;
        }
    }
}