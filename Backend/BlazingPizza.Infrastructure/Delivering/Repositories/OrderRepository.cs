﻿using BlazingPizza.Domain.Delivering.Entities;
using BlazingPizza.Domain.Shared;
using BlazingPizza.Infrastructure.Delivering.EntityFramework;
using BlazingPizza.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazingPizza.Infrastructure.Delivering.Repositories
{
    internal class OrderRepository : RepositoryBase<Order>, IRepository<Order>
    {
        private readonly DeliveryContext _context;

        public OrderRepository(DeliveryContext context)
        {
            _context = context;
        }

        public void CreateOne(Order entity)
        {
            foreach (var pizza in entity.Pizzas)
            {
                foreach (var topping in pizza.Toppings)
                {
                    topping.Id = (_context.Toppings.FirstOrDefault(t => t.Name == topping.Name) ?? topping).Id;
                }
            }

            _context.Orders.Add(entity);
        }

        public IReadOnlyCollection<TProjected> FindAll<TProjected>(Expression<Func<Order, bool>>? predicate = null, Expression<Func<Order, TProjected>>? projection = null)
        {
            var query = _context.Orders
                .Include(o => o.Pizzas)
                    .ThenInclude(p => p.Toppings)
                .Include(o => o.DeliveryAddress);

            return ApplyProjector(query, predicate, projection).ToList().AsReadOnly();
        }

        public TProjected? FindOne<TProjected>(Expression<Func<Order, bool>>? predicate = null, Expression<Func<Order, TProjected>>? projection = null)
        {
            var query = _context.Orders
                .Include(o => o.Pizzas)
                    .ThenInclude(p => p.Toppings)
                .Include(o => o.DeliveryAddress);

            return ApplyProjector(query, predicate, projection).FirstOrDefault();
        }
    }
}
