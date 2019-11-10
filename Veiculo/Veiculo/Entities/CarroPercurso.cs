using System;

namespace Veiculo {
    class CarroPercurso {
        public Veiculo Veiculo { get; set; }
        public Percurso Percurso { get; set; }

        public void Dirigir(AgenciaViagem agenciaViagem, CarroPercurso carroPercurso) {
            Relatorio Relatorio = agenciaViagem.Relatorios.Find(x => x.CarroPercurso.Percurso.Id == Percurso.Id);
            if (Relatorio == null) {
                Relatorio = new Relatorio { CarroPercurso = carroPercurso };
                agenciaViagem.Relatorios.Add(Relatorio);
            }
            double MenuDirigir() {
                string num;
                double viagem2;
                Console.WriteLine("[1] Dirigir até acabar o combustivel\n\n[2] Dirigir uma distancia especifica");
                num = Console.ReadLine();
                switch (num) {
                    case "1":
                        viagem2 = Percurso.Trajeto;
                        return viagem2;
                    case "2":
                        Console.Write("Digite o valor que quer viajar: ");
                        double.TryParse(Console.ReadLine(), out viagem2);
                        if(viagem2 == 0 || viagem2 > Percurso.Trajeto) {
                            Console.WriteLine("Valor invalido, tente novamente");
                            return MenuDirigir();
                        }
                        return viagem2;
                    default:
                        Console.WriteLine("Opcao invalida, tente novamente");
                        return MenuDirigir();
                } }
            double viagem = MenuDirigir();
            //Dirigir com todos os tipos de combustivel
            for (double km = 0; km <= Percurso.Trajeto; km = Math.Round((km + 0.1), 1)) {
                if (Relatorio.KmPercorrida == Percurso.Trajeto) {
                    agenciaViagem.CarroPercursos.Remove(Relatorio.CarroPercurso);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                else if(viagem == 0) {
                    double MenuViagem() {
                        Console.WriteLine("[1] Abastecer\n\n[2] Calibrar Pneu\n\n[3] Continuar viagem");
                        string num = Console.ReadLine();
                        switch (num) {
                            case "1":
                                if (Veiculo.Flex)
                                    Veiculo.AbastecerFlex();
                                else
                                    Veiculo.Abastecer();
                                return MenuViagem();
                            case "2":
                                Veiculo.CalibrarPneu();
                                return MenuViagem();
                            case "3":
                                return MenuDirigir();
                            default:
                                Console.WriteLine("Opcao invalida, aperte enter para tentar novamente");
                                Console.ReadLine();
                                return MenuViagem();
                        }
                    }
                }
                else if (Relatorio.KmPercorrida % 100 == 0 && Relatorio.KmPercorrida > 0) {
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
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + (0.1 / Veiculo.AutonomiaA)), 1);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                            viagem = Math.Round((viagem - 0.1), 1);
                        }
                        else {
                            Veiculo.QtdGasolina = Math.Round((Veiculo.QtdGasolina - (0.1 / Veiculo.AutonomiaG)), 2);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + (0.1 / Veiculo.AutonomiaG)), 1);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                            viagem = Math.Round((viagem - 0.1), 1);
                        }
                    }
                    else {
                        //Se for Alcool
                        if (Veiculo.TipoCombustivel == "Alcool") {
                            Veiculo.QtdCombustivel = Math.Round((Veiculo.QtdCombustivel - (0.1 / Veiculo.AutonomiaA)), 2);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + (0.1 / Veiculo.AutonomiaA)), 1);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                            viagem = Math.Round((viagem - 0.1), 1);
                        }
                        //Se for Gasolina
                        else {
                            Veiculo.QtdCombustivel = Math.Round((Veiculo.QtdCombustivel - (0.1 / Veiculo.AutonomiaG)), 2);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + (0.1 / Veiculo.AutonomiaG)), 1);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                            viagem = Math.Round((viagem - 0.1), 1);
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
