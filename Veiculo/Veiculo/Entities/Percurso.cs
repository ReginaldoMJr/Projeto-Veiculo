using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class Percurso {
        public int Id { get; set; }
        public string Clima { get; set; }
        public double Trajeto { get; set; }

        public void CadastrarPercurso(AgenciaViagem agenciaViagem) {
            do Id = new Random().Next(1000, 9999);
            while (agenciaViagem.Percursos.Exists(x => x.Id == Id) || agenciaViagem.CarrosPercursos.Exists(x => x.Percurso.Id == Id));

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

            do {
                Console.Write("[1] Sol (autonomia padrao)\n[2] Chovendo(12% a menos de autonomia)\n[3] Nevando(19% a menos de autonomia)\nComo esta o clima?: ");
                Clima = Console.ReadLine().ToUpper();
            }
            while (!Regex.IsMatch(Clima, "^[123]{1}$"));
        }
    }
}
