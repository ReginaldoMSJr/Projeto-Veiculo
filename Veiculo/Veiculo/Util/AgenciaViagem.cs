﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Veiculo {
    class AgenciaViagem {
        public List<Veiculo> Veiculos = new List<Veiculo>();
        public List<Percurso> Percursos = new List<Percurso>();
        public List<CarroPercurso> CarroPercursos = new List<CarroPercurso>();
        public List<Relatorio> Relatorios = new List<Relatorio>();

        public void CadastrarVeiculo() {
            Veiculo veiculo = new Veiculo();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------- Cadastro Veiculo -------------\n");
            Console.ResetColor();

            //Dar valor para a marca do veiculo e validar
            do {
                Console.Write("Digite a marca do veiculo: ");
                veiculo.Marca = Console.ReadLine().Trim();
                if (Regex.IsMatch(veiculo.Marca, "^[A-Z a-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ]{1,20}$") == false || veiculo.Marca.Contains("  ")) { //validação da marca
                    Console.WriteLine("\nNome da marca invalido, Digite novamente\n");
                    veiculo.Marca = null;
                }
            }
            while (veiculo.Marca == null);

            //Dar valor para o modelo do veiculo e validar
            do {
                Console.Write("Digite o modelo do veiculo: ");
                veiculo.Modelo = Console.ReadLine();
                if (Regex.IsMatch(veiculo.Modelo, "^[A-Z a-z0-9áàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ]{1,20}$") == false || veiculo.Modelo.Contains("  ")) { //validação do modelo
                    Console.WriteLine("\nNome do modelo invalido, Digite novamente\n");
                    veiculo.Modelo = null;
                }
            }
            while (veiculo.Modelo == null);

            //Dar valor para a placa do veiculo e validar
            do {
                Console.Write("Digite a placa do veiculo (Modelo: BRA-6679): ");
                veiculo.Placa = Console.ReadLine();
                if (!Regex.IsMatch(veiculo.Placa, "^[A-Z]{3}-[0-9]{4}$")) { //validação da placa
                    Console.WriteLine("\nPlaca invalida, digite novamente\n");
                    veiculo.Placa = null;
                }
            }
            while (veiculo.Placa == null);

            //Dar valor para o ano do veiculo e validar
            do {
                Console.Write("Digite o ano do veiculo (Entre 1900 até 2020): ");
                veiculo.Ano = Console.ReadLine();
                if (Regex.IsMatch(veiculo.Ano, "^[0-9]{4}$") == false || int.Parse(veiculo.Ano) > 2020 || int.Parse(veiculo.Ano) < 1900) { //validação do ano
                    Console.WriteLine("\nAno invalido, Digite novamente\n");
                    veiculo.Ano = null;
                }
            }
            while (veiculo.Ano == null);

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
            veiculo.CapacidadeTanque = n;

            //Escolher o tipo de combustivel do veiculo
            do {
                Console.WriteLine("[1] Flex");
                Console.WriteLine("[2] Alcool");
                Console.WriteLine("[3] Gasolina");
                Console.Write("Digite qual o tipo de combustivel do veiculo: ");
                veiculo.TipoCombustivel = Console.ReadLine();
            }
            while (!Regex.IsMatch(veiculo.TipoCombustivel, "^[1-3]{1}$"));
            //Se o tipo for flex
            if (veiculo.TipoCombustivel == "1") {
                veiculo.Flex = true;
                uint result;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro de alcool: ");
                    uint.TryParse(Console.ReadLine(), out result);
                    if (result != 0)
                        veiculo.AutonomiaA = result;
                    else if (result == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result == 0);

                uint result2;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro de gasolina: ");
                    uint.TryParse(Console.ReadLine(), out result2);
                    if (result2 != 0)
                        veiculo.AutonomiaG = result2;
                    else if (result2 == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result2 == 0);
            }
            //Se o tipo for alcool
            else if (veiculo.TipoCombustivel == "2") {
                veiculo.TipoCombustivel = "Alcool";
                uint result;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro: ");
                    uint.TryParse(Console.ReadLine(), out result);
                    if (result != 0)
                        veiculo.AutonomiaA = result;
                    else if (result == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result == 0);
            }
            //Se o tipo for gasolina
            else if (veiculo.TipoCombustivel == "3") {
                veiculo.TipoCombustivel = "Gasolina";
                uint result;
                do {
                    Console.Write("Digite quantos km o veiculo faz por litro: ");
                    uint.TryParse(Console.ReadLine(), out result);
                    if (result != 0)
                        veiculo.AutonomiaG = result;
                    else if (result == 0)
                        Console.WriteLine("Autonomia invalida, digite novamente");
                }
                while (result == 0);
            }
            //Dar valor para o Pneu do veiculo, mudar a autonomia de acordo com ele e validar
            do {
                Console.WriteLine("Qual o nivel do pneu?");
                veiculo.Pneu = Console.ReadLine();
                if (veiculo.Pneu != "1" && veiculo.Pneu != "2" && veiculo.Pneu != "3")
                    Console.WriteLine("\nValor invalido, Digite um numero de 1 a 3\n");
            }
            while (!Regex.IsMatch(veiculo.Pneu, "^[1-3]{1}$"));

            if (veiculo.Pneu == "2") {
                veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.0725;
                veiculo.AutonomiaG -= veiculo.AutonomiaG * 0.0725;
            }
            else if (veiculo.Pneu == "1") {
                veiculo.AutonomiaA -= veiculo.AutonomiaA * 0.0915;
                veiculo.AutonomiaG -= veiculo.AutonomiaG * 0.0915;
            }
            Veiculos.Add(veiculo);
        }
        public void CadastrarPercurso() {
            Percurso percurso = new Percurso();

            do percurso.Id = new Random().Next(1000, 9999);
            while (Percursos.Exists(x => x.Id == percurso.Id) || CarroPercursos.Exists(x => x.Percurso.Id == percurso.Id));

            do {
                Console.Write("Digite o tamanho da viagem: ");
                double.TryParse(Console.ReadLine(), out double viagem);
                if (viagem < 1 || viagem > 10000) {
                    Console.WriteLine("Valor de viagem invalido, Digite novamente");
                    percurso.Trajeto = 0;
                }
                else
                    percurso.Trajeto = viagem;
            }
            while (percurso.Trajeto == 0);

            do {
                Console.Write("[1] Sol (autonomia padrao)\n[2] Chovendo(12% a menos de autonomia)\n[3] Nevando(19% a menos de autonomia)\nComo esta o clima?: ");
                percurso.Clima = Console.ReadLine().ToUpper();
            }
            while (!Regex.IsMatch(percurso.Clima, "^[123]{1}$"));

            Percursos.Add(percurso);
        }
        public void CadastrarCarroPercurso() {
            CarroPercurso carroPercurso = new CarroPercurso();
            string verifica = Console.ReadLine();
            Veiculo veiculo = Veiculos.Find(x => x.Placa == verifica);
            verifica = Console.ReadLine();
            Percurso percurso = Percursos.Find(x => x.Id.ToString() == verifica);
            carroPercurso.Veiculo = veiculo;
            carroPercurso.Percurso = percurso;
            CarroPercursos.Add(carroPercurso);
        }
    }
}
