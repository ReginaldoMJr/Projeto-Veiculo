using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculo.Util {
    class SubMenuExibicao {
        public static void Exibicao(AgenciaViagem agenciaViagem) {
            Console.WriteLine("[1] Exibir Carros\n\n[2] Exibir Percursos\n\n[3] Exibir Viagens Em espera");
            string num = Console.ReadLine();
            switch (num) {
                case "1":
                    agenciaViagem.ExibirVeiculos();
                    break;
                case "2":
                    agenciaViagem.ExibirPercursos();
                    break;
                case "3":
                    //TODO: Metodo para mostrar as viagens em espera
                    break;
            }
        }
    }
}
    



