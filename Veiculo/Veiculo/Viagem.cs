using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class Viagem {
        public bool Clima { get; set; }
        public double Trajeto { get; set; }

        public void Dirigir(Veiculo veiculo) {
            Console.Write("Digite o tamanho da viagem: ");
            double.TryParse(Console.ReadLine(), out double viagem);
            string Cli;
            do {
                Console.Write("O clima esta ruim? (S / N): ");
                Cli = Console.ReadLine().ToUpper();
            }
            while (!Regex.IsMatch(Cli, "^[SN]{1}$"));
            if (Cli == "S")
                Clima = true;
            if (Clima == true) {
                veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.135;
                veiculo.AutonomiaG -= veiculo.AutonomiaG * 0.12;
            }
            if (veiculo.Flex) {
                do {
                    if (veiculo.QtdAlcool * veiculo.AutonomiaA <= viagem) {
                        viagem -= veiculo.QtdAlcool * veiculo.AutonomiaA;
                        veiculo.QtdAlcool = 0;
                    }
                    else if (veiculo.QtdAlcool * veiculo.AutonomiaA > viagem) {
                        veiculo.QtdAlcool -= viagem / veiculo.AutonomiaA;
                        viagem = 0;
                    }
                    if (veiculo.QtdAlcool == 0) {
                        if (veiculo.QtdGasolina * veiculo.AutonomiaG <= viagem) {
                            viagem -= veiculo.QtdGasolina * veiculo.AutonomiaG;
                            veiculo.QtdGasolina = 0;
                        }
                        else if (veiculo.QtdGasolina * veiculo.AutonomiaG > viagem) {
                            veiculo.QtdGasolina -= viagem / veiculo.AutonomiaG;
                            viagem = 0;
                        }
                        if (veiculo.QtdGasolina <= 0 && viagem != 0) {
                            Console.WriteLine($"Faltam {viagem} KM");
                            veiculo.AbastecerFlex();
                            veiculo.CalibrarPneu();
                            CalculoClima(veiculo);
                        }
                    }
                }
                while (viagem > 0);
                if (viagem == 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            else if (veiculo.TipoCombustivel == "Alcool") {
                do {
                    if (veiculo.QtdCombustivel * veiculo.AutonomiaA <= viagem) {
                        viagem -= veiculo.QtdCombustivel * veiculo.AutonomiaA;
                        veiculo.QtdCombustivel = 0;
                    }
                    else if (veiculo.QtdCombustivel * veiculo.AutonomiaA > viagem) {
                        veiculo.QtdCombustivel -= viagem / veiculo.AutonomiaA;
                        viagem = 0;
                    }
                    if (veiculo.QtdCombustivel <= 0 && viagem > 0) {
                        Console.WriteLine($"Faltam {viagem} KM");
                        veiculo.Abastecer();
                        veiculo.CalibrarPneu();
                        CalculoClima(veiculo);
                    }
                }
                while (viagem > 0);
                if (viagem == 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            else if (veiculo.TipoCombustivel == "Gasolina") {
                do {
                    if (veiculo.QtdCombustivel * veiculo.AutonomiaG <= viagem) {
                        viagem -= veiculo.QtdCombustivel * veiculo.AutonomiaG;
                        veiculo.QtdCombustivel = 0;
                    }
                    if (veiculo.QtdCombustivel * veiculo.AutonomiaG > viagem) {
                        veiculo.QtdCombustivel -= viagem / veiculo.AutonomiaG;
                        viagem = 0;
                    }
                    if (veiculo.QtdCombustivel <= 0 && viagem != 0) {
                        Console.WriteLine($"Faltam {viagem} KM");
                        veiculo.Abastecer();
                        veiculo.CalibrarPneu();
                        if (Clima)
                            CalculoClima(veiculo);
                    }
                }
                while (viagem > 0);
                if (viagem == 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }
        public void CalculoClima(Veiculo veiculo) {
            veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.135;
            veiculo.AutonomiaG -= veiculo.AutonomiaG * 0.12;
        }
    }
}
