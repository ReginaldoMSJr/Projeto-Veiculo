﻿using System;
using System.Text.RegularExpressions;

namespace Veiculo {
    class Veiculo {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
        public uint CapacidadeTanque { get; set; }
        public string TipoCombustivel { get; set; }
        public uint AutonomiaG { get; set; }
        public uint AutonomiaA { get; set; }
        public uint Autonomia { get; set; }
        public double QtdGasolina { get; set; }
        public double QtdAlcool { get; set; }

        public void CadastrarVeiculo() {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------- Cadastro Veiculo -------------\n");
            Console.ResetColor();

            do {
                Console.Write("Digite a marca do veiculo: ");
                Marca = Console.ReadLine().Trim();
                if (Regex.IsMatch(Marca, "^[A-Z a-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ]{1,20}$") == false || Marca.Contains("  ")) { //validação da marca
                    Console.WriteLine("\nNome da marca invalido, Digite novamente\n");
                    Marca = null;
                }
            }
            while (Marca == null);
            
            do {
                Console.Write("Digite a modelo do veiculo: ");
                Modelo = Console.ReadLine();
                if (Regex.IsMatch(Modelo, "^[A-Z a-z0-9áàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ]{1,20}$") == false || Modelo.Contains("  ")) { //validação do modelo
                    Console.WriteLine("\nNome do modelo invalido, Digite novamente\n");
                    Modelo = null;
                }
            }
            while (Modelo == null);

            do {
                Console.Write("Digite a placa do veiculo: ");
                Placa = Console.ReadLine();
                if(Regex.IsMatch(Placa, "^[A-Z0-9-]$")) { //validação da placa
                    Console.WriteLine("\nPlaca invalida, digite novamente\n");
                    Placa = null;
                }
            }
            while (Placa == null);

            do {
                Console.Write("Digite o ano do veiculo: ");
                Ano = Console.ReadLine();
                if (Regex.IsMatch(Ano, "^[0-9]{4}$") == false || int.Parse(Ano) > 2020) { //validação do ano
                    Console.WriteLine("\nAno invalido, Digite novamente\n");
                    Ano = null;
                }
            }
            while (Ano == null);

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
            Console.WriteLine("[1] Flex");
            Console.WriteLine("[2] Alcool");
            Console.WriteLine("[3] Gasolina");
            Console.Write("Digite qual o tipo de combustivel do veiculo: ");
            string verifica = Console.ReadLine();
            //Se o tipo for flex
            if (verifica == "1") {
                TipoCombustivel = "Flex";
                uint result;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro de alcool: ");
                    uint.TryParse(Console.ReadLine(), out result);
                    if (result != 0)
                        AutonomiaA = result;
                    if(result == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result == 0);
                
                uint result2;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro de gasolina: ");
                    uint.TryParse(Console.ReadLine(), out result2);
                    if (result2 != 0)
                        AutonomiaG = result;
                    if (result2 == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result2 == 0);
            }
            //Se o tipo for alcool
            else if (verifica == "2") {
                TipoCombustivel = "Alcool";
                uint result;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro: ");
                    uint.TryParse(Console.ReadLine(), out result);
                    if (result != 0)
                        Autonomia = result;
                    if (result == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result == 0);
            }
            //Se o tipo for gasolina
            else if (verifica == "3") {
                TipoCombustivel = "Gasolina";
                uint result;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro: ");
                    uint.TryParse(Console.ReadLine(), out result);
                    if (result != 0)
                        Autonomia = result;
                    if (result == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result == 0);
            }

        }
        //Metodo para abastecer o veiculo
        public void Abastecer() {
            uint abastecer;
            //Abastecer se o tipo for flex
            if (TipoCombustivel == "Flex") {
                int num;
                Console.WriteLine("[1] Gasolina");
                Console.WriteLine("[2] Alcool");
                int.TryParse(Console.ReadLine(), out num);
                //Abastecer Gasolina em um carro flex
                if (num == 1) {
                    do {
                        double QtdCombustivel = QtdAlcool + QtdGasolina;
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

            //Abastecer se o tipo for Gasolina
            if (TipoCombustivel == "Gasolina") {
                do {
                    Console.WriteLine($"quantidade de combustivel: {QtdGasolina}/{CapacidadeTanque}");
                    Console.WriteLine("Quantos litros deseja abastecer?");
                    uint.TryParse(Console.ReadLine(), out abastecer);
                    if (QtdGasolina + QtdAlcool + abastecer <= CapacidadeTanque)
                        QtdGasolina += abastecer;
                    else {
                        Console.WriteLine("Voce não pode abastecer mais que a quantidade do tanque");
                        abastecer = 3000;
                    }
                }
                while (abastecer == 3000);
            }
            //Abastecer se o tipo for Alcool
            if (TipoCombustivel == "Alcool") {
                do {
                    Console.WriteLine($"quantidade de combustivel: {QtdAlcool}/{CapacidadeTanque}");
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
            return $"Marca: {Marca} -- Modelo: {Modelo} -- Placa: {Placa} -- Ano: {Ano}"
                + $"\nCapacidade do tanque: {CapacidadeTanque} Litros -- Tipo de Combustivel: {TipoCombustivel} -- Autonomia: {Autonomia}/L";
        }
    }
}
