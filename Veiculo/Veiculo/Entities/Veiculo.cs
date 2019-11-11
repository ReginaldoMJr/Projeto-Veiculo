using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class Veiculo {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
        public uint CapacidadeTanque { get; set; }
        public string TipoCombustivel { get; set; }
        public bool Flex { get; set; }
        public double AutonomiaOriginalG { get; set; }
        public double AutonomiaG { get; set; }
        public double AutonomiaOriginalA { get; set; }
        public double AutonomiaA { get; set; }
        public double QtdCombustivel { get; set; }
        public double QtdGasolina { get; set; }
        public double QtdAlcool { get; set; }
        public string Pneu { get; set; }

        
        //Abastecer se o tipo for flex
        public void AbastecerFlex() {
            uint abastecer;
            Console.WriteLine("[1] Gasolina");
            Console.WriteLine("[2] Alcool");
            int.TryParse(Console.ReadLine(), out int num);
            //Abastecer Gasolina em um carro flex
            if (num == 1) {
                do {
                    QtdCombustivel = QtdAlcool + QtdGasolina;
                    Console.WriteLine($"quantidade de combustivel: {QtdCombustivel}/{CapacidadeTanque}");
                    Console.WriteLine("Quantos litros deseja abastecer?");
                    uint.TryParse(Console.ReadLine(), out abastecer);
                    if (QtdGasolina + QtdAlcool + abastecer <= CapacidadeTanque)
                        QtdGasolina += abastecer;
                    else {
                        Console.WriteLine("Voce não pode abastecer mais que a quantidade do tanque");
                        abastecer = 100000;
                    }
                }
                while (abastecer == 100000);
            }
            //Abastecer Alcool no carro flex
            if (num == 2) {
                do {
                    QtdCombustivel = QtdAlcool + QtdGasolina;
                    Console.WriteLine($"quantidade de combustivel: {QtdCombustivel}/{CapacidadeTanque}");
                    Console.WriteLine("Quantos litros deseja abastecer?");
                    uint.TryParse(Console.ReadLine(), out abastecer);
                    if (QtdAlcool + QtdGasolina + abastecer <= CapacidadeTanque)
                        QtdAlcool += abastecer;
                    else {
                        Console.WriteLine("Voce não pode abastecer mais que a quantidade do tanque");
                        abastecer = 100000;
                    }
                }
                while (abastecer == 100000);
            }
        }
        //Abastecer os outros tipos
        public void Abastecer() {
            uint abastecer;
            //Abastecer se o tipo for Gasolina 
                do {
                    Console.WriteLine($"quantidade de combustivel: {QtdCombustivel}/{CapacidadeTanque}");
                    Console.WriteLine("Quantos litros deseja abastecer?");
                    uint.TryParse(Console.ReadLine(), out abastecer);
                    if (QtdCombustivel + abastecer <= CapacidadeTanque)
                        QtdCombustivel += abastecer;
                    else {
                        Console.WriteLine("Voce não pode abastecer mais que a quantidade do tanque");
                        abastecer = 3000;
                    }
                }
                while (abastecer == 3000);
        }
        //Metodo para calibrar pneu do veiculo
        public string CalibrarPneu() {
            //Mudar a autonomia de acordo com o pedido
            do {
                Console.WriteLine("[3] Autonomia original\n[2] Autonomia com decrescimo de 7,25%\n[1] Autonomia com decrescimo de 9,15%\nQual o nivel do pneu?");
                Pneu = Console.ReadLine();
                if (Pneu != "1" && Pneu != "2" && Pneu != "3")
                    Console.WriteLine("\nValor invalido, Digite um numero de 1 a 3\n");
            }
            while (!Regex.IsMatch(Pneu, "^[1-3]{1}$"));
            return Pneu;
        }
        //Metodo para encher o tanque com qualquer tipo de combustivel
        public void EncherTanque() {
            string num;
            if (Flex == true) {
                do {
                    Console.WriteLine("Deseja encher o tanque com qual combustivel?\n[1] Gasolina\n[2] Alcool\n[3] Não encher o tanque");
                    num = Console.ReadLine();
                }
                while (!Regex.IsMatch(num, "^[123]{1}$"));
                if (num == "1")
                    QtdGasolina += CapacidadeTanque - (QtdGasolina + QtdAlcool);
                else if (num == "2")
                    QtdAlcool += CapacidadeTanque - (QtdGasolina + QtdAlcool);
                else if (num == "3")
                    AbastecerFlex();
            }
            else {
                do {
                    Console.WriteLine("[1] Encher o tanque\n[2] Encher outra quantia");
                    num = Console.ReadLine();
                }
                while (!Regex.IsMatch(num, "^[12]{1}$"));
                if (num == "1")
                    QtdCombustivel += CapacidadeTanque - QtdCombustivel;
                else
                    Abastecer();
            }
        }
        //Mostrar os dados do veiculo
        public void MostrarVeiculo() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Marca: {Marca}\nModelo: {Modelo}\nAno: {Ano}\nPlaca: {Placa}\nCapacidade do tanque{CapacidadeTanque}\nPneu:{Pneu}");
            if (Flex)
                Console.WriteLine($"Tipo Combustivel: Alcool e Gasolina\nQuantidade de combustivel: {QtdAlcool + QtdGasolina}/{CapacidadeTanque}" +
                    $"\nKm por litro de Alcool: {AutonomiaOriginalA}\nKm por litro de Gasolina: {AutonomiaOriginalG}\n(Valores podem variar de acordo com o clima e estado do pneu)");
            else if (TipoCombustivel == "Alcool")
                Console.WriteLine($"Tipo de Combustivel: {TipoCombustivel}\nQuantidade de Combustivel: {QtdCombustivel}/{CapacidadeTanque}" +
                    $"\nKm por litro de combustivel: {AutonomiaOriginalA}\n(Valores podem variar de acordo com o clima e estado do pneu)");
            else
                Console.WriteLine($"Tipo de Combustivel: {TipoCombustivel}\nQuantidade de Combustivel: {QtdCombustivel}/{CapacidadeTanque}" +
                    $"\nKm por litro de combustivel: {AutonomiaOriginalG}\n(Valores podem variar de acordo com o clima e estado do pneu)");
            Console.ResetColor();
        }
    }
}