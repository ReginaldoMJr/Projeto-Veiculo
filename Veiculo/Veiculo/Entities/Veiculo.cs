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
        public void CalibrarPneu() {
            //Voltar para os valores originais
            if(Pneu == "2") {
                AutonomiaA /= 0.9275;
                AutonomiaG /= 0.9275;
            }
            else if(Pneu == "1") {
                AutonomiaA /= 0.9085;
                AutonomiaG /= 0.9085;
            }
            
            //Mudar a autonomia de acordo com o pedido
            do {
                Console.WriteLine("[3] Autonomia original\n[2] Autonomia com decrescimo de 7,25%\n[1] Autonomia com decrescimo de 9,15%\nQual o nivel do pneu?");
                Pneu = Console.ReadLine();
                if (Pneu != "1" && Pneu != "2" && Pneu != "3")
                    Console.WriteLine("\nValor invalido, Digite um numero de 1 a 3\n");
            }
            while (!Regex.IsMatch(Pneu, "^[1-3]{1}$"));

            if (Pneu == "2") {
                AutonomiaA -= AutonomiaA * 0.0725;
                AutonomiaG -= AutonomiaG * 0.0725;
            }
            if (Pneu == "1") {
                AutonomiaA -= AutonomiaA * 0.0915;
                AutonomiaG -= AutonomiaG * 0.0915;
            }
        }
        public void DesgastePneu() {

        }
        //Metodo para encher o tanque com qualquer tipo de combustivel
        public void EncherTanque() {
            string num;
            if (Flex == true) {
                do {
                    Console.WriteLine("Deseja encher o tanque com qual combustivel?\n[1] Gasolina\n[2] Alcool\n[3] Não encher o tanque");
                    num = Console.ReadLine();
                }
                while (Regex.IsMatch(num, "^[123]{1}$"));
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
            Console.WriteLine($"Marca: {Marca}\nModelo: {Modelo}\nPlaca: {Placa}\nAno: {Ano}"
                + $"\nCapacidade do tanque: {CapacidadeTanque} Litros");
            if(Flex == true) 
                Console.WriteLine($"Tipo de combustivel: Alcool e Gasolina\nAutonomia Gasolina: {AutonomiaG}\nAutonomia Alcool {AutonomiaA}\nQuantidade de Gasolina: {QtdGasolina}\nQuantidade de Alcool: {QtdAlcool}");
            else if(TipoCombustivel == "Gasolina")
                Console.WriteLine($"Tipo de combustivel: {TipoCombustivel}\nAutonomia: {AutonomiaG}\nQuantidade de Combustivel: {QtdCombustivel}");
            else
                Console.WriteLine($"Tipo de combustivel: {TipoCombustivel}\nAutonomia: {AutonomiaA}\nQuantidade de Combustivel: {QtdCombustivel}");

        }
    }
}