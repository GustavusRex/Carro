using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoVeiculo
{
   public class CarroViagem:Base
    {
        public Viagem Viagem ;
        public Carro Carro;

        public CarroViagem(Viagem viagem, Carro carro)
        {
            Viagem = viagem;
            Carro = carro;
        }

        public void DirigirPercurso()
        {
            Carro.Dirigir(Viagem);
        }


        
    }
}
