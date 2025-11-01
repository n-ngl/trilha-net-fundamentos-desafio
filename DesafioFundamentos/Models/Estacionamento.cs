using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa;
            do
            {
                Console.WriteLine("\nDigite a placa do veículo para estacionar:");
                placa = Console.ReadLine();
                placa = placa.ToUpper();
            } while (string.IsNullOrWhiteSpace(placa));

            while (veiculos.Contains(placa))
            {
                Console.WriteLine($"O veículo de placa '{placa}' já está estacionado.");
                Console.WriteLine("\nDigite a placa do veículo para estacionar:");
                placa = Console.ReadLine();
                placa = placa.ToUpper();
            }
            veiculos.Add(placa);
            Console.WriteLine($"Veículo de placa '{placa}' adicionado com sucesso");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("\nDigite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            placa = placa.ToUpper();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("\nDigite a quantidade de horas que o veículo permaneceu estacionado:");
                string entrada = Console.ReadLine();
                int horas;
                bool valido = int.TryParse(entrada, out horas);
                while (horas < 0)
                {
                    Console.WriteLine("## Digite um número não negativo ##");
                    entrada = Console.ReadLine();
                    valido = int.TryParse(entrada, out horas);
                }
                while (!valido)
                {
                    Console.WriteLine("## Entrada inválida ##\nDigite um número inteiro");
                    entrada = Console.ReadLine();
                    valido = int.TryParse(entrada, out horas);
                    Console.WriteLine("\nDigite a quantidade de horas que o veículo permaneceu estacionado:");
                }

                decimal valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.Remove(placa);
                Console.WriteLine($"\nO veículo {placa} foi removido com sucesso\nValor total do Estacionamento: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("\nDesculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("\nExistem " + veiculos.Count + " veículos estacionados." + "\nAs placas dos veículos estacionados são:");
                int contador = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(contador + ". " + veiculo);
                    contador++;
                }
            }
            else
            {
                Console.WriteLine("\nNão há veículos estacionados.");
            }
        }
    }
}