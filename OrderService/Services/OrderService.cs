using KooBits.MicroServices.OrderServices.Interfaces;
using KooBits.MicroServices.OrderServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace KooBits.MicroServices.OrderServices.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OrderService(IOrderRepository orderRepository, HttpClient httpClient, IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _orderRepository.GetOrderByIdAsync(id);
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return _orderRepository.GetAllOrdersAsync();
        }

        public async Task AddOrderAsync(Order order)
        {

            try
            {
                //TODO : Need to ADD RefUsers table and config User Microservice to Order Microservice Consumer/Subuscriber patter via KAFKA
                // Then we can avoind this API call since Reference tables are syncing with Main table from User Domain

                var baseUrl = _configuration.GetValue<string>("User:Url");
                var url = $"{baseUrl}/{order.UserId}";

                // GET request to check user                                                        
                var response = await _httpClient.GetAsync(url);
                  
                // Read and return the response content
                var content = await response.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(content);

                int id = (int)jsonObject["id"];
                if (id != order.UserId)
                {
                    throw new InvalidOperationException("Invalid user id");
                }

                await _orderRepository.AddUserOrderAsync(order);
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("Request failed");
            }

        }
    }
}
