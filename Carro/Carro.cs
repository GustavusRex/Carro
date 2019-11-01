using System;
using System.Text;

namespace ProjetoVeiculo
{
    class Carro : Veiculo
    {
        Validacao val = new Validacao();

        public double KmPorAlcool;

        public double KmPorGasolina;

        public double Litros;

        public double LitrosGasolina = 0;

        public double LitrosAlcool = 0;

        public override void CadastrarVeiculo()
        {
            Console.WriteLine("Digite as informações do carro\n");
            base.CadastrarVeiculo();

            if (TipoCombustivel == "gasolina")
            {
                Console.WriteLine("Digite a Kilometragem por Litro de Gasolina (Entre 1 até 15): ");
                KmPorGasolina = val.ValidarAutonomia(Console.ReadLine());
            }
            else if (TipoCombustivel == "alcool")
            {
                Console.WriteLine("\nDigite a Kilometragem por Litro de Alcool (Entre 1 até 15): ");
                KmPorAlcool = val.ValidarAutonomia(Console.ReadLine());

            }
            else if (Flex)
            {
                Console.WriteLine("\nDigite a Kilometragem por Litro de Gasolina (Entre 1 até 15): ");
                KmPorGasolina = val.ValidarAutonomia(Console.ReadLine());
                Console.WriteLine("\nDigite a Kilometragem por Litro de Alcool (Entre 1 até 15): ");
                KmPorAlcool = val.ValidarAutonomia(Console.ReadLine());
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCarro Cadastrado!"); Console.ResetColor();
            Console.WriteLine("\nAperte qualquer coisa para continuar...");
        }

        public void Abastecer()
        {
            if (Placa == null)
            {
                Console.WriteLine("Carro Não existe" +
                    " Aperte qualquer coisa para continuar..."); return;
            }
            else if (TipoCombustivel == "gasolina")
            {
                AbastecerVeiculoPadrão(CapacidadeTanque, LitrosGasolina, Litros);
            }
            else if(TipoCombustivel == "alcool")
            {
                AbastecerVeiculoPadrão(CapacidadeTanque, LitrosAlcool, Litros);
            }
            else if (Flex)
            {
                AbastecerVeiculoFlex(CapacidadeTanque, LitrosGasolina, LitrosAlcool, Litros);
            }

        }

        public void Dirigir()
        {

            Console.WriteLine("Digite a distância da viagem");
            double viagem = val.ValidarNumerosDouble(Console.ReadLine()); // Distancia que o carro vai percorrer

            if (Placa == null)
                Console.WriteLine("Carro Não existe" +
                    " Aperte qualquer coisa para continuar...");

            if (TipoCombustivel == "gasolina")
            {
                do
                {
                    if (LitrosGasolina * KmPorGasolina < viagem) // Compara a autonomia com o a quantidade do tanque atual e a viagem
                    {
                        viagem -= LitrosGasolina * KmPorGasolina;
                        LitrosGasolina = 0;
                    }
                    else if (LitrosGasolina * KmPorGasolina > viagem) // Compara a autonomia com o a quantidade do tanque atual e a viagem
                    {
                        LitrosGasolina -= viagem / KmPorGasolina;
                        viagem = 0;

                    }
                    else if (LitrosGasolina * KmPorGasolina == viagem) // Compara a autonomia com o a quantidade do tanque atual e a viagem
                    {
                        viagem = 0;
                        LitrosGasolina = 0;
                    }
                    if (LitrosGasolina == 0 && viagem > 0)
                    {
                        Console.WriteLine($"O tanque está com {LitrosGasolina.ToString("F2")} litros, Ainda falta {viagem}KM para percorrer\n");
                        Abastecer();
                    }

                } while (viagem > 0);

                Console.WriteLine($"Viagem Concluída há {LitrosGasolina.ToString("F2")} litros no tanque");
                Console.WriteLine("\nAperte qualquer coisa para continuar...");
            }

            else if (TipoCombustivel == "alcool")
            {
                do
                {
                    if (LitrosAlcool * KmPorAlcool < viagem) // Compara a autonomia com o a quantidade do tanque atual e a viagem
                    {
                        viagem -= LitrosAlcool * KmPorAlcool;
                        LitrosAlcool = 0;
                    }
                    else if (LitrosAlcool * KmPorAlcool > viagem) // Compara a autonomia com o a quantidade do tanque atual e a viagem
                    {
                        LitrosAlcool -= viagem / KmPorAlcool;
                        viagem = 0;
                    }
                    else if (LitrosAlcool * KmPorAlcool == viagem) // Compara a autonomia com o a quantidade do tanque atual e a viagem
                    {
                        viagem = 0;
                        LitrosAlcool = 0;
                    }
                    if (LitrosAlcool == 0 && viagem > 0)
                    {
                        Console.WriteLine($"O tanque está com {LitrosAlcool.ToString("F2")} litros, Ainda falta {viagem}KM para percorrer\n");
                        Abastecer();
                    }

                } while (viagem > 0);

                Console.WriteLine($"Viagem Concluída há {LitrosAlcool.ToString("F2")} litros no tanque");
                Console.WriteLine("\nAperte qualquer coisa para continuar...");
            }

            else if (Flex)
            {
                do
                {
                    while (LitrosAlcool != 0 && viagem > 0)
                    {
                        if (LitrosAlcool * KmPorAlcool < viagem)
                        {
                            viagem -= LitrosAlcool * KmPorAlcool;
                            LitrosAlcool = 0;
                        }
                        else if (LitrosAlcool * KmPorAlcool > viagem)
                        {
                            LitrosAlcool -= viagem / KmPorAlcool;
                            viagem = 0;
                        }
                        else if (LitrosAlcool * KmPorAlcool == viagem)
                        {
                            viagem = 0;
                            LitrosAlcool = 0;
                        }
                    }

                    while (LitrosGasolina != 0 && viagem > 0)
                    {
                        if (LitrosGasolina * KmPorGasolina < viagem)
                        {
                            viagem -= LitrosGasolina * KmPorGasolina;
                            LitrosGasolina = 0;
                        }
                        else if (LitrosGasolina * KmPorGasolina > viagem)
                        {
                            LitrosGasolina -= viagem / KmPorGasolina;
                            viagem = 0;
                        }
                        else if (LitrosGasolina * KmPorGasolina == viagem)
                        {
                            viagem = 0;
                            LitrosGasolina = 0;
                        }
                    }

                    if (LitrosAlcool == 0 && LitrosGasolina == 0 && viagem > 0)
                    {
                        Console.WriteLine($"O tanque está com {LitrosAlcool + LitrosGasolina.ToString("F2")} litros, Ainda falta {viagem}KM para percorrer\n");
                        Abastecer();
                    }

                } while (viagem > 0);
                Console.WriteLine($"Viagem Concluída, há {LitrosGasolina + LitrosAlcool.ToString("F2")} litros no tanque");
                Console.WriteLine("\nAperte qualquer coisa para continuar...");
            }

        }

        public override string ToString()
        {
            if (Placa == null)
                Console.WriteLine("Carro Não existe" +
                    " Aperte qualquer coisa para continuar...");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"O carro da marca {Marca}, do modelo {Modelo} com a placa {Placa}");
            sb.AppendLine($"Sendo do ano {Ano}, alcança a velocidade maxima de {VelocidadeMaxima} e tem a capacidade de {CapacidadeTanque} litros");
            if (TipoCombustivel == "gasolina")
                sb.AppendLine($"Seu tipo de combustivel é {TipoCombustivel}, com seu Tanque inicial {LitrosGasolina} e com a autonomia de {KmPorGasolina} KM para percorrer como tanque cheio");
            else if (TipoCombustivel == "alcool")
                sb.AppendLine($"Seu tipo de combustivel é {TipoCombustivel}, com seu Tanque inicial {LitrosAlcool} e com a autonomia de {KmPorAlcool} KM para percorrer como tanque cheio");
            else if (Flex)
                sb.AppendLine($"Carro do tipo felex com seu Tanque inicial {LitrosAlcool} de alcool e {LitrosGasolina} de gasolina e com " +
                    $"a autonomia de {KmPorAlcool} KM/L " +
                    $"e com a autonomia de {KmPorGasolina} KM/L");
            return sb.ToString();
        }

    }
}
