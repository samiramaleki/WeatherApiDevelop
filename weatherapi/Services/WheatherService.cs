using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using weatherapi.DTOs;

namespace weatherapi.Services
{
    public class WheatherService
    {
        private readonly string APIKey = "4c8aa095e62b406eb71211822202311";
        private readonly HttpClient _client;

        public WheatherService(HttpClient httpClient)
        {
            _client = httpClient;
            _client.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");
        }
        public async Task<CurrentWeatherInformation> GetAsync(string cityName)
        {
            string url = $"?key={APIKey}&q={cityName}";
            HttpResponseMessage response = await _client.GetAsync(url);
            Stream responseBody = await response.Content.ReadAsStreamAsync();

            var weatherApiDto =
                await JsonSerializer.DeserializeAsync<CurrentWeatherInformation>(responseBody);
            //Rabbi mq

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            //  channel.QueueDeclare("Qwether",)
            return weatherApiDto;
        }
    }
}
