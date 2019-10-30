using System;

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
                            double viagem;
                            Console.Write("Digite o tamanho da viagem: ");
                            double.TryParse(Console.ReadLine(), out viagem);

                            if (veiculo.TipoCombustivel == "Flex") {

                            }
                            if (veiculo.TipoCombustivel == "Alcool") {
                                double QtdLitrosV = viagem / veiculo.Autonomia;
                                do {
                                    if (veiculo.QtdAlcool < QtdLitrosV) {
                                        QtdLitrosV -= veiculo.QtdAlcool;
                                        veiculo.QtdAlcool = 0;
                                    }
                                    if (veiculo.QtdAlcool >= QtdLitrosV) {
                                        veiculo.QtdAlcool -= QtdLitrosV;
                                        QtdLitrosV -= veiculo.QtdAlcool;
                                    }
                                    if (veiculo.QtdAlcool == 0) veiculo.Abastecer();
                                }
                                while (QtdLitrosV > 0);
                            }
                            if (veiculo.TipoCombustivel == "Gasolina") {
                                double QtdLitrosV = viagem / veiculo.Autonomia;
                                do {
                                    if (veiculo.QtdGasolina < QtdLitrosV) {
                                        QtdLitrosV -= veiculo.QtdGasolina;
                                        veiculo.QtdGasolina = 0;
                                    }
                                    if (veiculo.QtdGasolina >= QtdLitrosV) {
                                        veiculo.QtdGasolina -= QtdLitrosV;
                                        QtdLitrosV -= veiculo.QtdGasolina;
                                    }
                                    if (veiculo.QtdGasolina == 0) veiculo.Abastecer();
                                }
                                while (QtdLitrosV > 0);
                                if (QtdLitrosV == 0) {
                                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                                    Console.ReadLine();
                                }
                            }
                        }
                        break;
                    case 3:
                        veiculo.Abastecer();
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
