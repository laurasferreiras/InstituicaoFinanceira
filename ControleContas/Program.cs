using ControleContas;

Conta conta1 = new Conta(123456789);
Conta conta2 = new Conta();
Console.WriteLine($"O número da conta é: {conta1.Numero}");
Console.WriteLine($"O número da conta é: {conta2.Numero}");

Console.WriteLine($"O saldo é de ");

// crie um atributo saldo na classe conta cuja propriedade seja somente leitura 