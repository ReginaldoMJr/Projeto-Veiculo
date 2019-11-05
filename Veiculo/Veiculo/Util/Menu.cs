using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class Menu {
        public static void menu(Veiculo veiculo, AgenciaViagem agenciaViagem) {
            
            string num;
            do {
                do {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("------------- Menu -------------");
                    Console.ResetColor();
                    Console.WriteLine("[1] Cadastrar carro");
                    Console.WriteLine("[2] Cadastrar viagem");
                    Console.WriteLine("[3] Dirigir");
                    Console.WriteLine("[4] Abastecer");
                    Console.WriteLine("[5] Calibrar Pneu");
                    Console.WriteLine("[6] Exibir informações do veiculo");
                    Console.WriteLine("[0] Sair do programa");
                    num = Console.ReadLine();
                    if(Regex.IsMatch(num, "^[0-5]{1}$") == false) {
                        Console.WriteLine("Valor invalido, digite novamente");
                        num = "6";
                    }
                }
                while (num == "6");
                switch (num) {
                    case "1": //Faz o cadastro do veiculo
                        Console.Clear();
                        veiculo = new Veiculo();
                        veiculo.CadastrarVeiculo();
                        agenciaViagem.Veiculos.Add(veiculo);
                        break;
                    case "2": //Função para cadastrar um percurso
                        Console.Clear();
                        Percurso percurso = new Percurso();
                        agenciaViagem.Percursos.Add(percurso);
                        break;
                    case "3":
                        Console.Clear();
                        break;
                    //Função para abastecer o veiculo
                    case "4":
                        if (veiculo == null) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        //Abastece o carro flex
                        else if (veiculo.Flex)
                            veiculo.AbastecerFlex();
                        //Abastece os outros tipos
                        else
                            veiculo.Abastecer();
                        break;
                    //Função para calibrar o pneu do veiculo 
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
                    //Função para mostrar todas as informações do veiculo
                    case "6":
                        if (veiculo == null) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else {
                            veiculo.MostrarVeiculo();
                            Console.ReadLine();
                        }
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