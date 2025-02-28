using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsumidorDeBolinhas
{
    internal class BolinhaMVC
    {
        [JsonProperty("id")]
        public Guid IdBolinha { get; set; }
        [JsonProperty("nome")]
        public string NomeBolinha { get; set; }
    }

    internal class Executor
    {
        private const string URL = "https://localhost:44364/";

        private const string URI_LISTAR = "api/v1/bolinhas";
        private const string URI_ADICIONAR = "api/v1/bolinha";
        private const string URI_REMOVER = "api/v1/bolinhas/{0}";

        public static void Executar()
        {
            Menu();

            var entrada = Console.ReadLine();
            switch (entrada)
            {
                case "1":
                    Listar();
                    break;
                case "2":
                    Adicionar();
                    break;
                case "3":
                    Remover();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Thread.Sleep(500);
                    break;
            }

            Executar();
        }

        private static void Menu()
        {
            Console.WriteLine($"       SUPER MENU      ");
            Console.WriteLine(string.Empty);
            Console.WriteLine($"1. Listar bolinhas");
            Console.WriteLine($"2. Adicionar bolinha");
            Console.WriteLine($"3. Remover bolinha");
        }

        private static void Listar()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44364/api/v1/bolinhas");


            var responseTsk = client.SendAsync(request);
            responseTsk.Wait();

            var response = responseTsk.Result;
            response.EnsureSuccessStatusCode();

            var responseTextTsk = response.Content.ReadAsStringAsync();
            responseTextTsk.Wait();

            var bolinhas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BolinhaMVC>>(responseTextTsk.Result);
            Console.Clear();

            Console.WriteLine("Lista de bolinhas:");
            foreach(var bolinha in bolinhas)
            {
                Console.WriteLine($"ID: {bolinha.IdBolinha}     Nome: {bolinha.NomeBolinha}");
            }

            Console.WriteLine("");
            Console.WriteLine("Aperte qualquer coisa para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void Adicionar()
        {
            Console.WriteLine("Qual o nome da bolinha");
            var bolinha = new BolinhaMVC();
            bolinha.NomeBolinha = Console.ReadLine();

            var bolinhaJson = Newtonsoft.Json.JsonConvert.SerializeObject(bolinha);

            //Console.WriteLine($"O nome da bolinha é {bolinha.NomeBolinha}");
            //Console.WriteLine($"Os dados serializados da bolinha são: {bolinhaJson}");

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44364/api/v1/bolinha");

            var content = new StringContent(bolinhaJson, null, "application/json");
            request.Content = content;

            var responseTsk = client.SendAsync(request);
            responseTsk.Wait();

            var response = responseTsk.Result;
            response.EnsureSuccessStatusCode();
            Console.WriteLine($"Bolinha adicionada!");
        }

        private static void Remover()
        {
            Console.WriteLine("Informe o ID para remover");
            var idRemover = Console.ReadLine();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:44364/api/v1/bolinha/{idRemover}");

            var responseTst = client.SendAsync(request);
            responseTst.Wait();

            var response = responseTst.Result;
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Registro excluído");
        }
    }
}
