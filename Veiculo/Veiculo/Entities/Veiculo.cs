using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class Veiculo {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }
        public string Ano { get; private set; }
        public uint CapacidadeTanque { get; private set; }
        public string TipoCombustivel { get; private set; }
        public bool Flex { get; private set; }
        public double AutonomiaG { get; set; }
        public double AutonomiaA { get; set; }
        public double QtdCombustivel { get; set; }
        public double QtdGasolina { get; set; }
        public double QtdAlcool { get; set; }
        public string Pneu { get; set; }

        public void CadastrarVeiculo() {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------- Cadastro Veiculo -------------\n");
            Console.ResetColor();

            //Dar valor para a marca do veiculo e validar
            do {
                Console.Write("Digite a marca do veiculo: ");
                Marca = Console.ReadLine().Trim();
                if (Regex.IsMatch(Marca, "^[A-Z a-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ]{1,20}$") == false || Marca.Contains("  ")) { //validação da marca
                    Console.WriteLine("\nNome da marca invalido, Digite novamente\n");
                    Marca = null;
                }
            }
            while (Marca == null);

            //Dar valor para o modelo do veiculo e validar
            do {
                Console.Write("Digite o modelo do veiculo: ");
                Modelo = Console.ReadLine();
                if (Regex.IsMatch(Modelo, "^[A-Z a-z0-9áàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ]{1,20}$") == false || Modelo.Contains("  ")) { //validação do modelo
                    Console.WriteLine("\nNome do modelo invalido, Digite novamente\n");
                    Modelo = null;
                }
            }
            while (Modelo == null);

            //Dar valor para a placa do veiculo e validar
            do {
                Console.Write("Digite a placa do veiculo (Modelo: BRA-6679): ");
                Placa = Console.ReadLine();
                if (!Regex.IsMatch(Placa, "^[A-Z]{3}-[0-9]{4}$")) { //validação da placa
                    Console.WriteLine("\nPlaca invalida, digite novamente\n");
                    Placa = null;
                }
            }
            while (Placa == null);

            //Dar valor para o ano do veiculo e validar
            do {
                Console.Write("Digite o ano do veiculo (Entre 1900 até 2020): ");
                Ano = Console.ReadLine();
                if (Regex.IsMatch(Ano, "^[0-9]{4}$") == false || int.Parse(Ano) > 2020 || int.Parse(Ano) < 1900) { //validação do ano
                    Console.WriteLine("\nAno invalido, Digite novamente\n");
                    Ano = null;
                }
            }
            while (Ano == null);

            //Dar valor para a capacidade do tanque do veiculo e validar
            uint n;
            do {
                Console.Write("Digite a capacidade do tanque do veiculo: ");
                uint.TryParse(Console.ReadLine(), out n);
                if (n > 1000 || n < 5) { //validação da capacidade do tanque
                    Console.WriteLine("\nCapacidade do tanque invalido, digite novamente\n");
                    n = 0;
                }
            }
            while (n == 0);
            CapacidadeTanque = n;

            //Escolher o tipo de combustivel do veiculo
            do {
                Console.WriteLine("[1] Flex");
                Console.WriteLine("[2] Alcool");
                Console.WriteLine("[3] Gasolina");
                Console.Write("Digite qual o tipo de combustivel do veiculo: ");
                TipoCombustivel = Console.ReadLine();
            }
            while (!Regex.IsMatch(TipoCombustivel, "^[1-3]{1}$"));
            //Se o tipo for flex
            if (TipoCombustivel == "1") {
                Flex = true;
                uint result;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro de alcool: ");
                    uint.TryParse(Console.ReadLine(), out result);
                    if (result != 0)
                        AutonomiaA = result;
                    else if (result == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result == 0);

                uint result2;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro de gasolina: ");
                    uint.TryParse(Console.ReadLine(), out result2);
                    if (result2 != 0)
                        AutonomiaG = result2;
                    else if (result2 == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result2 == 0);
            }
            //Se o tipo for alcool
            else if (TipoCombustivel == "2") {
                TipoCombustivel = "Alcool";
                uint result;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro: ");
                    uint.TryParse(Console.ReadLine(), out result);
                    if (result != 0)
                        AutonomiaA = result;
                    else if (result == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result == 0);
            }
            //Se o tipo for gasolina
            else if (TipoCombustivel == "3") {
                TipoCombustivel = "Gasolina";
                uint result;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro: ");
                    uint.TryParse(Console.ReadLine(), out result);
                    if (result != 0)
                        AutonomiaG = result;
                    else if (result == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result == 0);
            }
            //Dar valor para o Pneu do veiculo, mudar a autonomia de acordo com ele e validar
            do {
                Console.WriteLine("Qual o nivel do pneu?");
                Pneu = Console.ReadLine();
                if (Pneu != "1" && Pneu != "2" && Pneu != "3")
                    Console.WriteLine("\nValor invalido, Digite um numero de 1 a 3\n");
            }
            while (!Regex.IsMatch(Pneu, "^[1-3]{1}$"));

            if (Pneu == "2") {
                AutonomiaA -= AutonomiaA * 0.0725;
                AutonomiaG -= AutonomiaG * 0.0725;
            }
            else if (Pneu == "1") {
                AutonomiaA -= AutonomiaA * 0.0915;
                AutonomiaG -= AutonomiaG * 0.0915;
            }

        }
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
                    if (QtdGasolina + abastecer <= CapacidadeTanque)
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
                    double QtdCombustivel = QtdAlcool + QtdGasolina;
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
            if(Flex == true) {
                string num;
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
            QtdCombustivel += CapacidadeTanque - QtdCombustivel;
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