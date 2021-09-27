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

namespace weatherapi.Services
{
    public class WheatherService : IWheatherService
    {
        private readonly string APIKey = "4c8aa095e62b406eb71211822202311";
        private HttpClient _client;
        // private readonly IMediator _mediator;

        public WheatherService()
        {
            //_client = httpClient;
            //_client.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");
            //  _mediator = mediator;
        }
        public async Task<CurrentWeatherInformation> GetAsync(string cityName)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");

            string url = $"?key={APIKey}&q={cityName}";
            HttpResponseMessage response = await _client.GetAsync(url);
            Stream responseBody = await response.Content.ReadAsStreamAsync();

            var weatherApiDto = await JsonSerializer.DeserializeAsync<CurrentWeatherInformation>(responseBody);
            //Rabbi mq
            var messageBody = Encoding.UTF8.GetBytes(weatherApiDto.ToString());
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("Qwether", durable: false, exclusive: false, autoDelete: false, arguments: null);

            channel.BasicPublish(exchange: "", routingKey: "Qwether", basicProperties: null, body: messageBody);
            return weatherApiDto;
        }
    }
}
