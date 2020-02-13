using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using RestSharp;

namespace SeedData
{
    class Program
    {
        static void Main(string[] args)
        {
            Seed();
        }

        public class VM
        {
            public string NumeroDoProcesso { get; set; }
            public DateTime dataDeCriacaoDoProcesso { get; set; }
            public decimal valor { get; set; }
            public int escritorioId { get; set; }
        }
        
        private static async Task Seed()
        {
            var j = new VM();
            j.NumeroDoProcesso = "8888";
            j.dataDeCriacaoDoProcesso = DateTime.Now;
            j.valor = 567.00m;
            j.escritorioId = 3;

            var client = new RestClient("http://localhost:5000/api/Main");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Content-Type", "application/json");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("numeroDoProcesso", " 88888");
            request.AddParameter("valor", " 456.00");
            request.AddParameter("escritorioId", " 2");
            request.AddParameter("dataDeCriacaoDoProcesso", " 2019-01-01");

            //request.JsonSerializer.Serialize(j);
            request.AddJsonBody(j);
            var f = request.Body;
            request.RequestFormat = DataFormat.Json;
            
            
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        public string GenerateRandomStrings()
        {
            var random = new Random();
            var tamanho = random.Next(1, 25);
            var strings = "abcdefghijklmopqrstuvxywzABCDEFGHIJKLMNOPQRSTUVXYWZ";
            var result = new string(Enumerable.Repeat(strings, tamanho).Select(s => s[random.Next(s.Length)]).ToArray());

            return result;
        }

    }
}
