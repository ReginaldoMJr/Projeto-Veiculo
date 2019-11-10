using System;
using System.Text.RegularExpressions;
using Veiculo.Util;

namespace Veiculo {
    class Menu {
        public static void menu(AgenciaViagem agenciaViagem) {
            string num;
            do {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("------------- Menu -------------");
                Console.ResetColor();
                Console.WriteLine("[1] Cadastros");
                Console.WriteLine("[2] Exibir");
                Console.WriteLine("[3] Atribuir um carro a uma viagem");
                Console.WriteLine("[4] Dirigir");
                Console.WriteLine("[5] Abastecer");
                Console.WriteLine("[6] Calibrar Pneu");
                Console.WriteLine("[7] Exibir informações do veiculo");
                Console.WriteLine("[0] Sair do programa");
                num = Console.ReadLine();

                switch (num) {
                    case "1": //Faz o cadastro do veiculo
                        Console.Clear();
                        SubMenuCadastro.Cadastro(agenciaViagem);
                        break;
                    case "2": //Função para cadastrar um percurso
                        Console.Clear();
                        SubMenuExibicao.Exibicao(agenciaViagem);
                        break;
                    case "3":
                        Console.Clear();
                        agenciaViagem.CadastrarCarroPercurso();
                        break;
                    //Função para abastecer o veiculo
                    case "4":
                        if (agenciaViagem.CarroPercursos.Count == 0) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else {
                            string placa = Console.ReadLine();
                            CarroPercurso carroPercurso = agenciaViagem.CarroPercursos.Find(x => x.Veiculo.Placa == placa);
                            carroPercurso.Dirigir(agenciaViagem);
                        }
                        break;
                    //Função para calibrar o pneu do veiculo 
                    case "5":
                        if (agenciaViagem.Veiculos.Count == 0) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else {
                            /*Console.WriteLine("Digite o id do carro:");
                            teste = Console.ReadLine();
                            veiculo = agenciaViagem.Veiculos.Find(x => x.Placa == teste);
                            veiculo.CalibrarPneu();*/
                        }
                        break;
                    //Função para mostrar todas as informações do veiculo
                    case "6":
                        if (agenciaViagem.Veiculos.Count == 0) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else {
                            /*Console.WriteLine("Digite o id do carro:");
                            teste = Console.ReadLine();
                            veiculo = agenciaViagem.Veiculos.Find(x => x.Placa == teste);
                            veiculo.MostrarVeiculo();
                            Console.ReadLine();*/
                        }
                        break;
                    //Sair do programa
                    case "0":
                        Console.Write("Sair do programa selecionado, se tem certeza disso aperte enter, senão aperte esc para voltar ao menu");
                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                            num = "6";
                        break;
                    default:
                        Console.WriteLine("Opcao invalida, aperte enter para tentar novamente");
                        Console.ReadLine();
                        menu(agenciaViagem);
                        break;
                }
            }
            while (num != "0");
        }
    }
}