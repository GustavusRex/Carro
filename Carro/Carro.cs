using System;
using System.Text;

namespace ProjetoVeiculo
{
    class Carro : Veiculo
    {
        Validacao val = new Validacao();
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
                Console.WriteLine("Digite a Kilometragem por Litro de Gasolina (Entre 1 até 15): ");
                KmPorGasolina = val.ValidarAutonomia(Console.ReadLine());
                AutonomiaGasolina = CapacidadeTanque * KmPorGasolina; // Autonomia com o tanque cheio
            }
            else if (TipoCombustivel == "alcool")
            {
                Console.WriteLine("\nDigite a Kilometragem por Litro de Alcool (Entre 1 até 15): ");
                KmPorAlcool = val.ValidarAutonomia(Console.ReadLine());
                AutonomiaAlcool = CapacidadeTanque * KmPorAlcool; // Autonomia com o tanque cheio
            }
            else if (Flex == "S")
            {
                Console.WriteLine("\nDigite a Kilometragem por Litro de Gasolina (Entre 1 até 15): ");
                KmPorGasolina = val.ValidarAutonomia(Console.ReadLine());
                Console.WriteLine("\nDigite a Kilometragem por Litro de Alcool (Entre 1 até 15): ");
                KmPorAlcool = val.ValidarAutonomia(Console.ReadLine());

                AutonomiaGasolina = CapacidadeTanque * KmPorGasolina; // Autonomia com o tanque cheio
                AutonomiaAlcool = CapacidadeTanque * KmPorAlcool; // Autonomia com o tanque cheio
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCarro Cadastrado!");
            Console.ResetColor();
            Console.WriteLine("\nAperte qualquer coisa para continuar...");
        }

        public void Abastecer()
        {
            if(Placa == null)
                Console.WriteLine("Carro Não existe" +
                    " Aperte qualquer coisa para continuar...");
  

            if (TipoCombustivel == "gasolina")
            {
                if (LitrosGasolina == CapacidadeTanque) //  Testa se o tanque está cheio
                    Console.WriteLine("O Tanque está cheio" +
                        " Aperte qualquer coisa para continuar...");

                else if (LitrosGasolina < CapacidadeTanque)
                {
                    Console.WriteLine("Deseja encher o tanque?");
                    opcao = val.ValidarSimOuNao(Console.ReadLine().ToUpper()); // Opção para escolher caso queira abastecer ou encher o tanque 
                    if (opcao == "S")
                    {
                        LitrosGasolina += (CapacidadeTanque - LitrosGasolina);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("O Tanque está cheio");
                        Console.ResetColor();
                        Console.WriteLine("\nAperte qualquer coisa para continuar...");
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"\nQuantidade no tanque {LitrosGasolina.ToString("F2")} litros");
                        Console.WriteLine("Quanto deseja abastecer de gasolina?");
                        Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {CapacidadeTanque} LITROS ");
                        Litros = val.ValidarLitros(Console.ReadLine()); // Litros de Combustivel

                        while (Litros > CapacidadeTanque || Litros + LitrosGasolina > CapacidadeTanque)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nUltrapassou o limite digite novamente");
                            Console.ResetColor();
                            Litros = val.ValidarLitros(Console.ReadLine());
                        }

                        LitrosGasolina += Litros;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\nO Carro foi Abastecido! Há {LitrosGasolina.ToString("F2")} Litros");
                        Console.ResetColor();
                        Console.WriteLine("\nAperte qualquer coisa para continuar...");
                    }
                }

            }

            else if (TipoCombustivel == "alcool")
            {
                if (LitrosAlcool == CapacidadeTanque) //  Testa se o tanque está cheio
                    Console.WriteLine("O Tanque está cheio" +
                        " Aperte qualquer coisa para continuar...");




                else if (LitrosGasolina < CapacidadeTanque)
                {
                    Console.WriteLine("Deseja encher o tanque?");
                    opcao = val.ValidarSimOuNao(Console.ReadLine().ToUpper()); // Opção para escolher caso queira abastecer ou encher o tanque 
                    if (opcao == "S")
                    {
                        LitrosAlcool += (CapacidadeTanque - LitrosAlcool);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("O Tanque está cheio");
                        Console.ResetColor();
                        Console.WriteLine("\nAperte qualquer coisa para continuar...");

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Quantidade no tanque {LitrosAlcool.ToString("F2")} litros");
                        Console.WriteLine("Quanto deseja abastecer de gasolina?");
                        Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {CapacidadeTanque} LITROS ");
                        Litros = val.ValidarLitros(Console.ReadLine());

                        while (Litros > CapacidadeTanque || Litros + LitrosAlcool > CapacidadeTanque)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nUltrapassou o limite digite novamente");
                            Console.ResetColor();
                            Litros = val.ValidarLitros(Console.ReadLine()); // Litros de Combustivel
                        }

                        LitrosAlcool += Litros;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\nO Carro foi Abastecido! Há {LitrosAlcool.ToString("F2")} Litros");
                        Console.ResetColor();
                        Console.WriteLine("\nAperte qualquer coisa para continuar...");
                    }
                }

            }
            else if (Flex == "S")
            {
                if (LitrosAlcool + LitrosGasolina == CapacidadeTanque) //  Testa se o tanque está cheio
                    Console.WriteLine("\nTanque está cheio" +
                        " Aperte qualquer coisa para continuar...");


                else if (LitrosGasolina < CapacidadeTanque)
                {
                    Console.WriteLine("\nDeseja encher o tanque?");
                    opcao = val.ValidarSimOuNao(Console.ReadLine().ToUpper());
                    if (opcao == "S")
                    {
                        Console.WriteLine("\nQuer encher o tanque de alcool ou gasolina?");
                        opcao = val.ValidarTipoCombustivel(Console.ReadLine().ToLower()); // Opção para escolher caso queira abastecer ou encher o tanque 
                        if (opcao == "alcool")
                        {
                            LitrosAlcool += (CapacidadeTanque - LitrosAlcool - LitrosGasolina);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("O Tanque está cheio");
                            Console.ResetColor();
                            Console.WriteLine("\nAperte qualquer coisa para continuar...");
                        }

                        else if (opcao == "gasolina")
                        {
                            LitrosGasolina += (CapacidadeTanque - LitrosAlcool - LitrosGasolina);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("O Tanque está cheio");
                            Console.ResetColor();
                            Console.WriteLine("\nAperte qualquer coisa para continuar...");
                        }
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Carro do tipo Flex");
                        Console.WriteLine("Deseja abastecer alcool ou gasolina?");
                        opcao = val.ValidarTipoCombustivel(Console.ReadLine().ToLower()); // Opção para escolher caso queira abastecer ou encher o tanque 
                        if (opcao == "gasolina")
                        {
                            Console.Clear();
                            Console.WriteLine($"Quantidade no tanque {LitrosGasolina.ToString("F2")} litros");
                            Console.WriteLine("Quanto deseja abastecer de gasolina?");
                            Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {CapacidadeTanque} LITROS ");
                            Litros = val.ValidarLitros(Console.ReadLine()); // Opção para escolher caso queira abastecer ou encher o tanque 

                            while (Litros > CapacidadeTanque || Litros + LitrosGasolina + LitrosAlcool > CapacidadeTanque)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ultrapassou o limite digite novamente");
                                Console.ResetColor();
                                Litros = val.ValidarLitros(Console.ReadLine());
                            }

                            LitrosGasolina += Litros;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n\n O Carro foi Abastecido Há {LitrosGasolina.ToString("F2")} Litros");
                            Console.ResetColor();
                            Console.WriteLine("\nAperte qualquer coisa para continuar...");
                        }
                        else if (opcao == "alcool")
                        {
                            Console.Clear();
                            Console.WriteLine($"Quantidade no tanque {LitrosAlcool.ToString("F2")} litros");
                            Console.WriteLine("Quanto deseja abastecer de gasolina?");
                            Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {CapacidadeTanque} LITROS ");
                            Litros = val.ValidarLitros(Console.ReadLine()); // Opção para escolher caso queira abastecer ou encher o tanque 

                            while (Litros > CapacidadeTanque || Litros + LitrosAlcool + LitrosGasolina > CapacidadeTanque)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ultrapassou o limite digite novamente");
                                Console.ResetColor();
                                Litros = val.ValidarLitros(Console.ReadLine());
                            }

                            LitrosAlcool += Litros;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n\n O Carro foi Abastecido Há {LitrosAlcool.ToString("F2")} Litros");
                            Console.ResetColor();
                            Console.WriteLine("\nAperte qualquer coisa para continuar...");
                        }

                    }
                }
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

            else if (Flex == "S")
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
                sb.AppendLine($"Seu tipo de combustivel é {TipoCombustivel}, com seu Tanque inicial {LitrosGasolina} e com a autonomia de {AutonomiaGasolina} KM para percorrer como tanque cheio");
            else if (TipoCombustivel == "alcool")
                sb.AppendLine($"Seu tipo de combustivel é {TipoCombustivel}, com seu Tanque inicial {LitrosAlcool} e com a autonomia de {AutonomiaAlcool} KM para percorrer como tanque cheio");
            else if (Flex == "S")
                sb.AppendLine($"Carro do tipo felex com seu Tanque inicial {LitrosAlcool} de alcool e {LitrosGasolina} de gasolina e com " +
                    $"a autonomia de {AutonomiaAlcool} KM para percorrer com tanque cheio de alcool" +
                    $"e com a autonomia de {AutonomiaGasolina} KM para percorrer com o tanque cheio de gasolina");
            return sb.ToString();
        }

    }
}
