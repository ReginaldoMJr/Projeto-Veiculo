using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class Viagem {
        public bool Clima { get; set; }
        public double Trajeto { get; set; }

        //Metodo para dirigir um veiculo
        public void Dirigir(Veiculo veiculo) {
            //Dar valor para o Trajeto da viagem e validar
            do {
                Console.Write("Digite o tamanho da viagem: ");
                double.TryParse(Console.ReadLine(), out double viagem);
                if (viagem < 1 || viagem > 10000) {
                    Console.WriteLine("Valor de viagem invalido, Digite novamente");
                    Trajeto = 0;
                }
                else
                    Trajeto = viagem;
            }
            while (Trajeto == 0);
            
            //Dar valor para o clima da viagem e validar
            string Cli;
            do {
                Console.Write("O clima esta ruim? (S / N): ");
                Cli = Console.ReadLine().ToUpper();
            }
            while (!Regex.IsMatch(Cli, "^[SN]{1}$"));
            if (Cli == "S")
                Clima = true;
            //Se o clima estiver ruim, retirar uma porcentagem de autonomia dependendo do combustivel
            if (Clima == true) {
                CalculoClima(veiculo);
            }
            //Dirigir se for Flex
            if (veiculo.Flex) {
                do {
                    if (veiculo.QtdAlcool * veiculo.AutonomiaA <= Trajeto) {
                        Trajeto -= veiculo.QtdAlcool * veiculo.AutonomiaA;
                        veiculo.QtdAlcool = 0;
                    }
                    else if (veiculo.QtdAlcool * veiculo.AutonomiaA > Trajeto) {
                        veiculo.QtdAlcool -= Trajeto / veiculo.AutonomiaA;
                        Trajeto = 0;
                    }
                    if (veiculo.QtdAlcool == 0) {
                        if (veiculo.QtdGasolina * veiculo.AutonomiaG <= Trajeto) {
                            Trajeto -= veiculo.QtdGasolina * veiculo.AutonomiaG;
                            veiculo.QtdGasolina = 0;
                        }
                        else if (veiculo.QtdGasolina * veiculo.AutonomiaG > Trajeto) {
                            veiculo.QtdGasolina -= Trajeto / veiculo.AutonomiaG;
                            Trajeto = 0;
                        }
                        if (veiculo.QtdGasolina <= 0 && Trajeto != 0) {
                            Console.WriteLine($"Faltam {Trajeto} KM");
                            veiculo.AbastecerFlex();
                            Console.WriteLine("Deseja calibrar o pneu? Se sim, aperte enter, ou aperte esc para continuar a viagem");
                            if (Console.ReadKey().Key == ConsoleKey.Enter)
                                veiculo.CalibrarPneu();
                            if (Clima)
                                CalculoClima(veiculo);
                        }
                    }
                }
                while (Trajeto > 0);
                if (Trajeto == 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            //Dirigir se for Alcool
            else if (veiculo.TipoCombustivel == "Alcool") {
                do {
                    if (veiculo.QtdCombustivel * veiculo.AutonomiaA <= Trajeto) {
                        Trajeto -= veiculo.QtdCombustivel * veiculo.AutonomiaA;
                        veiculo.QtdCombustivel = 0;
                    }
                    else if (veiculo.QtdCombustivel * veiculo.AutonomiaA > Trajeto) {
                        veiculo.QtdCombustivel -= Trajeto / veiculo.AutonomiaA;
                        Trajeto = 0;
                    }
                    if (veiculo.QtdCombustivel <= 0 && Trajeto > 0) {
                        Console.WriteLine($"Faltam {Trajeto} KM");
                        veiculo.Abastecer();
                        Console.WriteLine("Deseja calibrar o pneu? Se sim, aperte enter, ou aperte esc para continuar a viagem");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            veiculo.CalibrarPneu();
                        if (Clima)
                            CalculoClima(veiculo);
                    }
                }
                while (Trajeto > 0);
                if (Trajeto == 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            //Dirigir se for Gasolina
            else if (veiculo.TipoCombustivel == "Gasolina") {
                do {
                    if (veiculo.QtdCombustivel * veiculo.AutonomiaG <= Trajeto) {
                        Trajeto -= veiculo.QtdCombustivel * veiculo.AutonomiaG;
                        veiculo.QtdCombustivel = 0;
                    }
                    if (veiculo.QtdCombustivel * veiculo.AutonomiaG > Trajeto) {
                        veiculo.QtdCombustivel -= Trajeto / veiculo.AutonomiaG;
                        Trajeto = 0;
                    }
                    if (veiculo.QtdCombustivel <= 0 && Trajeto != 0) {
                        Console.WriteLine($"Faltam {Trajeto} KM");
                        veiculo.Abastecer();
                        Console.WriteLine("Deseja calibrar o pneu? Se sim, aperte enter, ou aperte esc para continuar a viagem");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            veiculo.CalibrarPneu();
                        if (Clima)
                            CalculoClima(veiculo);
                    }
                }
                while (Trajeto > 0);
                if (Trajeto == 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }
        //Fazer o calculo de clima
        public void CalculoClima(Veiculo veiculo) {
            veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.135;
            veiculo.AutonomiaG -= veiculo.AutonomiaG * 0.12;
        }
    }
}
