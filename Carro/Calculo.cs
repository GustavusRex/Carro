﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoVeiculo
{
    static class Calculo
    {
        public static double CalcularAbastecimento(double capacidadeTanque, double tanque)
        {
            string opcao;
            double litros;

            if (tanque == capacidadeTanque)
            {//  Testa se o tanque está cheio
                Console.WriteLine("\nTanque está cheio" +
                    " Aperte qualquer coisa para continuar...");
            }

            else if (tanque < capacidadeTanque)
            {
                Console.WriteLine("Deseja encher o tanque?");
                opcao = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper()); // Opção para escolher caso queira abastecer ou encher o tanque 
                if (opcao == "S")
                {
                    tanque += (capacidadeTanque - tanque);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("O Tanque está cheio"); Console.ResetColor();
                    Console.WriteLine("\nAperte qualquer coisa para continuar...");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\nQuantidade no tanque {tanque.ToString("F2")} litros");
                    Console.WriteLine("Quanto deseja abastecer ?");
                    Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {capacidadeTanque} LITROS ");
                    litros = Validacao.ValidarLitros(Console.ReadLine());

                    while (litros > capacidadeTanque || litros + tanque > capacidadeTanque)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nUltrapassou o limite digite novamente"); Console.ResetColor();
                        litros = Validacao.ValidarLitros(Console.ReadLine());
                    }

                    tanque += litros;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\nO Carro foi Abastecido! Há {tanque.ToString("F2")} Litros"); Console.ResetColor();

                }

            }
            return tanque;
        }
        public static double CalcularAbastecimentoFlex(double capacidadeTanque, double tanqueG, double tanqueA)
        {
            double litros;
            double tanqueflex = 0;

            Console.Clear();
            Console.WriteLine($"Quantidade no tanque {(tanqueG + tanqueA).ToString("F2")} litros");
            Console.WriteLine("Quanto deseja abastecer?");
            Console.WriteLine($"LEMBRE-SE A CAPACIDADE TOTAL DO TANQUE É {capacidadeTanque} LITROS ");
            litros = Validacao.ValidarLitros(Console.ReadLine()); // Opção para escolher caso queira abastecer ou encher o tanque 

            while (litros > capacidadeTanque || litros + tanqueG + tanqueA > capacidadeTanque)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ultrapassou o limite digite novamente");
                Console.ResetColor();
                litros = Validacao.ValidarLitros(Console.ReadLine());
            }

            tanqueflex += litros;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\n O Carro foi Abastecido Há {(tanqueflex + tanqueG + tanqueA).ToString("F2")} Litros");
            Console.ResetColor();
            Console.WriteLine("\nAperte qualquer coisa para continuar...");

            return tanqueflex;
        }

        public static double CalcularAutonomia(Viagem viagem, Carro carro, double alcool, double gasolina)
        {
            double autonomia = 0;
           if (viagem.Clima == 1)
            {
                autonomia = alcool + gasolina;
                if (carro.EstadoPneu == 2)
                    autonomia -= autonomia * 0.0725;
                else if (carro.EstadoPneu == 1)
                    autonomia -= autonomia * 0.0915;
            }
            else if (viagem.Clima == 2)
            {
                if (carro.TipoCombustivel == "gasolina")
                {
                    gasolina -= gasolina * 0.12;
                    autonomia = gasolina;

                    if (carro.EstadoPneu == 2)
                        autonomia -= autonomia * 0.0725;
                    else if (carro.EstadoPneu == 1)
                        autonomia -= autonomia * 0.0915;
                }
                else if (carro.TipoCombustivel == "alcool")
                {
                    alcool -= alcool * 0.12;
                    alcool -= alcool * 0.30;
                    autonomia = alcool;
                    if (carro.EstadoPneu == 2)
                        autonomia -= autonomia * 0.0725;
                    else if (carro.EstadoPneu == 1)
                        autonomia -= autonomia * 0.0915;
                }

            }
            else if (viagem.Clima == 3)
            {
                if (carro.TipoCombustivel == "gasolina")
                {
                    gasolina -= gasolina * 0.19;
                    autonomia = gasolina;

                    if (carro.EstadoPneu == 2)
                        autonomia -= autonomia * 0.0725;
                    else if (carro.EstadoPneu == 1)
                        autonomia -= autonomia * 0.0915;
                }
                else if (carro.TipoCombustivel == "alcool")
                {
                    alcool -= alcool * 0.19;
                    alcool -= alcool * 0.30;
                    autonomia = alcool;
                    if (carro.EstadoPneu == 2)
                        autonomia -= autonomia * 0.0725;
                    else if (carro.EstadoPneu == 1)
                        autonomia -= autonomia * 0.0915;
                }

            }
            return autonomia;
        }

        public static double CalcularAutonomiaFlexA(Viagem viagem, Carro carro)
        {
            double autonomia = 0;
            if (viagem.Clima == 1)
            {
                autonomia = carro.KmPorAlcool;
                if (carro.EstadoPneu == 2)
                    autonomia -= autonomia * 0.0725;
                else if (carro.EstadoPneu == 1)
                    autonomia -= autonomia * 0.0915;
            }
            else if (viagem.Clima == 2)
            {
                carro.KmPorGasolina -= carro.KmPorGasolina * 0.12;
                carro.KmPorAlcool -= carro.KmPorGasolina * 0.30;
                autonomia = carro.KmPorAlcool;
                if (carro.EstadoPneu == 2)
                    autonomia -= autonomia * 0.0725;
                else if (carro.EstadoPneu == 1)
                    autonomia -= autonomia * 0.0915;
            }
            else if (viagem.Clima == 3)
            {
                carro.KmPorGasolina -= carro.KmPorGasolina * 0.19;
                carro.KmPorAlcool -= carro.KmPorGasolina * 0.30;
                autonomia = carro.KmPorAlcool;
                if (carro.EstadoPneu == 2)
                    autonomia -= autonomia * 0.0725;
                else if (carro.EstadoPneu == 1)
                    autonomia -= autonomia * 0.0915;
            }
            return autonomia;
        }
           
        public static double CalcularAutonomiaFlexG(Viagem viagem, Carro carro)
        {
            double autonomia = 0;
            if (viagem.Clima == 1)
            {
                autonomia = carro.KmPorGasolina;
                if (carro.EstadoPneu == 2)
                    autonomia -= autonomia * 0.0725;
                else if (carro.EstadoPneu == 1)
                    autonomia -= autonomia * 0.0915;
            }
            else if (viagem.Clima == 2)
            {
                carro.KmPorGasolina -= carro.KmPorGasolina * 0.12;
                autonomia = carro.KmPorGasolina;
                if (carro.EstadoPneu == 2)
                    autonomia -= autonomia * 0.0725;
                else if (carro.EstadoPneu == 1)
                    autonomia -= autonomia * 0.0915;
            }
            else if (viagem.Clima == 3)
            {
                carro.KmPorGasolina -= carro.KmPorGasolina * 0.19;
                autonomia = carro.KmPorGasolina;
                if (carro.EstadoPneu == 2)
                    autonomia -= autonomia * 0.0725;
                else if (carro.EstadoPneu == 1)
                    autonomia -= autonomia * 0.0915;
            }
            return autonomia;
        }
    }

    
}



