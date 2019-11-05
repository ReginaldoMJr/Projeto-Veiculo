using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class Percurso {
        public string Clima { get; set; }
        public double Trajeto { get; set; }

        //Metodo para dirigir um veiculo
        public void Dirigir(Veiculo veiculo) {
            //Dar valor para o Trajeto da viagem e validar
            double viagem;
            do {
                Console.Write("Digite o tamanho da viagem: ");
                double.TryParse(Console.ReadLine(), out viagem);
                if (viagem < 1 || viagem > 10000) {
                    Console.WriteLine("Valor de viagem invalido, Digite novamente");
                    Trajeto = 0;
                }
                else
                    Trajeto = viagem;
            }
            while (Trajeto == 0);
            
            //Dar valor para o clima da viagem e validar
            do {
                Console.Write("[1] Sol (autonomia padrao)\n[2] Chovendo(12% a menos de autonomia)\n[3] Nevando(19% a menos de autonomia)\nComo esta o clima?: ");
                Clima = Console.ReadLine().ToUpper();
            }
            while (!Regex.IsMatch(Clima, "^[123]{1}$"));
            if (Clima == "2" || Clima == "3")
                CalculoClima(veiculo, Clima);
            //Dirigir se for Flex
            if (veiculo.Flex) {
                for(double km = 0; km <= Trajeto; km = Math.Round((km + 0.1), 1)) {
                    if (veiculo.QtdGasolina == 0 && veiculo.QtdAlcool == 0 && viagem != 0) {
                        km = Math.Round((km - 0.1), 2);
                        Console.WriteLine($"Faltam {viagem} KM");
                        veiculo.AbastecerFlex();
                        Console.WriteLine("Deseja calibrar o pneu? Se sim, aperte enter, ou aperte esc para continuar a viagem");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            veiculo.CalibrarPneu();
                    }
                    else if (viagem == 0) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                    else {
                        if(veiculo.QtdAlcool > 0) {
                            veiculo.QtdAlcool = Math.Round((veiculo.QtdAlcool - (0.1 / veiculo.AutonomiaA)), 2);
                            viagem = Math.Round((viagem - 0.1), 1);
                        }
                        else {
                            veiculo.QtdGasolina = Math.Round((veiculo.QtdGasolina - (0.1 / veiculo.AutonomiaG)), 2);
                            viagem = Math.Round((viagem - 0.1), 1);
                        }
                    }
                }
                
                            //TODO: Usar o metodo de clima a cada 100 km
                            /*int cli = new Random().Next(1, 3);
                            if (cli.ToString() != Clima)
                                CalculoClima(veiculo,Clima);*/
                        }
            
            //Dirigir se for Alcool
            else if (veiculo.TipoCombustivel == "Alcool") {
                for (double km = 0; km <= Trajeto; km = Math.Round((km + 0.1), 1)) {
                    if (veiculo.QtdCombustivel <= 0 && viagem != 0) {
                        km = Math.Round((km - 0.1), 2);
                        Console.WriteLine($"Faltam {viagem} KM");
                        veiculo.Abastecer();
                        Console.WriteLine("Deseja calibrar o pneu? Se sim, aperte enter, ou aperte esc para continuar a viagem");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            veiculo.CalibrarPneu();
                    }
                    else if (viagem == 0) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                    else {
                        veiculo.QtdCombustivel = Math.Round((veiculo.QtdCombustivel - (0.1 / veiculo.AutonomiaA)), 2);
                        viagem = Math.Round((viagem - 0.1), 1);
                    }
                }
            }
            //Dirigir se for Gasolina
            else if (veiculo.TipoCombustivel == "Gasolina") {
                for (double km = 0; km <= Trajeto; km = Math.Round((km + 0.1),1)) {
                    if (veiculo.QtdCombustivel <= 0 && viagem != 0) {
                        km = Math.Round((km - 0.1),2);
                        Console.WriteLine($"Faltam {viagem} KM");
                        veiculo.Abastecer();
                        Console.WriteLine("Deseja calibrar o pneu? Se sim, aperte enter, ou aperte esc para continuar a viagem");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            veiculo.CalibrarPneu();
                    }
                    else if (viagem == 0) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                    else {
                        veiculo.QtdCombustivel = Math.Round((veiculo.QtdCombustivel - (0.1 / veiculo.AutonomiaG)),2);
                        viagem = Math.Round((viagem - 0.1),1);
                    }

                }
            }
        }
        //Fazer o calculo de clima
        public void CalculoClima(Veiculo veiculo, string Clima) {
            if (Clima == "2") {
                if (veiculo.Flex) {
                    veiculo.AutonomiaG -= veiculo.AutonomiaG * 0.12;
                    veiculo.AutonomiaA -= veiculo.AutonomiaG * 0.30;
                }
                else if (veiculo.TipoCombustivel == "Gasolina")
                    veiculo.AutonomiaG -= veiculo.AutonomiaG * 0.12;
                else {
                    veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.12;
                    veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.30;
                }
            }
            if(Clima == "3") {
                if (veiculo.Flex) {
                    veiculo.AutonomiaG -= veiculo.AutonomiaG * 0.19;
                    veiculo.AutonomiaA -= veiculo.AutonomiaG * 0.30;
                }
                else if (veiculo.TipoCombustivel == "Gasolina")
                    veiculo.AutonomiaG -= veiculo.AutonomiaG * 0.19;
                else {
                    veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.19;
                    veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.30;
                }
            }
        }
    }
}
