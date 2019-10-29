using System;

namespace ProjetoVeiculo
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Carro carro = new Carro();
            menu.Menyu(carro);
        }
    }
}
