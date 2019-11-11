using System;

namespace Veiculo {
    class Percurso {
        public int Id { get; set; }
        public string Clima { get; set; }
        public double Trajeto { get; set; }

        public void MostrarPercurso() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Id: {Id}\nTrajeto: {Trajeto} KM\nClima: {Clima}");
            Console.ResetColor();
        }
    }
}
