using System;
using System.Text;

namespace Veiculo {
    class Relatorio {
        public CarroPercurso CarroPercurso { get; set; }
        public double KmPercorrida { get; set; }
        public uint QtdAbastecimentos { get; set; }
        public uint QtdCalibragens { get; set; }
        public double LitrosConsumidos { get; set; }
        public StringBuilder DesgastePneu { get; set; } = new StringBuilder();
        public StringBuilder AlteracaoClimatica { get; set; } = new StringBuilder();

        public void ExibirRelatorio() {
            Console.Write("Carro -> ");
            CarroPercurso.Veiculo.MostrarVeiculo();
            Console.Write("Percurso -> ");
            CarroPercurso.Percurso.MostrarPercurso();
            Console.Write($"KM Percorridos: {KmPercorrida}\nQuantidade de abastecimentos: {QtdAbastecimentos}\nQuantidade de calibragens: {QtdCalibragens}\nLitros consumidos: {LitrosConsumidos}");
            Console.WriteLine($"\nDesgaste do Pneu:\n{DesgastePneu.ToString()}");
            Console.WriteLine($"Alteracao climatica:\n{AlteracaoClimatica.ToString()}");
        }
    }
}
