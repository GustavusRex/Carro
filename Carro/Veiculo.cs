using System;


namespace ProjetoVeiculo
{
    abstract class Veiculo
    {
        Validacao val = new Validacao();
        public string Marca;

        public string Modelo;

        public string Placa;

        public uint Ano;

        public double VelocidadeMaxima;

        public double CapacidadeTanque;

        public bool Flex;

        public string TipoCombustivel;


        public virtual void CadastrarVeiculo()
        {
            Console.Write("\nDigite a marca do veículo: ");
            Marca = val.ValidarDescricao(Console.ReadLine());

            Console.Write("\nDigite o tipo de modelo do veiculo: ");
            Modelo = val.ValidarDescricao(Console.ReadLine());

            Console.Write("\nDigite a placa do veículo, EXEMPLO DE PLACA(KUR-2202): ");
            Placa = val.ValidarPlaca(Console.ReadLine().ToUpper());

            Console.Write("\nDigite o ano entre 1910 e 2019 : ");
            Ano = val.ValidarAno(Console.ReadLine());

            Console.Write("\nDigite a velocidade maxima do veiculo: ");
            VelocidadeMaxima = val.ValidarNumerosDouble(Console.ReadLine());

            Console.Write("\nDigite a capacidade maxima do tanque de combustivel: ");
            CapacidadeTanque = val.ValidarNumerosDouble(Console.ReadLine());

            Console.WriteLine("\nO veículo é do tipo flex? " +
                         "Digite S para Sim e N para Não");
            Flex = val.ValidarSimOuNao(Console.ReadLine().ToUpper()) == "S"? true:false;

            if (Flex == false)
            {
                Console.WriteLine("\nQual o tipo de Combustivel (Entre gasolina e alcool) que o veículo utiliza? ");
                TipoCombustivel = val.ValidarTipoCombustivel(Console.ReadLine().ToLower());
            }

        }

        public virtual void AbastecerVeiculoPadrão(double capacidadeTanque, double litrosCombustivel, double litros)
        {
            string opcao;

            if (litrosCombustivel == capacidadeTanque)
            {//  Testa se o tanque está cheio
                Console.WriteLine("\nTanque está cheio" +
                    " Aperte qualquer coisa para continuar..."); return;
            }

            else if (litrosCombustivel < capacidadeTanque)
            {
                Console.WriteLine("Deseja encher o tanque?");
                opcao = val.ValidarSimOuNao(Console.ReadLine().ToUpper()); // Opção para escolher caso queira abastecer ou encher o tanque 
                if (opcao == "S")
                {
                    litrosCombustivel += (capacidadeTanque - litrosCombustivel);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("O Tanque está cheio"); Console.ResetColor();
                    Console.WriteLine("\nAperte qualquer coisa para continuar...");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\nQuantidade no tanque {litrosCombustivel.ToString("F2")} litros");
                    Console.WriteLine("Quanto deseja abastecer ?");
                    Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {capacidadeTanque} LITROS ");
                    litros = val.ValidarLitros(Console.ReadLine());

                    while (litros > capacidadeTanque || litros + litrosCombustivel > capacidadeTanque)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nUltrapassou o limite digite novamente"); Console.ResetColor();
                        litros = val.ValidarLitros(Console.ReadLine());
                    }

                    litrosCombustivel += litros;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\nO Carro foi Abastecido! Há {litrosCombustivel.ToString("F2")} Litros"); Console.ResetColor();
                    Console.WriteLine("\nAperte qualquer coisa para continuar...");

                }
            }

        }

        public virtual void AbastecerVeiculoFlex(double capacidadeTanque, double litrosCombustivelTanqueG, double litrosCombustivelTanqueA, double litros)
        {
            string opcao;

            if (litrosCombustivelTanqueA + litrosCombustivelTanqueA == capacidadeTanque)
            {
                Console.WriteLine("\nTanque está cheio" +
                       " Aperte qualquer coisa para continuar..."); return;
            }

            else if (litrosCombustivelTanqueA + litrosCombustivelTanqueG < capacidadeTanque)
            {
                Console.WriteLine("\nDeseja encher o tanque?");
                opcao = val.ValidarSimOuNao(Console.ReadLine().ToUpper());
                if (opcao == "S")
                {
                    Console.WriteLine("\nQuer encher o tanque de alcool ou gasolina?");
                    opcao = val.ValidarTipoCombustivel(Console.ReadLine().ToLower()); // Opção para escolher caso queira abastecer ou encher o tanque 
                    if (opcao == "alcool")
                    {
                        litrosCombustivelTanqueA += (capacidadeTanque - litrosCombustivelTanqueA - litrosCombustivelTanqueG);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("O Tanque está cheio");
                        Console.ResetColor();
                        Console.WriteLine("\nAperte qualquer coisa para continuar...");
                    }

                    else if (opcao == "gasolina")
                    {
                        litrosCombustivelTanqueG += (capacidadeTanque - litrosCombustivelTanqueA - litrosCombustivelTanqueG);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("O Tanque está cheio");
                        Console.ResetColor();
                        Console.WriteLine("\nAperte qualquer coisa para continuar...");
                    }
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
                    Console.WriteLine($"Quantidade no tanque {litrosCombustivelTanqueG.ToString("F2")} litros");
                    Console.WriteLine("Quanto deseja abastecer de gasolina?");
                    Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {capacidadeTanque} LITROS ");
                    litros = val.ValidarLitros(Console.ReadLine()); // Opção para escolher caso queira abastecer ou encher o tanque 

                    while (litros > capacidadeTanque || litros + litrosCombustivelTanqueG + litrosCombustivelTanqueA > capacidadeTanque)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ultrapassou o limite digite novamente");
                        Console.ResetColor();
                        litros = val.ValidarLitros(Console.ReadLine());
                    }

                    litrosCombustivelTanqueG += litros;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\n O Carro foi Abastecido Há {litrosCombustivelTanqueG.ToString("F2")} Litros");
                    Console.ResetColor();
                    Console.WriteLine("\nAperte qualquer coisa para continuar...");
                }
                else if (opcao == "alcool")
                {
                    Console.Clear();
                    Console.WriteLine($"Quantidade no tanque {litrosCombustivelTanqueA.ToString("F2")} litros");
                    Console.WriteLine("Quanto deseja abastecer de gasolina?");
                    Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {capacidadeTanque} LITROS ");
                    litros = val.ValidarLitros(Console.ReadLine()); // Opção para escolher caso queira abastecer ou encher o tanque 

                    while (litros > capacidadeTanque || litros + litrosCombustivelTanqueA + litrosCombustivelTanqueG > capacidadeTanque)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ultrapassou o limite digite novamente");
                        Console.ResetColor();
                        litros = val.ValidarLitros(Console.ReadLine());
                    }

                    litrosCombustivelTanqueA += litros;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\n O Carro foi Abastecido Há {litrosCombustivelTanqueA.ToString("F2")} Litros");
                    Console.ResetColor();
                    Console.WriteLine("\nAperte qualquer coisa para continuar...");
                }
            }
        }

        public virtual void DirigirVeiculo()
        {

        }

    }
}