using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculo {
    class Relatorio {
        public uint KmPercorrida { get; set; }
        public uint QtdAbastecimentos { get; set; }
        public uint QtdCalibragens { get; set; }
        public double LitrosConsumidos { get; set; }
        public StringBuilder DesgastePneu { get; set; }
        public StringBuilder AlteracaoClimatica { get; set; }
    }
}
