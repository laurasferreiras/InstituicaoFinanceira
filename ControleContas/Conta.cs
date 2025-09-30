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
        public Conta(long numero) 
        {
            this.Numero = numero;
        }

        public Conta() 
        {
            _numero = new Random().Next(10, 999999999);
        }

        private long _numero;
        public long Numero
        {
            get
            {
                return _numero;
            }
            private set
            {
                _numero = value;
            }
        }


        private decimal _saldo;
        public decimal Saldo { get { return _saldo; } private set { _saldo = value; } }

        public void Depositar(decimal valor)
        {
            if (valor < 0)
            {
                Console.WriteLine("Valor negativo");
                return;
            }
            _saldo += valor;
        } 


    }
}
