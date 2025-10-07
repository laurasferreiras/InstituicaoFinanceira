using ControleContas;

namespace ControleContas.Tests
{
    [TestClass]
    public class ContaTests
    {
        [TestMethod]
        public void TestarDepositoPositivo()
        {
            Banco banco = new Banco("banco 1", 1);
            Agencia agencia = new Agencia(1, "0000", "1111", banco);
            Cliente cliente = new Cliente("Laura", "44444444444", 25);

            Conta conta = new Conta(1, 200, cliente, agencia);

            conta.Depositar(100);

            Assert.AreEqual(300, conta.Saldo);
        }

        [TestMethod]
        public void TestarDepositoNegativo()
        {
            Banco banco = new Banco("banco 1", 1);
            Agencia agencia = new Agencia(2, "2222", "3333", banco);
            Cliente cliente = new Cliente("Mateus", "77777777777", 20);

            Conta conta = new Conta(2, 50, cliente, agencia);

            conta.Depositar(-50);

            Assert.AreEqual(50, conta.Saldo);
        }
    }
}
