using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculo.Util {
    class SubMenuCadastro {
        public static void Cadastro(AgenciaViagem agenciaViagem) {
            Console.WriteLine("[1] Cadastrar Carro\n\n[2] Cadastrar Percurso");
            string num = Console.ReadLine();
            switch (num) {
                case "1":
                    agenciaViagem.CadastrarVeiculo();
                    break;
                case "2":
                    agenciaViagem.CadastrarPercurso();
                    break;
                default:
                    Console.WriteLine("Opcao Invalida, tente novamente");
                    Cadastro(agenciaViagem);
                    break;
            }
        }
    }
}
