using System;
using System.Collections.Generic;

namespace Veiculo {
    class Menu {
        public void menu(Veiculo veiculo) {
            int num;
            do {
                Console.WriteLine("[1] Cadastrar carro");
                Console.WriteLine("[2] Dirigir");
                Console.WriteLine("[3] Abastecer");
                Console.WriteLine("[4] Exibir informações do veiculo");
                Console.WriteLine("[0] Sair do programa");
                num = int.Parse(Console.ReadLine());
                switch (num) {
                    case 1:
                        Console.Clear();
                        veiculo = new Veiculo();
                        veiculo.CadastrarVeiculo();
                        break;
                    case 2:
                        Console.Clear();
                        if (veiculo == null) {
                            Console.WriteLine("Nenhum veiculo cadastrado");
                            num = 5;
                        }
                        else {
                            uint viagem;
                            do {
                                Console.Write("Digite o tamanho da viagem: ");
                                uint.TryParse(Console.ReadLine(), out viagem);
                                for (int km = 0; km <= viagem; km++) {

                                    if (veiculo.TipoCombustivel == "Flex") {
                                        while (veiculo.QtdAlcool > 0) {
                                            if (km % veiculo.AutonomiaA == 0) {
                                                veiculo.QtdAlcool--;
                                            }
                                        }
                                        while (veiculo.QtdGasolina > 0) {
                                            if (km % veiculo.AutonomiaG == 0) {
                                                veiculo.QtdGasolina--;
                                            }
                                        }
                                    }
                                    else if (veiculo.TipoCombustivel == "Alcool") {
                                        if (km % veiculo.Autonomia == 0) {
                                            if (veiculo.QtdAlcool > 0)
                                                veiculo.QtdAlcool--;
                                        }
                                    }
                                    else if (veiculo.TipoCombustivel == "Gasolina") {
                                        if (km % veiculo.Autonomia == 0) {
                                            if (veiculo.QtdGasolina > 0)
                                                veiculo.QtdGasolina--;
                                        }
                                    }
                                }
                            }
                            while (viagem == 0);
                        }
                        break;
                    case 3:

                        break;
                    case 4:
                        Console.WriteLine(veiculo);
                        break;
                    case 0:
                        Console.Write("Sair do programa selecionado, se tem certeza disso aperte enter, senão aperte esc para voltar ao menu");
                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                            num = 5;
                        break;
                }
            }
            while (num != 0);

        }
    }
}
