using Microsoft.EntityFrameworkCore;
using OrderTrackingApp.Helpers;
using OrderTrackingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderTrackingApp.Data
{
    public static class AddOrders
    {
        private static List<Order> orders = new List<Order>();

        private static void GenerateOrders(ApplicationDBContext db)
        {
            for (int i = 0; i < 100; i++) // let's generate 100 orders
            {
                string orderId = GenerateOrderId();
                Random random = new Random();

                List<OrderCart> orderCarts = new List<OrderCart>();
                int numberOfItems = random.Next(1, 6); // generate a realistic number of items in an order
                for (int j = 0; j < numberOfItems; j++)
                {
                    int randomIndex = random.Next(0, db.Item.AsNoTracking().Count()); // random item
                    OrderCart orderCart = new OrderCart();
                    orderCart.OrderId = orderId;
                    orderCart.ItemId = db.Item.AsNoTracking().Skip(randomIndex).First().Id;
                    orderCarts.Add(orderCart);
                }

                Order order = new Order();
                order.Id = orderId;
                order.Status = GenerateRandomStatus(db);
                order.Cart = orderCarts;

                orders.Add(order);
            }
        }

        private static string GenerateOrderId() // format: QWER1234
        {
            StringBuilder id = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int num = random.Next(0, 26); // 25 letters in alphabet
                char letter = (char)('a' + num);
                id.Append(letter.ToString().ToUpper());
            }
            for (int i = 0; i < 4; i++)
            {
                int num = random.Next(0, 10);
                id.Append(num.ToString());
            }
            if (!orders.Any(x => x.Id == id.ToString()))
            {
                return id.ToString();
            }
            else
            {
                GenerateOrderId();
                return id.ToString();
            }
        }

        private static OrderStatus GenerateRandomStatus(ApplicationDBContext db)
        {
            OrderStatus orderStatus = new OrderStatus();
            Random random = new Random();
            orderStatus = db.OrderStatus.Skip(random.Next(0, db.OrderStatus.Count() - 1)).First();
            return orderStatus;
        }



        public static void InsertToDB(ApplicationDBContext db)
        {
            if (db.Order.Any())
            {
                return;
            }
            GenerateOrders(db);
            foreach (Order order in orders)
            {
                db.Order.Add(order);
                db.SaveChanges();
            }
        }
    }
}
