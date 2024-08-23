using KooBits.Application.Interfaces;
using KooBits.Domain.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace KooBits.Application.Services 
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly HttpClient _httpClient;

        public OrderService(IOrderRepository orderRepository, HttpClient httpClient)
        {
            _orderRepository = orderRepository;
            _httpClient = httpClient;
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
                var url = $"{"http://localhost:5175/api/Users"}/{order.UserId}";

                // GET request to check user                                                        
                var response = await _httpClient.GetAsync(url);
                 
                response.EnsureSuccessStatusCode();

                // Read and return the response content
                var content = await response.Content.ReadAsStringAsync(); 
                JObject jsonObject = JObject.Parse(content);
                 
                int id = (int)jsonObject["id"];
                if (id != order.UserId)
                { 
                    throw new Exception("Invalid UserID");
                }

                await _orderRepository.AddUserOrderAsync(order);
            }
            catch (HttpRequestException ex)
            { 
                throw new Exception("Request failed");
            }

        }
    }
}
