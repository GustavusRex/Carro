using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoVeiculo
{
    class Carro : Veiculo
    {
        public double AutonomiaAlcool;

        public double KmPorAlcool;

        public double AutonomiaGasolina;

        public double KmPorGasolina;

        public double Litros;

        public double LitrosGasolina = 0;

        public double LitrosAlcool = 0;

        public string opcao;


        public override void CadastrarVeiculo()
        {
            Console.WriteLine("Digite as informações do carro\n");
            base.CadastrarVeiculo();

            if (TipoCombustivel == "gasolina")
            {
                Console.WriteLine("Digite a Kilometragem por Litro de Gasolina");
                KmPorGasolina = double.Parse(Console.ReadLine());
                AutonomiaGasolina = CapacidadeTanque * KmPorGasolina;
            }
            else if (TipoCombustivel == "alcool")
            {
                Console.WriteLine("Digite a Kilometragem por Litro de Alcool");
                KmPorAlcool = double.Parse(Console.ReadLine());
                AutonomiaAlcool = CapacidadeTanque * KmPorAlcool;
            }
            else if (Flex == "S")
            {
                Console.WriteLine("Digite a Kilometragem por Litro de Gasolina");
                KmPorGasolina = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite a Kilometragem por Litro de Alcool");
                KmPorAlcool = double.Parse(Console.ReadLine());

                AutonomiaGasolina = CapacidadeTanque * KmPorGasolina;
                AutonomiaAlcool = CapacidadeTanque * KmPorAlcool;
            }

        } 

        public void Abastecer()
        {
            if (TipoCombustivel == "gasolina")
            {
                Console.WriteLine("Deseja encher o tanque?");
                opcao = Console.ReadLine();
                if (opcao == "S")
                {
                    LitrosGasolina += (CapacidadeTanque - LitrosGasolina);
                }

                if (LitrosGasolina == CapacidadeTanque)
                    Console.WriteLine("Tanque está cheio");               

               else 
                {
                    Console.WriteLine($"Quantidade no tanque {LitrosGasolina} litros");
                    Console.WriteLine("Quanto deseja abastecer de gasolina?");
                    Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {CapacidadeTanque} LITROS ");
                    Litros = double.Parse(Console.ReadLine());

                    while (Litros > CapacidadeTanque || Litros + LitrosGasolina > CapacidadeTanque)
                    {
                        Console.WriteLine("Ultrpassou o limite digite novamente");
                        Litros = double.Parse(Console.ReadLine());
                    }

                    LitrosGasolina += Litros;
                }

            }

            else if (TipoCombustivel == "alcool")
            {
                Console.WriteLine("Deseja encher o tanque?");
                opcao = Console.ReadLine();
                if (opcao == "S")
                {
                    LitrosAlcool += (CapacidadeTanque - LitrosAlcool);
                }

                if (LitrosAlcool == CapacidadeTanque)
                    Console.WriteLine("Tanque está cheio");

                else
                {
                    Console.WriteLine($"Quantidade no tanque {LitrosGasolina} litros");
                    Console.WriteLine("Quanto deseja abastecer de gasolina?");
                    Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {CapacidadeTanque} LITROS ");
                    Litros = double.Parse(Console.ReadLine());

                    while (Litros > CapacidadeTanque || Litros + LitrosAlcool > CapacidadeTanque)
                    {
                        Console.WriteLine("Ultrpassou o limite digite novamente");
                        Litros = double.Parse(Console.ReadLine());
                    }

                    LitrosAlcool += Litros;
                }

            }
            else if (Flex == "S")
            {
                if (LitrosAlcool + LitrosGasolina == CapacidadeTanque)
                    Console.WriteLine("Tanque está cheio");

                else
                {
                    Console.WriteLine("Carro do tipo Flex");
                    Console.WriteLine("Deseja abastecer alcool ou gasolina");
                    opcao = Console.ReadLine();
                  if (opcao == "gasolina")
                    {

                    }

                }
            }
        }

        public void Dirigir()
        {

            Console.WriteLine("Digite o tamanho da viagem");
            double viagem = double.Parse(Console.ReadLine());
            if(TipoCombustivel == "gasolina")
            {
                do
                {
                    if (LitrosGasolina < viagem)
                    {
                        viagem -= LitrosGasolina * KmPorGasolina;
                        LitrosGasolina = 0;
                    }
                    else if (LitrosGasolina >= viagem)
                    {
                        LitrosGasolina -= viagem;
                        viagem -= LitrosGasolina;
                    }
                    if (LitrosGasolina == 0 && viagem != 0)
                    {
                        Console.WriteLine($"O tanque está com {LitrosGasolina}, Ainda falta {viagem}KM para percorrer\n");
                        Abastecer();
                    }

                } while (viagem > 0);

                Console.WriteLine($"Viagem feita há {LitrosGasolina} litros no tanque");
            }

            else if (TipoCombustivel == "alcool")
            {
                do
                {
                    if (LitrosAlcool < viagem)
                    {
                        viagem -= LitrosAlcool * KmPorAlcool;
                        LitrosAlcool = 0;
                    }
                    else if (LitrosAlcool >= viagem)
                    {
                        LitrosAlcool -= viagem;
                        viagem -= LitrosAlcool;
                    }
                    if (LitrosAlcool == 0 && viagem != 0)
                    {
                        Console.WriteLine($"O tanque está com {LitrosAlcool}, Ainda falta {viagem}KM para percorrer\n");
                        Abastecer();
                    }

                } while (viagem > 0);

                Console.WriteLine($"Viagem feita há {LitrosAlcool} litros no tanque");
            }

            else if(Flex == "S")
            {
                do
                {
                    while (LitrosAlcool != 0)
                    {
                        if (LitrosAlcool < viagem)
                        {
                            viagem -= LitrosAlcool * KmPorAlcool;
                            LitrosAlcool = 0;
                        }
                        else if (LitrosAlcool >= viagem)
                        {
                            LitrosAlcool -= viagem;
                            viagem -= LitrosAlcool;
                        }
                    }

                    while (LitrosGasolina != 0)
                    {
                        if (LitrosGasolina < viagem)
                        {
                            viagem -= LitrosGasolina * KmPorGasolina;
                            LitrosGasolina = 0;
                        }
                        else if (LitrosGasolina >= viagem)
                        {
                            LitrosGasolina -= viagem;
                            viagem -= LitrosGasolina;
                        }
                    }

                    if (LitrosAlcool == 0 && LitrosGasolina == 0 && viagem != 0)
                    {
                        Console.WriteLine($"O tanque está com {LitrosAlcool}, Ainda falta {viagem}KM para percorrer\n");
                        Abastecer();
                    }

                } while (viagem > 0);
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"O carro da marca {Marca}, do modelo {Modelo} com a placa {Placa}");
            sb.AppendLine($"Sendo do ano {Ano}, alcança a velocidade maxima de {VelocidadeMaxima} e tem a capacidade de {CapacidadeTanque} litros");
            if (TipoCombustivel == "gasolina")
                sb.AppendLine($"Seu tipo de combustivel é {TipoCombustivel}, com seu Tanque inicial {LitrosGasolina} e com a autonomia de {AutonomiaGasolina}KM para percorrer como tanque cheio");
            else if (TipoCombustivel == "alcool")
                sb.AppendLine($"Seu tipo de combustivel é {TipoCombustivel}, com seu Tanque inicial {LitrosAlcool} e com a autonomia de {AutonomiaAlcool}KM para percorrer como tanque cheio");
            else if (Flex == "S")
                sb.AppendLine($"Carro do tipo felex com seu Tanque inicial {LitrosAlcool} de alcool e {LitrosGasolina} de gasolina e com " +
                    $"a autonomia de {AutonomiaAlcool}KM para percorrer com tanque cheio de alcool" +
                    $"e com a autonomia de {AutonomiaGasolina}KM para percorrer com o tanque cheio de gasolina");
            return sb.ToString();
        }

    }
}

