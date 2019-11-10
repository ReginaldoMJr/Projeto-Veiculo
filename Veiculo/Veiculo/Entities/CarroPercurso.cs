using System;

namespace Veiculo {
    class CarroPercurso {
        public Veiculo Veiculo { get; set; }
        public Percurso Percurso { get; set; }

        public void Dirigir(AgenciaViagem agenciaViagem) {
            Relatorio Relatorio = new Relatorio();
            Relatorio.CarroPercurso.Veiculo = Veiculo;
            Relatorio.CarroPercurso.Percurso = Percurso;
            agenciaViagem.Relatorios.Add(Relatorio);
            //Dirigir com todos os tipos de combustivel
            for (double km = 0; km <= Percurso.Trajeto; km = Math.Round((km + 0.1), 1)) {
                if (Relatorio.KmPercorrida == Percurso.Trajeto) {
                    agenciaViagem.CarroPercursos.Remove(Relatorio.CarroPercurso);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                else if (Relatorio.KmPercorrida % 100 == 0) {
                    int cli = new Random().Next(1, 3);
                    Relatorio.AlteracaoClimatica.AppendLine($"Alteracao Climatica: {Relatorio.KmPercorrida} KM -- Clima: {cli}");
                    if (cli.ToString() != Percurso.Clima) {
                        Percurso.Clima = cli.ToString();
                        CalculoClima(Veiculo, Percurso.Clima);
                    }
                }
                else if (Veiculo.QtdGasolina == 0 && Veiculo.QtdAlcool == 0 && Veiculo.QtdCombustivel == 0 && km != Percurso.Trajeto) {
                    Console.WriteLine($"Faltam {Percurso.Trajeto - km} KM");
                    Veiculo.EncherTanque();
                    Console.WriteLine("Deseja calibrar o pneu? Se sim, aperte enter, ou aperte esc para continuar a viagem");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        Veiculo.CalibrarPneu();
                    km = Math.Round((km - 0.1), 2);
                }
                else {
                    //Se for Flex
                    if (Veiculo.Flex) {
                        if (Veiculo.QtdAlcool > 0) {
                            Veiculo.QtdAlcool = Math.Round((Veiculo.QtdAlcool - (0.1 / Veiculo.AutonomiaA)), 2);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + 0.1), 1);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                        }
                        else {
                            Veiculo.QtdGasolina = Math.Round((Veiculo.QtdGasolina - (0.1 / Veiculo.AutonomiaG)), 2);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + 0.1), 1);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                        }
                    }
                    else {
                        //Se for Alcool
                        if (Veiculo.TipoCombustivel == "Alcool") {
                            Veiculo.QtdCombustivel = Math.Round((Veiculo.QtdCombustivel - (0.1 / Veiculo.AutonomiaA)), 2);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + 0.1), 1);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                        }
                        //Se for Gasolina
                        else {
                            Veiculo.QtdCombustivel = Math.Round((Veiculo.QtdCombustivel - (0.1 / Veiculo.AutonomiaG)), 2);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + 0.1), 1);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                        }
                    }
                }
            }
        }
        public void CalculoClima(Veiculo veiculo, string Clima) {

            if (Clima == "1") {
                veiculo.AutonomiaG = veiculo.AutonomiaOriginalG;
                veiculo.AutonomiaA = veiculo.AutonomiaOriginalA;
            }
            else if (Clima == "2") {
                if (veiculo.Flex) {
                    veiculo.AutonomiaG -= veiculo.AutonomiaOriginalG * 0.12;
                    veiculo.AutonomiaA -= veiculo.AutonomiaG * 0.30;
                }
                else if (veiculo.TipoCombustivel == "Gasolina")
                    veiculo.AutonomiaG -= veiculo.AutonomiaOriginalG * 0.12;
                else {
                    veiculo.AutonomiaA -= veiculo.AutonomiaOriginalA * 0.12;
                    veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.30;
                }
            }
            else if (Clima == "3") {
                if (veiculo.Flex) {
                    veiculo.AutonomiaG -= veiculo.AutonomiaOriginalG * 0.19;
                    veiculo.AutonomiaA -= veiculo.AutonomiaG * 0.30;
                }
                else if (veiculo.TipoCombustivel == "Gasolina")
                    veiculo.AutonomiaG -= veiculo.AutonomiaOriginalG * 0.19;
                else {
                    veiculo.AutonomiaA -= veiculo.AutonomiaOriginalA * 0.19;
                    veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.30;
                }
            }
        }
    }
}
