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
                        if (viagem2 == 0 || viagem2 > Percurso.Trajeto) {
                            Console.WriteLine("Valor invalido, tente novamente");
                            return MenuDirigir();
                        }
                        return viagem2;
                    default:
                        Console.WriteLine("Opcao invalida, tente novamente");
                        return MenuDirigir();
                }
            }
            double viagem = MenuDirigir();
            CalculoClima(Veiculo, Percurso.Clima);
            //Dirigir com todos os tipos de combustivel
            for (double km = 0; km <= Percurso.Trajeto; km = Math.Round((km + 0.1), 1)) {
                if (Relatorio.KmPercorrida == Percurso.Trajeto) {
                    agenciaViagem.CarroPercursos.Remove(agenciaViagem.CarroPercursos.Find(x => x.Percurso.Id == Percurso.Id));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Viagem finalizada, aperte enter para voltar ao menu");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                else if (viagem == 0) {
                    MenuViagem();
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
                                viagem = MenuDirigir();
                                return viagem;
                            default:
                                Console.WriteLine("Opcao invalida, aperte enter para tentar novamente");
                                Console.ReadLine();
                                return MenuViagem();
                        }
                    }
                }
                else if (Veiculo.QtdGasolina <= 0 && Veiculo.QtdAlcool <= 0 && Veiculo.QtdCombustivel <= 0 && km != Percurso.Trajeto) {
                    Veiculo.QtdGasolina = 0;
                    Veiculo.QtdAlcool = 0;
                    Veiculo.QtdCombustivel = 0;
                    Console.WriteLine($"Faltam {Percurso.Trajeto - Relatorio.KmPercorrida} KM");
                    Veiculo.EncherTanque();
                    Relatorio.QtdAbastecimentos++;
                    Console.WriteLine("Deseja calibrar o pneu? Se sim, aperte enter, ou aperte esc para continuar a viagem");
                    if (Console.ReadKey().Key == ConsoleKey.Enter) {
                        Veiculo.CalibrarPneu();
                        CalculoClima(Veiculo, Percurso.Clima);
                        Relatorio.QtdCalibragens++;
                    }
                    km = Math.Round((km - 0.1), 2);
                }
                else {
                    //Se for Flex
                    if (Veiculo.Flex) {
                        if (Veiculo.QtdAlcool > 0) {
                            Veiculo.QtdAlcool = Math.Round((Veiculo.QtdAlcool - (0.1 / Veiculo.AutonomiaA)), 3);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + (0.1 / Veiculo.AutonomiaA)), 2);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                            viagem = Math.Round((viagem - 0.1), 1);
                        }
                        else {
                            Veiculo.QtdGasolina = Math.Round((Veiculo.QtdGasolina - (0.1 / Veiculo.AutonomiaG)), 3);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + (0.1 / Veiculo.AutonomiaG)), 2);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                            viagem = Math.Round((viagem - 0.1), 1);
                        }
                    }
                    else {
                        //Se for Alcool
                        if (Veiculo.TipoCombustivel == "Alcool") {
                            Veiculo.QtdCombustivel = Math.Round((Veiculo.QtdCombustivel - (0.1 / Veiculo.AutonomiaA)), 3);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + (0.1 / Veiculo.AutonomiaA)), 2);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                            viagem = Math.Round((viagem - 0.1), 1);
                        }
                        //Se for Gasolina
                        else {
                            Veiculo.QtdCombustivel = Math.Round((Veiculo.QtdCombustivel - (0.1 / Veiculo.AutonomiaG)), 3);
                            Relatorio.LitrosConsumidos = Math.Round((Relatorio.LitrosConsumidos + (0.1 / Veiculo.AutonomiaG)), 2);
                            Relatorio.KmPercorrida = Math.Round((Relatorio.KmPercorrida + 0.1), 1);
                            viagem = Math.Round((viagem - 0.1), 1);
                        }
                    }
                }
                if (km % 100 == 0 && km > 0) {
                    int cli = new Random().Next(1, 4);
                    Relatorio.AlteracaoClimatica.AppendLine($"Alteracao Climatica: {km} KM -- Clima: {cli}");
                    Percurso.Clima = cli.ToString();
                    int pneu = new Random().Next(0, 2);
                    Veiculo.Pneu = (int.Parse(Veiculo.Pneu) - pneu).ToString();
                    if (Veiculo.Pneu == "0") {
                        Console.WriteLine("Pneu Furou, calibrar");
                        Relatorio.DesgastePneu.AppendLine($"Desgaste de Pneu: {km} KM -- Pneu: {Veiculo.Pneu}");
                        Veiculo.Pneu = Veiculo.CalibrarPneu();
                        Relatorio.QtdCalibragens++;
                    }
                    Relatorio.DesgastePneu.AppendLine($"Desgaste de Pneu: {km} KM -- Pneu: {Veiculo.Pneu}");
                    CalculoClima(Veiculo, Percurso.Clima);
                }
            }
        }
        public void CalculoClima(Veiculo veiculo, string Clima) {
            //Clima Sol e Pneu Novo
            if (Clima == "1" && veiculo.Pneu == "3") {
                veiculo.AutonomiaG = veiculo.AutonomiaOriginalG;
                veiculo.AutonomiaA = veiculo.AutonomiaOriginalA;
            }
            //Clima Sol e Pneu Seminovo
            else if (Clima == "1" && veiculo.Pneu == "2") {
                veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - (veiculo.AutonomiaOriginalG * 0.0725)), 2);
                veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaOriginalA - (veiculo.AutonomiaOriginalA * 0.0725)), 2);
            }
            //Clima Sol e Pneu Velho
            else if (Clima == "1" && veiculo.Pneu == "1") {
                veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - (veiculo.AutonomiaOriginalG * 0.0915)), 2);
                veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaOriginalA - (veiculo.AutonomiaOriginalA * 0.0915)), 2);
            }
            //Clima Chuva e Pneu Novo
            else if (Clima == "2" && veiculo.Pneu == "3") {
                if (veiculo.Flex) {
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - (veiculo.AutonomiaOriginalG * 0.12)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaG - (veiculo.AutonomiaG * 0.30)),2);
                }
                else if (veiculo.TipoCombustivel == "Gasolina")
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - (veiculo.AutonomiaOriginalG * 0.12)), 2);
                else {
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaOriginalA - (veiculo.AutonomiaOriginalA * 0.12)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaA - (veiculo.AutonomiaA * 0.30)), 2);
                }
            }
            //Clima Chuva e Pneu Seminovo
            else if (Clima == "2" && veiculo.Pneu == "2") {
                if (veiculo.Flex) {
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - veiculo.AutonomiaOriginalG * (0.12 + 0.0725)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaG - veiculo.AutonomiaG * (0.30 + 0.0725)), 2);
                }
                else if (veiculo.TipoCombustivel == "Gasolina")
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - veiculo.AutonomiaOriginalG * (0.12 + 0.0725)), 2);
                else {
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaOriginalA - veiculo.AutonomiaOriginalA * (0.12 + 0.0725)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaA - (veiculo.AutonomiaA * (0.30 + 0.0725))), 2);
                }
            }
            //Clima Chuva e Pneu Velho
            else if (Clima == "2" && veiculo.Pneu == "1") {
                if (veiculo.Flex) {
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - veiculo.AutonomiaOriginalG * (0.12 + 0.0915)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaG - veiculo.AutonomiaG * (0.30 + 0.0915)), 2);
                }
                else if (veiculo.TipoCombustivel == "Gasolina")
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - veiculo.AutonomiaOriginalG * (0.12 + 0.0915)), 2);
                else {
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaOriginalA - veiculo.AutonomiaOriginalA * (0.12 + 0.0915)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaA - (veiculo.AutonomiaA * (0.30 + 0.0915))), 2);
                }
            }
            //Clima Neve e Pneu novo
            else if (Clima == "3" && veiculo.Pneu == "3") {
                if (veiculo.Flex) {
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - (veiculo.AutonomiaOriginalG * 0.19)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaG - (veiculo.AutonomiaG * 0.30)), 2);
                }
                else if (veiculo.TipoCombustivel == "Gasolina")
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - (veiculo.AutonomiaOriginalG * 0.19)), 2);
                else {
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaOriginalA - (veiculo.AutonomiaOriginalA * 0.19)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaA - (veiculo.AutonomiaA * 0.30)), 2);
                }
            }
            //Clima Neve e Pneu Seminovo
            else if (Clima == "3" && veiculo.Pneu == "2") {
                if (veiculo.Flex) {
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - veiculo.AutonomiaOriginalG * (0.19 + 0.0725)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaG - veiculo.AutonomiaG * (0.30 + 0.0725)), 2);
                }
                else if (veiculo.TipoCombustivel == "Gasolina")
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - veiculo.AutonomiaOriginalG * (0.19 + 0.0725)), 2);
                else {
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaOriginalA - veiculo.AutonomiaOriginalA * (0.19 + 0.0725)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaA - (veiculo.AutonomiaA * (0.30 + 0.0725))), 2);
                }
            }
            //Clima Neve e Pneu Velho
            else if (Clima == "3" && veiculo.Pneu == "1") {
                if (veiculo.Flex) {
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - veiculo.AutonomiaOriginalG * (0.19 + 0.0915)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaG - veiculo.AutonomiaG * (0.30 + 0.0725)), 2);
                }
                else if (veiculo.TipoCombustivel == "Gasolina")
                    veiculo.AutonomiaG = Math.Round((veiculo.AutonomiaOriginalG - veiculo.AutonomiaOriginalG * (0.19 + 0.0915)), 2);
                else {
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaOriginalA - veiculo.AutonomiaOriginalA * (0.19 + 0.0915)), 2);
                    veiculo.AutonomiaA = Math.Round((veiculo.AutonomiaA - (veiculo.AutonomiaA * (0.30 + 0.0915))), 2);
                }
            }

        }
    }
}
