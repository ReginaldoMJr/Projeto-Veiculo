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
                    Console.WriteLine("[4] Exibir informações do veiculo");
                    Console.WriteLine("[0] Sair do programa");
                    num = Console.ReadLine();
                    if(Regex.IsMatch(num, "^[0-4]{1}$") == false) {
                        Console.WriteLine("Valor invalido, digite novamente");
                        num = "5";
                    }
                }
                while (num == "5");
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
                            num = "5";
                        }
                        else {
                            double viagem;
                            Console.Write("Digite o tamanho da viagem: ");
                            double.TryParse(Console.ReadLine(), out viagem);

                            if (veiculo.TipoCombustivel == "Flex") {
                                do {
                                    if (veiculo.QtdAlcool * veiculo.AutonomiaA <= viagem) {
                                        viagem -= veiculo.QtdAlcool * veiculo.AutonomiaA;
                                        veiculo.QtdAlcool = 0;
                                    }
                                    if (veiculo.QtdAlcool * veiculo.AutonomiaA > viagem) {
                                        veiculo.QtdAlcool -= viagem / veiculo.AutonomiaA;
                                        viagem = 0;
                                    }
                                    if (veiculo.QtdAlcool == 0) {
                                        if (veiculo.QtdGasolina * veiculo.AutonomiaG <= viagem) {
                                            viagem -= veiculo.QtdGasolina * veiculo.AutonomiaG;
                                            veiculo.QtdGasolina = 0;
                                        }
                                        if (veiculo.QtdGasolina * veiculo.AutonomiaG > viagem) {
                                            veiculo.QtdGasolina -= viagem / veiculo.AutonomiaG;
                                            viagem = 0;
                                        }
                                        if (veiculo.QtdGasolina <= 0 && viagem != 0) {
                                            Console.WriteLine($"Faltam {viagem} KM");
                                            veiculo.Abastecer();
                                        }
                                    }
                                }
                                while (viagem > 0);
                                if (viagem <= 0) {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                }
                            }

                            if (veiculo.TipoCombustivel == "Alcool") {
                                do {
                                    if (veiculo.QtdAlcool * veiculo.Autonomia <= viagem) {
                                        viagem -= veiculo.QtdAlcool * veiculo.Autonomia;
                                        veiculo.QtdAlcool = 0;
                                    }
                                    if (veiculo.QtdAlcool * veiculo.Autonomia > viagem) {
                                        veiculo.QtdAlcool -= viagem / veiculo.Autonomia;
                                        viagem = 0;
                                    }
                                    if (veiculo.QtdAlcool <= 0 && viagem != 0) {
                                        Console.WriteLine($"Faltam {viagem} KM");
                                        veiculo.Abastecer();
                                    }
                                }
                                while (viagem > 0);
                                if (viagem <= 0) {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                                    Console.ResetColor();
                                }
                            }


                            if (veiculo.TipoCombustivel == "Gasolina") {
                                do {
                                    if (veiculo.QtdGasolina * veiculo.Autonomia <= viagem) {
                                        viagem -= veiculo.QtdGasolina * veiculo.Autonomia;
                                        veiculo.QtdGasolina = 0;
                                    }
                                    if (veiculo.QtdGasolina * veiculo.Autonomia > viagem) {
                                        veiculo.QtdGasolina -= viagem/veiculo.Autonomia;
                                        viagem = 0;
                                    }
                                    if (veiculo.QtdGasolina <= 0 && viagem != 0) {
                                        Console.WriteLine($"Faltam {viagem} KM");
                                        veiculo.Abastecer();
                                    }
                                }
                                while (viagem > 0);
                                if (viagem <= 0) {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                                    Console.ResetColor();
                                }
                            }
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
                        else
                            Console.WriteLine(veiculo);
                        break;
                    //Sair do programa
                    case "0":
                        Console.Write("Sair do programa selecionado, se tem certeza disso aperte enter, senão aperte esc para voltar ao menu");
                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                            num = "5";
                        break;
                }
            }
            while (num != "0");

        }
    }
}
