using System;

namespace Calculadora
{
    public interface ICalcular
    {
        int Somar(int primeiro, int segundo);
        int Subtrair(int primeiro, int segundo);
    }
}