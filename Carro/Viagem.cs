using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoVeiculo
{
    public class Viagem:Base
    {
        public double Distancia;
        public string ClimaAtual;


        public override string ToString()
        {
            return $"A Distância da viagem {Distancia}, com o clima {ClimaAtual}";
        }

    }
}
