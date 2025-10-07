using ControleContas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ControleContas.Tests
{
    [TestClass]
    public class AgenciaTests
    {
        [TestMethod]
        public void TestarCriacaoAgenciaValida()
        {
            Banco banco = new Banco("Banco Itaú", 1);
            Agencia agencia = new Agencia(100, "27475-000", "24999999999", banco);

            Assert.AreEqual(100, agencia.Numero);
            Assert.AreEqual("27475-000", agencia.Cep);
            Assert.AreEqual("24999999999", agencia.Telefone);
            Assert.AreEqual(banco, agencia.Banco);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarAgenciaComNumeroInvalido()
        {
            Banco banco = new Banco("Banco Itaú", 1);
            Agencia agencia = new Agencia(0, "27475-000", "24999999999", banco);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarAgenciaComCepInvalido()
        {
            Banco banco = new Banco("Banco Itaú", 1);
            Agencia agencia = new Agencia(100, "", "24999999999", banco);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarAgenciaComTelefoneInvalido()
        {
            Banco banco = new Banco("Banco Itaú", 1);
            Agencia agencia = new Agencia(100, "27475-000", "", banco);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestarAgenciaComBancoNulo()
        {
            Agencia agencia = new Agencia(100, "27475-000", "24999999999", null);
        }
    }
}