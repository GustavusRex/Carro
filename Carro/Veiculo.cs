using System;
namespace ProjetoVeiculo
{
    abstract class Veiculo
    {

        public string Marca;
        public string Modelo;
        public string Placa;
        public uint Ano;
        public int EstadoPneu;
        public double VelocidadeMaxima;
        public double CapacidadeTanque;
        public bool Flex;
        public string TipoCombustivel;
        public double KmPorAlcool;
        public double KmPorGasolina;
        public double Litros;
        public double LitrosGasolina;
        public double LitrosAlcool;

        public virtual void AbastecerVeiculoPadrão() 
        {
            if (TipoCombustivel == "gasolina")
            {
                LitrosGasolina += Calculo.CalcularAbastecimento(CapacidadeTanque, LitrosGasolina);

            }
            else if (TipoCombustivel == "alcool")
            {
                LitrosAlcool += Calculo.CalcularAbastecimento(CapacidadeTanque, LitrosAlcool);

            }

        }

        public virtual void AbastecerVeiculoFlex(double litros)
        {
            string opcao;

            if (LitrosGasolina + LitrosAlcool == CapacidadeTanque)
            {
                Console.WriteLine("\nTanque está cheio" +
                       " Aperte qualquer coisa para continuar..."); return;
            }

            else if (LitrosAlcool + LitrosGasolina < CapacidadeTanque)
            {
                Console.WriteLine("\nDeseja encher o tanque?");
                opcao = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper());
                if (opcao == "S")
                {
                    Console.WriteLine("\nQuer encher o tanque de alcool ou gasolina?");
                    opcao = Validacao.ValidarTipoCombustivel(Console.ReadLine().ToLower()); // Opção para escolher caso queira abastecer ou encher o tanque 
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
                    opcao = Validacao.ValidarTipoCombustivel(Console.ReadLine().ToLower()); // Opção para escolher caso queira abastecer ou encher o tanque 
                    if (opcao == "gasolina")
                    {
                        LitrosGasolina += Calculo.CalcularAbastecimentoFlex(CapacidadeTanque, LitrosGasolina, LitrosAlcool);
                    }
                    else if (opcao == "alcool")
                    {
                        LitrosAlcool += Calculo.CalcularAbastecimentoFlex(CapacidadeTanque, LitrosGasolina, LitrosAlcool);
                    }
                }
            }
            
        }

        public virtual void DirigirVeiculoPadrão(Viagem viagem, Carro carro, double litrosCombustivelTanque)
        {

            Console.WriteLine("O clima qual o tipo de clima [1] = Sol [2] = Chuva [3] = Neve");
            viagem.Clima = Validacao.Validar3opcoes(Console.ReadLine());
            Console.WriteLine("Qual a distância da viagem?");
            viagem.Distancia = Validacao.ValidarNumerosDouble(Console.ReadLine());
            double Autonomia;

            KmPorAlcool = (viagem.ClimaRuim ? KmPorAlcool -= KmPorAlcool * 0.135 : KmPorAlcool);
            KmPorGasolina = (viagem.ClimaRuim ? KmPorGasolina -= KmPorGasolina * 0.12 : KmPorGasolina);
            Autonomia = KmPorAlcool + KmPorGasolina;
            do
            {
                if (EstadoPneu == 1)
                    Autonomia -= Autonomia * 0.0915;
                else if (EstadoPneu == 2)
                    Autonomia -= Autonomia * 0.725;

                litrosCombustivelTanque = LitrosGasolina + LitrosAlcool;
                if (litrosCombustivelTanque * Autonomia < viagem.Distancia)
                {
                    viagem.Distancia -= litrosCombustivelTanque * Autonomia;
                    litrosCombustivelTanque = 0;
                    LitrosAlcool = 0;
                    LitrosGasolina = 0;
                }
                else if (litrosCombustivelTanque * Autonomia > viagem.Distancia)
                {
                    litrosCombustivelTanque = viagem.Distancia / Autonomia;
                    LitrosGasolina = viagem.Distancia / Autonomia;
                    LitrosAlcool = viagem.Distancia / Autonomia;
                    viagem.Distancia = 0;
                }
                else if (litrosCombustivelTanque * Autonomia == viagem.Distancia)
                {
                    viagem.Distancia = 0;
                    litrosCombustivelTanque = 0;
                    LitrosAlcool = 0;
                    LitrosGasolina = 0;
                }
                if (litrosCombustivelTanque == 0 && viagem.Distancia > 0)
                {
                    Console.WriteLine($"O tanque está com {litrosCombustivelTanque.ToString("F2")} litros, Ainda falta {viagem.Distancia}KM para percorrer\n");
                    carro.Abastecer();
                }
            } while (viagem.Distancia > 0);
            Console.WriteLine($"Viagem Concluída há {litrosCombustivelTanque.ToString("F2")} litros no tanque e o Estado do pneu é {EstadoPneu}");
            Console.WriteLine("\nAperte qualquer coisa para continuar...");
        }

        public virtual void DirigirVeiculoFlex(Viagem viagem, Carro carro)
        {
            Console.WriteLine("O clima está ruim?");
            viagem.Clima = Validacao.Validar3opcoes(Console.ReadLine());
            Console.WriteLine("Digite a distância da viagem");
            viagem.Distancia = Validacao.ValidarNumerosDouble(Console.ReadLine());

            KmPorAlcool = (viagem.ClimaRuim ? KmPorAlcool -= KmPorAlcool * 0.135 : KmPorAlcool);
            KmPorGasolina = (viagem.ClimaRuim ? KmPorGasolina -= KmPorGasolina * 0.12 : KmPorGasolina);

            do
            {
                if (EstadoPneu == 1)
                {
                    KmPorAlcool -= KmPorAlcool * 0.0915;
                    KmPorGasolina -= KmPorGasolina * 0.0915;
                }
                else if (EstadoPneu == 2)
                {
                    KmPorAlcool -= KmPorAlcool * 0.0725;
                    KmPorGasolina -= KmPorGasolina * 0.725;
                }

                while (LitrosAlcool != 0 && viagem.Distancia > 0)
                {
                    if (LitrosAlcool * KmPorAlcool < viagem.Distancia)
                    {
                        viagem.Distancia -= LitrosAlcool * KmPorAlcool;
                        LitrosAlcool = 0;
                    }
                    else if (LitrosAlcool * KmPorAlcool > viagem.Distancia)
                    {
                        LitrosAlcool -= viagem.Distancia / KmPorAlcool;
                        viagem.Distancia = 0;
                    }
                    else if (LitrosAlcool * KmPorAlcool == viagem.Distancia)
                    {
                        viagem.Distancia = 0;
                        LitrosAlcool = 0;
                    }
                }

                while (LitrosGasolina != 0 && viagem.Distancia > 0)
                {
                    if (LitrosGasolina * KmPorGasolina < viagem.Distancia)
                    {
                        viagem.Distancia -= LitrosGasolina * KmPorGasolina;
                        LitrosGasolina = 0;
                    }
                    else if (LitrosGasolina * KmPorGasolina > viagem.Distancia)
                    {
                        LitrosGasolina -= viagem.Distancia / KmPorGasolina;
                        viagem.Distancia = 0;
                    }
                    else if (LitrosGasolina * KmPorGasolina == viagem.Distancia)
                    {
                        viagem.Distancia = 0;
                        LitrosGasolina = 0;
                    }
                }

                if (LitrosAlcool == 0 && LitrosGasolina == 0 && viagem.Distancia > 0)
                {
                    Console.WriteLine($"O tanque está com {(LitrosAlcool + LitrosGasolina).ToString("F2")} litros, Ainda falta {viagem.Distancia}KM para percorrer\n");
                    carro.Abastecer();
                }

            } while (viagem.Distancia > 0);

        }

        public virtual void Calibrar()
        {
            Console.WriteLine("Deseja qual opção para calibrar o pneu?");
            int opcao = Validacao.ValidarPneu(Console.ReadLine());

            if (opcao == 1)
                EstadoPneu = 1;
            else if (opcao == 2)
                EstadoPneu = 2;
            else
                EstadoPneu = 3;

        }
    }
}