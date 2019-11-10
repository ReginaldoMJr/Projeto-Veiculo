using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculo.Util {
    class SubMenuExibicao {
        public static void Exibicao(AgenciaViagem agenciaViagem) {
            Console.WriteLine("[1] Exibir Carros\n\n[2] Exibir Percursos\n\n[3] Exibir Viagens Em espera\n\n[4] Exibir Relatorios");
            string num = Console.ReadLine();
            switch (num) {
                case "1":
                    agenciaViagem.ExibirVeiculos();
                    Console.ReadLine();
                    break;
                case "2":
                    agenciaViagem.ExibirPercursos();
                    Console.ReadLine();
                    break;
                case "3":
                    agenciaViagem.ExibirCarrosPercursos();
                    Console.ReadLine();
                    break;
                case "4":
                    agenciaViagem.ExibirRelatorios();
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opcao invalida, tente novamente");
                    Exibicao(agenciaViagem);
                    break;
            }
        }
    }
}
    



