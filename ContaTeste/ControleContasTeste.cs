using ControleContas;

namespace ControleContas.Tests
{
    [TestClass]
    public class ContaTests
    {
        [TestMethod]
        public void TestarDepositoPositivo()
        {
            Conta conta = new Conta("Laura", 12345, 0); 
            conta.Depositar(100);
            Assert.AreEqual(100, conta.Saldo);
        }

        [TestMethod]
        public void TestarDepositoNegativo()
        {
            Conta conta = new Conta("Laura", 12345, 0); 
            conta.Depositar(-50);
            Assert.AreEqual(0, conta.Saldo);
        }
    }
}
