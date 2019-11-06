using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoVeiculo
{
    public abstract class Base
    {
        public int ID = new Random().Next(100000, 999999);
        public DateTime DataCadastro = DateTime.Now;
    }
}
