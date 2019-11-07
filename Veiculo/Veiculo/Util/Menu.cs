using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class Menu {
        public static void menu(AgenciaViagem agenciaViagem) {
            string num;
            do {
                do {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("------------- Menu -------------");
                    Console.ResetColor();
                    Console.WriteLine("[1] Cadastrar carro");
                    Console.WriteLine("[2] Cadastrar viagem");
                    Console.WriteLine("[3] Atribuir um carro a uma viagem");
                    Console.WriteLine("[4] Dirigir");
                    Console.WriteLine("[5] Abastecer");
                    Console.WriteLine("[6] Calibrar Pneu");
                    Console.WriteLine("[7] Exibir informações do veiculo");
                    Console.WriteLine("[0] Sair do programa");
                    num = Console.ReadLine();
                    if(!Regex.IsMatch(num, "^[0-7]{1}$")) {
                        Console.WriteLine("Valor invalido, digite novamente");
                        num = "8";
                    }
                }
                while (num == "8");

                switch (num) {
                    case "1": //Faz o cadastro do veiculo
                        Console.Clear();
                        Veiculo veiculo = new Veiculo();
                        veiculo.CadastrarVeiculo();
                        agenciaViagem.Veiculos.Add(veiculo);
                        break;
                    case "2": //Função para cadastrar um percurso
                        Console.Clear();
                        Percurso percurso = new Percurso();
                        percurso.CadastrarPercurso(agenciaViagem);
                        agenciaViagem.Percursos.Add(percurso);
                        break;
                    case "3":
                        Console.WriteLine("Digite a placa do carro:");
                        string teste = Console.ReadLine();
                        CarroPercurso carroPercurso = null;
                        carroPercurso.Veiculo = agenciaViagem.Veiculos.Find(x => x.Placa == teste);
                        Console.WriteLine("Digite o id da viagem");
                        teste = Console.ReadLine();
                        carroPercurso.Percurso = agenciaViagem.Percursos.Find(x => x.Id.ToString() == teste);
                        agenciaViagem.CarroPercursos.Add(carroPercurso);
                        Console.Clear();
                        break;
                    //Função para abastecer o veiculo
                    case "4":
                        if (agenciaViagem.Veiculos.Count == 0) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else {
                            Console.WriteLine("Digite o id do carro:");
                            teste = Console.ReadLine();
                            veiculo = agenciaViagem.Veiculos.Find(x => x.Placa == teste);
                            //Abastece o carro flex
                            if (veiculo.Flex)
                                veiculo.AbastecerFlex();
                            //Abastece os outros tipos
                            else
                                veiculo.Abastecer();
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
                            Console.WriteLine("Digite o id do carro:");
                            teste = Console.ReadLine();
                            veiculo = agenciaViagem.Veiculos.Find(x => x.Placa == teste);
                            veiculo.CalibrarPneu();
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
                            Console.WriteLine("Digite o id do carro:");
                            teste = Console.ReadLine();
                            veiculo = agenciaViagem.Veiculos.Find(x => x.Placa == teste);
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