using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IBasketRepository _basketRepo;
        private readonly IGenericRepository<DeliveryMethod> _dmRepo;

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<Product> productRepo, IBasketRepository basketRepo, IGenericRepository<DeliveryMethod> dmRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _basketRepo = basketRepo;
            _dmRepo = dmRepo;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            var basket = await _basketRepo.GetBasketAsync(basketId);

            var items = new List<OrderItem>();

            foreach(var item in basket.Items)
            {
                var productItem = await _productRepo.GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            var deliveryMethod = await _dmRepo.GetByIdAsync(deliveryMethodId);

            var subtotal = items.Sum(item => item.Price * item.Quantity);

            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal);

            //TODO: add to db

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new System.NotImplementedException();
        }
    }
}
