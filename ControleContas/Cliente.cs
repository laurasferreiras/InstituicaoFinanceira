using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public int Idade { get; private set; }

        public Cliente(string nome, string cpf, int idade)
        {
            if (idade < 18)
            {
                throw new ArgumentException("O cliente deve ter mais de 18 anos.");
            }

            if (cpf.Length != 11 || !long.TryParse(cpf, out _))
            {
                throw new ArgumentException("O CPF deve conter exatamente 11 dígitos numéricos, sem ponto ou traço.");
            }

            Nome = nome;
            CPF = cpf;
            Idade = idade;
        }

        public void MostrarDados()
        {
            Console.WriteLine("Cliente");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Cpf: {CPF}");
            Console.WriteLine($"Ano Nascimento: {Idade}");
        }
    }
}