using System;
using ControleContas;

Banco banco1 = new Banco("Banco Itaú", 1);

//recebe numero, cep, telefone e banco
Agencia agencia1 = new Agencia(101, "12345-678", "(24) 998484728", banco1);
Agencia agencia2 = new Agencia(102, "98765-432", "(24) 999344182", banco1);
Agencia agencia3 = new Agencia(103, "55555-000", "(24) 999999999", banco1);

// recebe nome, cpf e idade
Cliente cliente1 = new Cliente("Laura", "11122233344", 19);
Cliente cliente2 = new Cliente("Mateus", "55566677788", 19);
Cliente cliente3 = new Cliente("NovaConta", "12345678910", 28);

cliente1.MostrarDados();
cliente2.MostrarDados();
cliente3.MostrarDados();

// recebe numero da conta, saldo, nome do cliente e sua agencia
Conta conta1 = new Conta(2024101324, 200, cliente1, agencia1);
Conta conta2 = new Conta(2024101325, 50, cliente2, agencia2);
Conta conta3 = new Conta(654321, 2341.42m, cliente3, agencia3);

Conta.MostrarResumoConta(conta1);
Conta.MostrarResumoConta(conta2);
Conta.MostrarResumoConta(conta3);

conta1.Depositar(100);
Console.WriteLine($"\nSaldo {conta1.Titular.Nome} após depósito: R${conta1.Saldo:F2}");

conta1.Sacar(50);
Console.WriteLine($"Saldo {conta1.Titular.Nome} após saque: R${conta1.Saldo:F2}");

conta1.Transferir(30, conta2);
Console.WriteLine($"\nSaldo final {conta1.Titular.Nome}: R${conta1.Saldo:F2}");
Console.WriteLine($"Saldo final {conta2.Titular.Nome}: R${conta2.Saldo:F2}");

Console.WriteLine($"\nSaldo total geral: R${Conta.SaldoTotalGeral:F2}");
Console.WriteLine($"Conta com maior saldo: {Conta.ContaMaiorSaldo.Titular.Nome}");
