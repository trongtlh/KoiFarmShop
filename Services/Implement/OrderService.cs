﻿using BusinessObjects.Models;
using DataAccessObjects.DTOs.OrderDTO;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implement
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> CreateOrder(CreateOrderDTO createOrder)
        {
            var order = new Order
            {
                KoiId = createOrder.KoiId,
                KoiFishyId = createOrder.KoiFishyId,
                AccountId = createOrder.AccountId,
                PaymentId = createOrder.PaymentId,
                Status = createOrder.Status,
                Type = createOrder.Type,
                Price = createOrder.Price,
            };
            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task<Order> DeleteOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new Exception($"Order with ID{id} is not found");
            }
            order.IsDeleted = true;
            await _orderRepository.UpdateAsync(order);
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<Order> RestoreOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new Exception($"Order with ID{id} is not found");
            }
            if (order.IsDeleted == true)
            {
                order.IsDeleted = false;
                await _orderRepository.UpdateAsync(order);
            }
            return order;
        }

        public async Task<Order> UpdateOrder(int id, UpdateOrderDTO updateOrder)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new Exception($"Order with ID{id} is not found");
            }
            order.KoiId = updateOrder.KoiId;
            order.KoiFishyId = updateOrder.KoiFishyId;
            order.AccountId = updateOrder.AccountId;
            order.PaymentId = updateOrder.PaymentId;
            order.Status = updateOrder.Status;
            order.Type = updateOrder.Type;
            order.Price = updateOrder.Price;

            await _orderRepository.UpdateAsync(order);
            return order;
        }
    }
}
