using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleContas
{
    public class Conta
    {
        private static List<Conta> todasContas = new List<Conta>();
        private static decimal saldoInicialTotal = 0;

        private Cliente _titular;

        public Conta(Cliente titular, long numero, decimal saldoInicial)
        {
            if (titular == null)
            {
                Console.WriteLine("Erro: é necessário informar um cliente titular válido.");
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

            todasContas.Add(this);
            saldoInicialTotal += saldoInicial;
        }

        public Cliente Titular
        {
            get { return _titular; }
        }

        private long _numero;
        public long Numero
        {
            get { return _numero; }
        }

        private decimal _saldo;
        public decimal Saldo
        {
            get { return _saldo; }
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Erro: valor de depósito inválido.");
                return;
            }
            _saldo += valor;
        }

        public decimal Sacar(decimal valor)
        {
            decimal taxa = 0.10m;
            if (valor <= 0)
            {
                Console.WriteLine("Erro: valor inválido.");
                return _saldo;
            }

            if (valor > _saldo)
            {
                Console.WriteLine("Erro: saldo insuficiente.");
                return _saldo;
            }

            _saldo -= (valor + taxa);
            return _saldo;
        }

        public void Transferir(decimal valor, Conta contaDestino)
        {
            if (contaDestino == null)
            {
                Console.WriteLine("Erro: conta de destino inválida.");
                return;
            }

            if (valor <= 0)
            {
                Console.WriteLine("Erro: valor de transferência inválido.");
                return;
            }

            if (valor > _saldo)
            {
                Console.WriteLine("Erro: saldo insuficiente.");
                return;
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);

            Console.WriteLine($"Transferência de R${valor:F2} realizada com sucesso!");
            Console.WriteLine($"Saldo de {Titular.Nome}: R${Saldo:F2}");
            Console.WriteLine($"Saldo de {contaDestino.Titular.Nome}: R${contaDestino.Saldo:F2}");
        }

        public static decimal SaldoTotal()
        {
            return todasContas.Sum(c => c.Saldo);
        }

        public static Conta ContaMaiorSaldo()
        {
            return todasContas.OrderByDescending(c => c.Saldo).FirstOrDefault();
        }

        public static decimal SaldoInicialTotal()
        {
            return saldoInicialTotal;
        }
    }
}
