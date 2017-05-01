using System;
using System.Collections.Generic;
using System.Text;
using Conversor.Extension;
using System.Linq;

namespace Conversor
{
    public class CalculadoraIntergalatica
    {
        private Dictionary<string, string> unidadesConhecidasEmRomanos;
        private Dictionary<string, int> unidadesConhecidasEmInteiros;

        private Dictionary<string, string> UnidadesConhecidasEmRomanos
        {
            get
            {
                if(this.unidadesConhecidasEmRomanos == null)
                {
                    this.unidadesConhecidasEmRomanos = new Dictionary<string, string>();

                    this.unidadesConhecidasEmRomanos.Add("glob", "I");
                    this.unidadesConhecidasEmRomanos.Add("prok", "V");
                    this.unidadesConhecidasEmRomanos.Add("pish", "X");
                    this.unidadesConhecidasEmRomanos.Add("tegj", "L");
                }

                return this.unidadesConhecidasEmRomanos;
            }
        }

        private Dictionary<string, int> UnidadesConhecidasEmInteiros
        {
            get
            {
                if (this.unidadesConhecidasEmInteiros == null)
                {
                    this.unidadesConhecidasEmInteiros = new Dictionary<string, int>();

                    this.unidadesConhecidasEmInteiros.Add("glob glob Silver", 34);
                    this.unidadesConhecidasEmInteiros.Add("glob prok Gold", 57800);
                    this.unidadesConhecidasEmInteiros.Add("pish pish Iron", 3910);
                }

                return this.unidadesConhecidasEmInteiros;
            }
        }

        public string Calcular(string nomeDaMoeda)
        {
            var resultado = 0;

            if (this.UnidadesConhecidasEmInteiros.ContainsKey(nomeDaMoeda))
            {
                var valorDaUnidade = this.UnidadesConhecidasEmInteiros[nomeDaMoeda];

                var valorRomano = valorDaUnidade.ToRoman();

                resultado += valorDaUnidade;
            }
            else
            { 
                var valorTratado = this.SepararNomeMoedaParaCalculo(nomeDaMoeda);

                if (valorTratado.Any())
                {
                    var numeroRomano = string.Empty;

                    foreach (var palavra in valorTratado)
                    {
                        if (this.UnidadesConhecidasEmRomanos.ContainsKey(palavra))
                        {
                            var valorDaUnidade = this.unidadesConhecidasEmRomanos[palavra];
                            numeroRomano += valorDaUnidade;
                        }
                    }

                    resultado = numeroRomano.ToInt();
                }                
            }

            return string.Format("{0} is {1}", nomeDaMoeda, resultado);
        }

        private string[] SepararNomeMoedaParaCalculo(string valor)
        {
            return valor.Split(' ');
        }
    }
}
