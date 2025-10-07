using ControleContas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ControleContas.Tests
{
    [TestClass]
    public class BancoTests
    {
        [TestMethod]
        public void TestarCriacaoBancoValido()
        {
            // cenário
            string nome = "Banco Itaú";
            int numero = 1;

            // ação
            Banco banco = new Banco(nome, numero);

            // verificação
            Assert.AreEqual(nome, banco.Nome);
            Assert.AreEqual(numero, banco.Numero);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarCriacaoBancoComNomeInvalido()
        {
            // nome vazio
            Banco banco = new Banco("", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarCriacaoBancoComNumeroInvalido()
        {
            // número negativo
            Banco banco = new Banco("Banco Teste", -5);
        }
    }
}