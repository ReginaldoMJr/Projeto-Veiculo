using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class CarroPercurso {
        public Veiculo Veiculo { get; set; }
        public Percurso Percurso { get; set; }
        public Relatorio Relatorio { get; set; }

        public void Dirigir() { 
            //Dirigir se for Flex
            if (Veiculo.Flex) {
                for (double km = 0; km <= Percurso.Trajeto; km = Math.Round((km + 0.1), 1)) {
                    if (Relatorio.KmPercorrida % 100 == 0) {
                        int cli = new Random().Next(1, 3);
                        if (cli.ToString() != Percurso.Clima) {
                            Percurso.Clima = cli.ToString();
                            CalculoClima(Veiculo, Percurso.Clima);
                        }
                    }
                    if (Veiculo.QtdGasolina == 0 && Veiculo.QtdAlcool == 0 && km != Percurso.Trajeto) {
                        Console.WriteLine($"Faltam {Percurso.Trajeto - km} KM");
                        Veiculo.EncherTanque();
                        Console.WriteLine("Deseja calibrar o pneu? Se sim, aperte enter, ou aperte esc para continuar a viagem");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            Veiculo.CalibrarPneu();
                        km = Math.Round((km - 0.1), 2);
                    }
                    else if (km == Percurso.Trajeto) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                    else {
                        if (Veiculo.QtdAlcool > 0) {
                            Veiculo.QtdAlcool = Math.Round((Veiculo.QtdAlcool - (0.1 / Veiculo.AutonomiaA)), 2);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                        }
                        else {
                            Veiculo.QtdGasolina = Math.Round((Veiculo.QtdGasolina - (0.1 / Veiculo.AutonomiaG)), 2);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                        }
                    }
                }

                //TODO: Usar o metodo de clima a cada 100 km
                /*int cli = new Random().Next(1, 3);
                if (cli.ToString() != Clima)
                    CalculoClima(veiculo,Clima);*/
            }
            //Dirigir se for Alcool ou Gasolina
            else {
                for (double km = 0; km <= Percurso.Trajeto; km = Math.Round((km + 0.1), 1)) {
                    if (Veiculo.QtdCombustivel <= 0 && km != Percurso.Trajeto) {
                        Console.WriteLine($"Faltam {Percurso.Trajeto - km} KM");
                        Veiculo.EncherTanque();
                        Console.WriteLine("Deseja calibrar o pneu? Se sim, aperte enter, ou aperte esc para continuar a viagem");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            Veiculo.CalibrarPneu();
                        km = Math.Round((km - 0.1), 2);
                    }
                    else if (Percurso.Trajeto == km) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                    else {
                        if (Veiculo.TipoCombustivel == "Alcool") {
                            Veiculo.QtdCombustivel = Math.Round((Veiculo.QtdCombustivel - (0.1 / Veiculo.AutonomiaA)), 2);
                        }
                        else {
                            Veiculo.QtdCombustivel = Math.Round((Veiculo.QtdCombustivel - (0.1 / Veiculo.AutonomiaG)), 2);
                        }
                    }
                }
            }
        }
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
            if (Clima == "3") {
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
