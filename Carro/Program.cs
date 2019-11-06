using System;

namespace ProjetoVeiculo
{
    class Program
    {
        static void Main(string[] args)
        {
            AgênciaDeViagens agênciaDeViagens = new AgênciaDeViagens();
            MenuGlobal menu = new MenuGlobal();
            menu.MenuInicial(agênciaDeViagens);

        }
    }
}
