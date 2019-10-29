using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoVeiculo
{
    class Carro:Veiculo
    {
       // public double AutonomiaAlcool;

        public double KmPorAlcool;

        //public double AutonomiaGasolina;

        public double KmPorGasolina;

        public double AutonomiaTotal;

        public double litros;

        public double Tanque = 0;

        public string opcao;

        public override void CadastrarVeiculo()
        {
            Console.WriteLine("Digite as informações do carro\n");
            base.CadastrarVeiculo();

            if (TipoCombustivel == "gasolina")
            {
                Console.WriteLine("Digite a Kilometragem por Litro de Gasolina");
                KmPorGasolina = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Digite a Kilometragem por Litro de Alcool");
                KmPorAlcool = double.Parse(Console.ReadLine());
            }
            AutonomiaTotal = ((CapacidadeTanque * KmPorGasolina) + (CapacidadeTanque * KmPorAlcool));
        }

        public void Abastecer()
        {
            Console.WriteLine($"Quantidade no tanque {Tanque} litros");

            switch (TipoCombustivel)
            {

                case "gasolina":
                    {

                        if (Tanque == CapacidadeTanque)
                        Console.WriteLine("Tanque está cheio");

                        else
                        {
                            Console.WriteLine("Quanto deseja abastecer?");
                            litros = double.Parse(Console.ReadLine());
                            
                            while (litros > CapacidadeTanque || Tanque > CapacidadeTanque)
                            {
                                Console.WriteLine("Impossivel colocar essa quantidade");
                                Console.WriteLine($"Sua capacidade maxima é de: {CapacidadeTanque}");
                                litros = double.Parse(Console.ReadLine());
                            }

                            Tanque += litros;
                        }
                        break;
                    }

                case "alcool":
                    {
                

                        if (Tanque == CapacidadeTanque)
                            Console.WriteLine("Tanque está cheio");

                        else
                        {
                            Console.WriteLine("Quanto deseja abastecer?");
                            Tanque += double.Parse(Console.ReadLine());

                            while (Tanque > CapacidadeTanque)
                            {
                                Console.WriteLine("Impossivel colocar essa quantidade");
                                Console.WriteLine($"Sua capacidade maxima é de: {CapacidadeTanque}");
                                Tanque = double.Parse(Console.ReadLine());
                            }
                        }
                        break;
                    }

            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"O carro da marca {Marca}, do modelo {Modelo} com a placa {Placa}");
            sb.AppendLine($"Sendo do ano {Ano.ToString("dd/MM/yyyy")}, alcança a velocidade maxima de {VelocidadeMaxima} e tem a capacidade de {CapacidadeTanque} litros");
            sb.AppendLine($"Seu tipo de combustivel é {TipoCombustivel}, com seu Tanque inicial {Tanque} e com a autonomia de {AutonomiaTotal} para percorrer como tanque cheio");
            return sb.ToString();
        }

    }
}
