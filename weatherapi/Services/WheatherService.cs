using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using weatherapi.DTOs;
using weatherapi.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace weatherapi.Services
{
    public class WheatherService : IWheatherService
    {
        private readonly string APIKey = "4c8aa095e62b406eb71211822202311";
        private HttpClient _client;
        private readonly ILogger<WheatherService> _logger;

        public WheatherService(ILogger<WheatherService> logger)
        {
            _logger = logger;
        }
        public async Task<CurrentWeatherInformation> GetAsync(string cityName)
        {
            //try
            //{
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");

            string url = $"?key={APIKey}&q={cityName}";
            HttpResponseMessage response = await _client.GetAsync(url);
            Stream responseBody = await response.Content.ReadAsStreamAsync();

            var weatherApiDto = await JsonSerializer.DeserializeAsync<CurrentWeatherInformation>(responseBody);

            //Rabbi mq
            var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(weatherApiDto));
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("Qwether", durable: false, exclusive: false, autoDelete: false, arguments: null);

            channel.BasicPublish(exchange: "", routingKey: "Qwether", basicProperties: null, body: messageBody);
            _logger.LogInformation("WetherService", JsonSerializer.Serialize(weatherApiDto));
            return weatherApiDto;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError("There is error", ex);
            //}


        }
    }
}
