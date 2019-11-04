using System;
namespace ProjetoVeiculo
{
    class Menu
    {
        Viagem viagem = new Viagem();
        public string opcao;
        public void Menyu(Carro carro)
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Digite 1 para cadastrar um carro");
                Console.WriteLine("Digite 2 para exibir o carro");
                Console.WriteLine("Digite 3 para abastecer o carro ");
                Console.WriteLine("Digite 4 para dirigir");
                Console.WriteLine("Digite 0 para sair");
                Console.ResetColor();
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Cadastrar um carro selecionado\n");
                            Console.ResetColor();
                            carro.CadastrarCarro();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nCarro Cadastrado!"); Console.ResetColor();
                            Console.WriteLine("\nAperte qualquer coisa para continuar...");// Cadastrar um veiculo
                            Console.ReadKey();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Exibir o carro selecionado\n");
                            Console.ResetColor();
                            Console.WriteLine(carro); // exibir o carro/ veiculo
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Abastecer o carro selecionado\n");
                            Console.ResetColor();
                            carro.Abastecer(); // Abastecer de combustivel o carro/veiculo
                            Console.ReadKey();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Digirir o carro selecionado\n");
                            Console.ResetColor();
                            carro.Dirigir(viagem); // Dirigir o carro / veiculo
                            Console.ReadKey();
                            break;
                        }
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.ReadKey();
                        break;
                }

            } while (opcao != "0");
        }
    }
}
