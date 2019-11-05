using System;
using System.Text;

namespace ProjetoVeiculo
{
    class Carro : Veiculo
    {
       

        public void CadastrarCarro()
        {
            Console.WriteLine("Cadastro de Carro Selecionado");
            Console.Write("\nDigite a marca do veículo: ");
            Marca = Validacao.ValidarDescricao(Console.ReadLine());
            Console.Write("\nDigite o tipo de modelo do veiculo: ");
            Modelo = Validacao.ValidarDescricao(Console.ReadLine());
            Console.Write("\nDigite a placa do veículo, EXEMPLO DE PLACA(KUR-2202): ");
            Placa = Validacao.ValidarPlaca(Console.ReadLine().ToUpper());
            Console.Write("\nDigite o ano entre 1910 e 2019: ");
            Ano = Validacao.ValidarAno(Console.ReadLine());
            Console.Write("\nDigite o estado do pneu atual: ");
            EstadoPneuAtual = Validacao.Validar3opcoes(Console.ReadLine());
            Console.Write("\nDigite a velocidade maxima do veiculo: ");
            VelocidadeMaxima = Validacao.ValidarNumerosDouble(Console.ReadLine());
            Console.Write("\nDigite a capacidade maxima do tanque de combustivel: ");
            CapacidadeTanque = Validacao.ValidarNumerosDouble(Console.ReadLine());
            Console.WriteLine("\nO veículo é do tipo flex? " +
                         "Digite S para Sim e N para Não");
            Flex = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper()) == "S" ? true : false;

            if (Flex)
            {
                Console.WriteLine("\nDigite a Kilometragem por Litro de Gasolina (Entre 1 até 15): ");
                KmPorGasolinaAtual = Validacao.ValidarAutonomia(Console.ReadLine());
                Console.WriteLine("\nDigite a Kilometragem por Litro de Alcool (Entre 1 até 15): ");
                KmPorAlcoolAtual = Validacao.ValidarAutonomia(Console.ReadLine());
            }

            if (Flex == false)
            {
                Console.WriteLine("\nQual o tipo de Combustivel (Entre gasolina e alcool) que o veículo utiliza? ");
                TipoCombustivel = Validacao.ValidarTipoCombustivel(Console.ReadLine().ToLower());

                if (TipoCombustivel == "gasolina")
                {
                    Console.WriteLine("Digite a Kilometragem por Litro de Gasolina (Entre 1 até 15): ");
                    KmPorGasolinaAtual = Validacao.ValidarAutonomia(Console.ReadLine());
                }
                else if (TipoCombustivel == "alcool")
                {
                    Console.WriteLine("\nDigite a Kilometragem por Litro de Alcool (Entre 1 até 15): ");
                    KmPorAlcoolAtual = Validacao.ValidarAutonomia(Console.ReadLine());

                }
            }
        }

        public void Abastecer()
        {
            string opcao;
            if (Placa == null)
            {
                Console.WriteLine("Carro Não existe" +
                    " Aperte qualquer coisa para continuar..."); return;
            }
            else if (TipoCombustivel == "gasolina")
            {
                AbastecerVeiculoPadrão();

                if (EstadoPneu == 1 || EstadoPneu == 2)
                {
                    Console.WriteLine("\nVocê está no posto, seu pneu está mal calibrado... deseja calibrar parar melhorar o desempenho?");
                    opcao = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper());
                    if (opcao == "S")
                        Calibrar();
                    Console.WriteLine("\nAperte qualquer coisa para continuar...");

                }
                Console.WriteLine("\nAperte qualquer coisa para continuar...");

            }
            else if (TipoCombustivel == "alcool")
            {
                AbastecerVeiculoPadrão();

                if (EstadoPneu == 1 || EstadoPneu == 2)
                {
                    Console.WriteLine("Você está no posto, seu pneu está mal calibrado... deseja calibrar parar melhorar o desempenho?");
                    opcao = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper());
                    if (opcao == "S")
                        Calibrar();
                    Console.WriteLine("\nAperte qualquer coisa para continuar...");

                }
                Console.WriteLine("\nAperte qualquer coisa para continuar...");

            }
            else if (Flex)
            {
                AbastecerVeiculoFlex(Litros);

                if (EstadoPneu == 1 || EstadoPneu == 2)
                {
                    Console.WriteLine("Você está no posto, seu pneu está mal calibrado... deseja calibrar parar melhorar o desempenho?");
                    opcao = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper());
                    if (opcao == "S")
                        Calibrar();
                    Console.WriteLine("\nAperte qualquer coisa para continuar...");

                }
                Console.WriteLine("\nAperte qualquer coisa para continuar...");
            }

        }

        public void Dirigir(Viagem viagem)
        {
            if (TipoCombustivel == "gasolina")
                DirigirVeiculoPadrão(viagem, this, LitrosGasolina);
            else if (TipoCombustivel == "alcool")
                DirigirVeiculoPadrão(viagem, this, LitrosAlcool);
            else if (Flex)
                DirigirVeiculoFlex(viagem, this); 
        }

        public override string ToString()
        {
            if (Placa == null)
                Console.WriteLine("Carro Não existe" +
                    " Aperte qualquer coisa para continuar...");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"O carro da marca {Marca}, do modelo {Modelo} com a placa {Placa}");
            sb.AppendLine($"Sendo do ano {Ano}, alcança a velocidade maxima de {VelocidadeMaxima}, tem a capacidade de {CapacidadeTanque} litros e o estado do pneu é {EstadoPneu}");
            if (TipoCombustivel == "gasolina")
                sb.AppendLine($"Seu tipo de combustivel é {TipoCombustivel}, com seu Tanque inicial {LitrosGasolina} e com a autonomia de {KmPorGasolina} KM/L");
            else if (TipoCombustivel == "alcool")
                sb.AppendLine($"Seu tipo de combustivel é {TipoCombustivel}, com seu Tanque inicial {LitrosAlcool} e com a autonomia de {KmPorAlcool} KM/L");
            else if (Flex)
                sb.AppendLine($"Carro do tipo flex com seu Tanque inicial {LitrosAlcool} de alcool e {LitrosGasolina} de gasolina e com " +
                    $"a autonomia de alcool {KmPorAlcool} KM/L " +
                    $"e com a autonomia de gasolina {KmPorGasolina} KM/L");
            return sb.ToString();
        }

    }
}