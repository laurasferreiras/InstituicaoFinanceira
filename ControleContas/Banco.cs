using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Banco
    {
        public string Nome { get; private set; }
        public int Numero { get; private set; }

        public Banco(string nome, int numero)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do banco é obrigatório.");
            if (numero <= 0)
                throw new ArgumentException("O número do banco deve ser positivo.");

            Nome = nome;
            Numero = numero;
        }
    }
}