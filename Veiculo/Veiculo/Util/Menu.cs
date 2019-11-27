using System;
using Veiculo.Util;
using Veiculo.Banco;

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
                Console.WriteLine("[5] Abastecer um carro");
                Console.WriteLine("[0] Sair do programa");
                num = Console.ReadLine();

                switch (num) {
                    case "1": //Faz o cadastro do veiculo ou de um Percurso
                        Console.Clear();
                        SubMenuCadastro.Cadastro(agenciaViagem);
                        break;
                    case "2": //Função para Exibir Veiculos, Percursos e viagens em espera
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
                            agenciaViagem.ExibirCarrosPercursos();
                            Console.WriteLine("Digite a placa do veiculo");
                            string placa = Console.ReadLine();
                            CarroPercurso carroPercurso = agenciaViagem.CarroPercursos.Find(x => x.Veiculo.Placa == placa);
                            carroPercurso.Dirigir(agenciaViagem, carroPercurso);
                        }
                        break;
                    case "5":
                        if (agenciaViagem.CarroPercursos.Count == 0 && agenciaViagem.Veiculos.Count == 0) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Não tem nenhum carro, aperte enter para voltar ao menu");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        else {
                            Console.WriteLine("========== Carros atribuidos ===========\n");
                            agenciaViagem.CarroPercursos.ForEach(x => x.Veiculo.MostrarVeiculo());
                            Console.WriteLine("\n======== carros não atribuidos =========");
                            agenciaViagem.ExibirVeiculos();
                            Veiculo veiculo;
                            do {
                                Console.WriteLine("Digite a Placa do veiculo que deseja abastecer");
                                string placa = Console.ReadLine();
                                veiculo = agenciaViagem.Veiculos.Find(x => x.Placa == placa);
                                if(veiculo == null) {
                                    veiculo = agenciaViagem.CarroPercursos.Find(x => x.Veiculo.Placa == placa).Veiculo;
                                }
                                if(veiculo == null) {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Veiculo não encontrado, aperte enter para tentar novamente");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                }
                            }
                            while (veiculo == null);
                            veiculo.EncherTanque();
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