using ControleContas;

Conta conta1 = new Conta("Laura", 2024101324, 200);
Conta conta2 = new Conta("Mateus", 2024101325, 50);

conta1.Depositar(100);
Console.WriteLine($"Saldo Laura após depósito: R${conta1.Saldo:F2}");

conta1.Sacar(50);
Console.WriteLine($"Saldo Laura após saque: R${conta1.Saldo:F2}");

conta1.Transferir(30, conta2);
Console.WriteLine($"Saldo final Laura: R${conta1.Saldo:F2}");
Console.WriteLine($"Saldo final Mateus: R${conta2.Saldo:F2}");


// crie um atributo saldo na classe conta cuja propriedade seja somente leitura 
// crie um projeto de teste para testar a classe Conta 
// ele deverá testar um metodo depositar
//o metodo depositar devera receber u valor decimal positivo
// e incrementar o saldo da conta 