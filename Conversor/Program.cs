using System;

namespace Conversor
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculadora = new CalculadoraIntergalatica();

            var resultado = calculadora.Calcular("glob prok Iron");

            Console.WriteLine(resultado);
        }
    }
}