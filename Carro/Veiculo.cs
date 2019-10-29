using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoVeiculo
{
    abstract class Veiculo
    {
        public string Marca;

        public string Modelo;

        public string Placa;

        public int Ano;

        public double VelocidadeMaxima;

        public double CapacidadeTanque;

        public string Flex;

        public string TipoCombustivel;


        public virtual void CadastrarVeiculo()
        {
            Console.Write("Digite a marca do veículo: ");
            Marca = Console.ReadLine();

            Console.Write("\nDigite o tipo de modelo do veiculo: ");
            Modelo = Console.ReadLine();

            Console.Write("Digite a placa do veículo: ");
            Placa = Console.ReadLine();

            Console.Write("Digite o ano : ");
            Ano = int.Parse(Console.ReadLine());

            Console.Write("Digite a velocidade maxima do veiculo: ");
            VelocidadeMaxima = double.Parse(Console.ReadLine());

            Console.Write("Digite a capacidade maxima do tanque de combustivel: ");
            CapacidadeTanque = double.Parse(Console.ReadLine());

            Console.Write("O veículo é do tipo flex? ");
            Flex = Console.ReadLine();

            if(Flex == "N")
            {
                Console.Write("Qual o tipo de Combustivel que o veículo utiliza? ");
                TipoCombustivel = Console.ReadLine();
            }

        }

    }
}
