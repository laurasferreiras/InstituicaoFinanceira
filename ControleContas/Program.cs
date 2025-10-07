using ControleContas;

Cliente cliente1 = new Cliente("Laura", "12345678901", 25);
Cliente cliente2 = new Cliente("Mateus", "98765432100", 30);
Cliente cliente3 = new Cliente("NovaConta", "11122233344", 28);

cliente1.MostrarDados();
cliente2.MostrarDados();
cliente3.MostrarDados();

Conta conta1 = new Conta(cliente1, 2024101324, 200);
Conta conta2 = new Conta(cliente2, 2024101325, 50);
Conta conta3 = new Conta(cliente3, 654321, 2341.42m);

conta1.Depositar(100);
Console.WriteLine($"\nSaldo {conta1.Titular.Nome} após depósito: R${conta1.Saldo:F2}");

conta1.Sacar(50);
Console.WriteLine($"Saldo {conta1.Titular.Nome} após saque: R${conta1.Saldo:F2}");

conta1.Transferir(30, conta2);
Console.WriteLine($"\nSaldo final {conta1.Titular.Nome}: R${conta1.Saldo:F2}");
Console.WriteLine($"Saldo final {conta2.Titular.Nome}: R${conta2.Saldo:F2}");

Console.WriteLine($"\nSaldo total das contas: R${Conta.SaldoTotal():F2}");
Console.WriteLine($"Conta com maior saldo: {Conta.ContaMaiorSaldo().Titular.Nome}");
Console.WriteLine($"Saldo inicial total geral: R${Conta.SaldoInicialTotal():F2}");



// crie um atributo saldo na classe conta cuja propriedade seja somente leitura 
// crie um projeto de teste para testar a classe Conta 
// ele deverá testar um metodo depositar
//o metodo depositar devera receber u valor decimal positivo
// e incrementar o saldo da conta 