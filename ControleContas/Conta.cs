using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Conta
    {
        private static decimal _saldoTotalGeral = 0;
        private static Conta _contaMaiorSaldo = null;

        private long _numero;
        private decimal _saldo;

        public Cliente Titular { get; private set; }
        public Agencia Agencia { get; private set; }

        public Conta(long numero, decimal saldoInicial, Cliente titular, Agencia agencia)
        {
            if (titular == null)
                throw new ArgumentNullException(nameof(titular), "A conta precisa de um titular.");

            if (agencia == null)
                throw new ArgumentNullException(nameof(agencia), "A conta precisa pertencer a uma agência.");

            if (saldoInicial <= 10)
                throw new ArgumentException("O saldo inicial deve ser superior a R$10,00.");

            _numero = numero;
            _saldo = saldoInicial;
            Titular = titular;
            Agencia = agencia;

            _saldoTotalGeral += saldoInicial;
            AtualizarContaMaiorSaldo();
        }

        public long Numero
        {
            get { return _numero; }
            private set { _numero = value; }
        }

        public decimal Saldo
        {
            get { return _saldo; }
            private set { _saldo = value; }
        }

        public void Depositar(decimal value)
        {
            if (value <= 0)
            {
                Console.WriteLine("Valor inválido para depósito.");
                return;
            }

            _saldo += value;
            _saldoTotalGeral += value;
            AtualizarContaMaiorSaldo();
        }

        public static decimal SaldoTotalGeral
        {
            get { return _saldoTotalGeral; }
        }

        public static Conta ContaMaiorSaldo
        {
            get { return _contaMaiorSaldo; }
        }

        private void AtualizarContaMaiorSaldo()
        {
            if (_contaMaiorSaldo == null || this._saldo > _contaMaiorSaldo._saldo)
            {
                _contaMaiorSaldo = this;
            }
        }

        public decimal Sacar(decimal valor)
        {
            const decimal taxa = 0.10m;
            decimal total = valor + taxa;

            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido para saque!");
                return _saldo;
            }

            if (total > _saldo)
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
                return _saldo;
            }

            _saldo -= total;
            _saldoTotalGeral -= total;

            Console.WriteLine($"Saque de R${valor:F2} realizado com taxa de R$0,10. Novo saldo: R${_saldo:F2}");
            AtualizarContaMaiorSaldo();
            return _saldo;
        }

        public void Transferir(decimal valor, Conta contaDestino)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido para transferência!");
                return;
            }

            if (valor > _saldo)
            {
                Console.WriteLine("Saldo insuficiente para transferência!");
                return;
            }

            _saldo -= valor;
            contaDestino._saldo += valor;

            Console.WriteLine($"Transferência de R${valor:F2} realizada com sucesso!");
            Console.WriteLine($"Saldo da conta {Numero}: R${_saldo:F2}");
            Console.WriteLine($"Saldo da conta {contaDestino.Numero}: R${contaDestino._saldo:F2}");

            AtualizarContaMaiorSaldo();
        }

            public static void MostrarResumoConta(Conta conta)
        {
            if (conta == null)
            {
                Console.WriteLine("Conta inválida!");
                return;
            }

            Console.WriteLine($"Conta {conta.Numero} | Titular: {conta.Titular.Nome} | Saldo: R${conta.Saldo:F2} | " +
                $"Agência: {conta.Agencia.Numero} | Banco: {conta.Agencia.Banco.Nome}");
        }

    }
}

