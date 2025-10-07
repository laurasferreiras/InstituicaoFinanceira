using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace ControleContas
{
    public class Conta
    {
        public Conta(string titular, long numero, decimal saldoInicial)
        {
            if (string.IsNullOrWhiteSpace(titular))
            {
                Console.WriteLine("Erro: a conta precisa ter um titular.");
                return;
            }

            if (saldoInicial < 10)
            {
                Console.WriteLine("Erro: saldo inicial deve ser no mínimo R$10,00.");
                return;
            }

            _titular = titular;
            _numero = numero;
            _saldo = saldoInicial;
        }

        private string _titular;
        public string Titular
        {
            get { return _titular; }
            private set { _titular = value; }
        }

        private long _numero;
        public long Numero
        {
            get { return _numero; }
            private set { _numero = value; }
        }


        private decimal _saldo;
        public decimal Saldo
        {
            get { return _saldo; }
            private set { _saldo = value; }
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor negativo");
                return;
            }
            _saldo += valor;
        }

        public decimal Sacar(decimal valor)
        {
            decimal taxa = 0.10m;
            if (valor <= 0)
            {
                Console.WriteLine("Valor negativo.");
                return _saldo;
            }

            if (valor > _saldo)
            {
                Console.WriteLine("Saldo insuficiente.");
                return _saldo;
            }

            _saldo -= (valor + taxa);
            return _saldo;

        }

        public void Transferir(decimal valor, Conta contaDestino)
        {
            if (contaDestino == null)
            {
                Console.WriteLine("Conta de destino inválida.");
                return;
            }

            if (valor <= 0)
            {
                Console.WriteLine("Valor de transferência inválido.");
                return;
            }

            if (valor > _saldo)
            {
                Console.WriteLine("Saldo insuficiente para transferência.");
                return;
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);

            Console.WriteLine($"Transferência de R${valor:F2} realizada com sucesso!");
            Console.WriteLine($"Saldo de {Titular}: R${Saldo:F2}");
            Console.WriteLine($"Saldo de {contaDestino.Titular}: R${contaDestino.Saldo:F2}");

        }
    }
}
