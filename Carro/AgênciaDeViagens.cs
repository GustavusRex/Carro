using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoVeiculo
{
    public class AgênciaDeViagens
    {
        public List<Carro> Carros = new List<Carro>();
        public List<Viagem> Viagens = new List<Viagem>();
        public List<CarroViagem> CarroViagens = new List<CarroViagem>();
        int Codigo;

        public void CadastrarCarro()
        {
            Console.Clear();
            Carro carro = new Carro();

            Console.WriteLine("===================Cadastro de Carro Selecionado===================");
            Console.Write("\n\nDigite a marca do veículo: ");
            carro.Marca = Validacao.ValidarDescricao(Console.ReadLine());
            Console.Write("\nDigite o tipo de modelo do veiculo: ");
            carro.Modelo = Validacao.ValidarDescricao(Console.ReadLine());
            Console.Write("\nDigite a placa do veículo, EXEMPLO DE PLACA(KUR-2202): ");
            carro.Placa = Validacao.ValidarPlaca(Console.ReadLine().ToUpper());
            Console.Write("\nDigite o ano entre 1910 e 2019: ");
            carro.Ano = Validacao.ValidarAno(Console.ReadLine());
            Console.Write("\nDigite o estado do pneu atual: ");
            carro.EstadoPneuAtual = Validacao.Validar3opcoesINT(Console.ReadLine());
            Console.Write("\nDigite a velocidade maxima do veiculo: ");
            carro.VelocidadeMaxima = Validacao.ValidarNumerosDouble(Console.ReadLine());
            Console.Write("\nDigite a capacidade maxima do tanque de combustivel: ");
            carro.CapacidadeTanque = Validacao.ValidarNumerosDouble(Console.ReadLine());
            Console.WriteLine("\nO veículo é do tipo flex? " +
                         "Digite S para Sim e N para Não");
            carro.Flex = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper()) == "S" ? true : false;

            if (carro.Flex)
            {
                Console.WriteLine("\nDigite a Kilometragem por Litro de Gasolina (Entre 1 até 15): ");
                carro.KmPorGasolinaAtual = Validacao.ValidarAutonomia(Console.ReadLine());
                Console.WriteLine("\nDigite a Kilometragem por Litro de Alcool (Entre 1 até 15): ");
                carro.KmPorAlcoolAtual = Validacao.ValidarAutonomia(Console.ReadLine());
            }

            if (carro.Flex == false)
            {
                Console.WriteLine("\nQual o tipo de Combustivel (Entre gasolina e alcool) que o veículo utiliza? ");
                carro.TipoCombustivel = Validacao.ValidarTipoCombustivel(Console.ReadLine().ToLower());

                if (carro.TipoCombustivel == "gasolina")
                {
                    Console.WriteLine("Digite a Kilometragem por Litro de Gasolina (Entre 1 até 15): ");
                    carro.KmPorGasolinaAtual = Validacao.ValidarAutonomia(Console.ReadLine());
                }
                else if (carro.TipoCombustivel == "alcool")
                {
                    Console.WriteLine("\nDigite a Kilometragem por Litro de Alcool (Entre 1 até 15): ");
                    carro.KmPorAlcoolAtual = Validacao.ValidarAutonomia(Console.ReadLine());

                }
            }
            Console.WriteLine("Carro Cadastrado Com Sucesso!");
            Console.ReadKey();
            Carros.Add(carro);
        }

        public void CadastrarViagem()
        {
            Console.Clear();
            Viagem viagem = new Viagem();
            Console.WriteLine("===================Cadastro de Viagem Selecionado===================");
            Console.WriteLine("Qual a distância da viagem?");
            viagem.Distancia = Validacao.ValidarNumerosDouble(Console.ReadLine());
            Console.WriteLine("O clima qual o tipo de clima [1] = Sol [2] = Chuva [3] = Neve");
            viagem.ClimaAtual = Validacao.Validar3opcoesString(Console.ReadLine());
            Console.WriteLine("\n Viagem Cadastrada com sucesso!");
            Console.ReadKey();
            Viagens.Add(viagem);
        }

        public void AtribuirCarroAViagem()
        {
            string opcao;
            Console.Clear();
            Console.WriteLine("===================Atribuir Carro a Uma Viagem===================");
            if (Viagens.Count == 0)
            {
                Console.WriteLine("\n\nNão existe viagens cadastradas, cadastre uma!");
                Console.WriteLine("\nDeseja Cadastrar uma Viagem para continuar?");
                opcao = Validacao.ValidarSimOuNao(Console.ReadLine());
                if (opcao == "S")
                    CadastrarViagem();
                else
                    return;
            }
            if (Carros.Count == 0)
            {
                Console.WriteLine("Não existe carros cadastrados, cadastre uma!");
                Console.WriteLine("\nDeseja Cadastrar um Carro para continuar?");
                opcao = Validacao.ValidarSimOuNao(Console.ReadLine());
                if (opcao == "S")
                    CadastrarCarro();
                else
                    return;
            }
            Console.Clear();       
            Console.WriteLine("===================Atribuir Carro a Uma Viagem===================\n\n");

            Console.WriteLine("===================Lista de Viagens===================\n\n");

            Viagens.ForEach(v => {
                Console.WriteLine(v); 
                });

            Console.Write("\n\nDigite a Codigo da viagens: ");
            Codigo = Validacao.ValidarNumerosINT(Console.ReadLine());
            Viagem viagem = Viagens.Find(v => v.ID == Codigo);
            
            

            Console.Clear();

            Console.WriteLine("===================Atribuir Carro a Uma Viagem===================\n\n");

            Console.WriteLine("===================Lista de Carros===================\n\n");

            Carros.ForEach(c => {
                Console.WriteLine(c);
            });

            Console.Write("\n\nDigite a Codigo da viagens: ");
            Codigo = Validacao.ValidarNumerosINT(Console.ReadLine());
            Carro carro = Carros.Find(c => c.ID == Codigo);
            CarroViagens.Add(new CarroViagem(viagem, carro));
            Viagens.Remove(viagem);
            Carros.Remove(carro);
        }

    }
}
