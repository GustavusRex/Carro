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

        public string Flex;

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
            Flex = val.ValidarSimOuNao(Console.ReadLine().ToUpper());

            if (Flex == "N")
            {
                Console.WriteLine("\nQual o tipo de Combustivel (Entre gasolina e alcool) que o veículo utiliza? ");
                TipoCombustivel = val.ValidarTipoCombustivel(Console.ReadLine().ToLower());
            }

        }

    }
}