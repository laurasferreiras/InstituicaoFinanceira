using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Agencia
    {
        public int Numero { get; private set; }
        public string Cep { get; private set; }
        public string Telefone { get; private set; }
        public Banco Banco { get; private set; }

        public Agencia(int numero, string cep, string telefone, Banco banco)
        {
            if (numero <= 0)
                throw new ArgumentException("O número da agência deve ser positivo.");
            if (string.IsNullOrWhiteSpace(cep))
                throw new ArgumentException("O CEP da agência é obrigatório.");
            if (string.IsNullOrWhiteSpace(telefone))
                throw new ArgumentException("O telefone da agência é obrigatório.");
            if (banco == null)
                throw new ArgumentNullException(nameof(banco), "A agência deve pertencer a um banco.");

            Numero = numero;
            Cep = cep;
            Telefone = telefone;
            Banco = banco;
        }

    }
}