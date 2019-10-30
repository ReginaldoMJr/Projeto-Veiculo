using System;

namespace Veiculo {
    class Veiculo {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public uint Ano { get; set; }
        public uint VelocidadeMax { get; set; }
        public uint CapacidadeTanque { get; set; }
        public string TipoCombustivel { get; set; }
        public uint AutonomiaG { get; set; }
        public uint AutonomiaA { get; set; }
        public uint Autonomia { get; set; }
        public uint QtdGasolina { get; set; }
        public uint QtdAlcool { get; set; }

        public void CadastrarVeiculo() {
            Console.Write("Digite a marca do veiculo: ");
            Marca = Console.ReadLine();

            Console.Write("Digite a modelo do veiculo: ");
            Modelo = Console.ReadLine();

            Console.Write("Digite a placa do veiculo: ");
            Placa = Console.ReadLine();

            Console.Write("Digite o ano do veiculo: ");
            Ano = uint.Parse(Console.ReadLine());

            Console.Write("Digite a velocidade maxima do veiculo: ");
            VelocidadeMax = uint.Parse(Console.ReadLine());

            Console.Write("Digite a capacidade do tanque do veiculo: ");
            CapacidadeTanque = uint.Parse(Console.ReadLine());

            Console.WriteLine("[1] Flex");
            Console.WriteLine("[2] Alcool");
            Console.WriteLine("[3] Gasolina");
            Console.Write("Digite qual o tipo de combustivel do veiculo: ");
            string verifica = Console.ReadLine();
            if (verifica == "1") {
                TipoCombustivel = "Flex";
                Console.Write("Digite quantos km o veiculo faz por litro de alcool: ");
                AutonomiaA = uint.Parse(Console.ReadLine());
                Console.Write("Digite quantos km o veiculo faz por litro de gasolina: ");
                AutonomiaG = uint.Parse(Console.ReadLine());
            }
            if (verifica == "2") {
                TipoCombustivel = "Alcool";
                Console.Write("Digite quantos km o veiculo faz por litro: ");
                Autonomia = uint.Parse(Console.ReadLine());
            }
            if (verifica == "3") {
                TipoCombustivel = "Gasolina";
                Console.Write("Digite quantos km o veiculo faz por litro: ");
                Autonomia = uint.Parse(Console.ReadLine());
            }
        }
        public void Abastecer() {
            uint abastecer;
            if (TipoCombustivel == "Flex") {
                int num;
                Console.WriteLine("[1] Gasolina");
                Console.WriteLine("[2] Alcool");
                int.TryParse(Console.ReadLine(), out num);
                if (num == 1) {
                    do {
                        Console.WriteLine("Quantos litros deseja abastecer?");
                        uint.TryParse(Console.ReadLine(), out abastecer);
                        if (QtdGasolina + abastecer <= CapacidadeTanque)
                            QtdGasolina += abastecer;
                        else {
                            Console.WriteLine("Voce não pode abastecer mais que a quantidade do tanque");
                            abastecer = 3000;
                        }
                    }
                    while (abastecer == 3000);
                }
                if (num == 2) {
                    do {
                        Console.WriteLine("Quantos litros deseja abastecer?");
                        uint.TryParse(Console.ReadLine(), out abastecer);
                        if (QtdAlcool + abastecer <= CapacidadeTanque)
                            QtdAlcool += abastecer;
                        else {
                            Console.WriteLine("Voce não pode abastecer mais que a quantidade do tanque");
                            abastecer = 3000;
                        }
                    }
                    while (abastecer == 3000);
                }
            }

            if (TipoCombustivel == "Gasolina") {
                do {
                    Console.WriteLine("Quantos litros deseja abastecer?");
                    uint.TryParse(Console.ReadLine(), out abastecer);
                    if (QtdGasolina + abastecer <= CapacidadeTanque)
                        QtdGasolina += abastecer;
                    else {
                        Console.WriteLine("Voce não pode abastecer mais que a quantidade do tanque");
                        abastecer = 3000;
                    }
                }
                while (abastecer == 3000);
            }
            if (TipoCombustivel == "Alcool") {
                do {
                    Console.WriteLine("Quantos litros deseja abastecer?");
                    uint.TryParse(Console.ReadLine(), out abastecer);
                    if (QtdAlcool + abastecer <= CapacidadeTanque)
                        QtdAlcool += abastecer;
                    else {
                        Console.WriteLine("Voce não pode abastecer mais que a quantidade do tanque");
                        abastecer = 3000;
                    }
                }
                while (abastecer == 3000);
            }
        }
        public override string ToString() {
            return $"Marca: {Marca} -- Modelo: {Modelo} -- Placa: {Placa} -- Ano: {Ano} -- Velocidade Maxima: {VelocidadeMax}"
                + $"\nCapacidade do tanque: {CapacidadeTanque} -- Tipo de Combustivel: {TipoCombustivel} -- Autonomia: {Autonomia}";
        }
    }
}
