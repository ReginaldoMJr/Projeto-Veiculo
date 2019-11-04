using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class Menu {
        public void menu(Veiculo veiculo) {
            string num;
            do {
                do {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("------------- Menu -------------");
                    Console.ResetColor();
                    Console.WriteLine("[1] Cadastrar carro");
                    Console.WriteLine("[2] Dirigir");
                    Console.WriteLine("[3] Abastecer");
                    Console.WriteLine("[4] Calibrar Pneu");
                    Console.WriteLine("[5] Exibir informações do veiculo");
                    Console.WriteLine("[0] Sair do programa");
                    num = Console.ReadLine();
                    if(Regex.IsMatch(num, "^[0-5]{1}$") == false) {
                        Console.WriteLine("Valor invalido, digite novamente");
                        num = "6";
                    }
                }
                while (num == "6");
                switch (num) {
                    //Faz o cadastro do veiculo
                    case "1":
                        Console.Clear();
                        veiculo = new Veiculo();
                        veiculo.CadastrarVeiculo();
                        break;
                    //Função dirigir para todos os tipos de combustivel
                    case "2":
                        Console.Clear();
                        if (veiculo == null) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else {
                            Viagem viagem = new Viagem();
                            viagem.Dirigir(veiculo);
                        }
                        break;
                    //Função para abastecer o veiculo
                    case "3":
                        if (veiculo == null) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else if (veiculo.Flex)
                            veiculo.AbastecerFlex();
                        else
                            veiculo.Abastecer();
                        break;
                    //Mostrar as informações do veiculo
                    case "4":
                        if (veiculo == null) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else {
                            Console.WriteLine(veiculo);
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        if (veiculo == null) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else 
                            veiculo.CalibrarPneu();
                        break;
                    //Sair do programa
                    case "0":
                        Console.Write("Sair do programa selecionado, se tem certeza disso aperte enter, senão aperte esc para voltar ao menu");
                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                            num = "6";
                        break;
                }
            }
            while (num != "0");
        }
    }
}