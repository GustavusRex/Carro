using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoVeiculo
{
    class Menu
    {
        public int opcao;
        public void Menyu(Carro carro)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Digite 1 para cadastrar um carro");
                Console.WriteLine("Digite 2 para exibir o carro");
                Console.WriteLine("Digite 3 para abastecer o carro ");
                Console.WriteLine("Digite 4 para dirigir");
                Console.WriteLine("Digite 0 para sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Cadastrar um carro selecionado\n");
                            carro.CadastrarVeiculo();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Exibir o carro selecionado\n");
                            Console.WriteLine(carro);
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Abastecer o carro selecionado\n");
                            carro.Abastecer();
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Digirir o carro selecionado\n");
                            carro.Dirigir();
                            Console.ReadKey();
                            break;
                        }
                }

            } while (opcao != 0);
        }
    }
}
