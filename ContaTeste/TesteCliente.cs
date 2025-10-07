using ControleContas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ControleContas.Tests
{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        public void TestarCriacaoClienteValido()
        {
            // cenário
            string nome = "Laura";
            string cpf = "12345678900";
            int idade = 30;

            // ação
            Cliente cliente = new Cliente(nome, cpf, idade);

            // verificação
            Assert.AreEqual(nome, cliente.Nome);
            Assert.AreEqual(cpf, cliente.CPF);
            Assert.AreEqual(idade, cliente.Idade);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarCriacaoClienteComCpfInvalido()
        {
            // CPF com menos de 11 dígitos
            Cliente cliente = new Cliente("Laura", "12345678", 30);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarCriacaoClienteComIdadeInvalida()
        {
            // idade menor que 18
            Cliente cliente = new Cliente("Laura", "12345678900", 17);
        }
    }
}