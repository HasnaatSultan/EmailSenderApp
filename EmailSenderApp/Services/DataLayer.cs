
using EmailSenderApp.Models;
using System;
using System.Collections.Generic;

namespace EmailSenderApp.Services
{
    public static class DataLayer
    {
        public static List<Customer> ListCustomers()
        {
            return new List<Customer>
            {
                new Customer { Email = "hasnaatsultan@gmail.com", CreatedDateTime = DateTime.Now.AddHours(-7) },
                new Customer { Email = "mail2@mail.com", CreatedDateTime = DateTime.Now.AddDays(-1) },
                new Customer { Email = "mail3@mail.com", CreatedDateTime = DateTime.Now.AddMonths(-6) },
                new Customer { Email = "mail4@mail.com", CreatedDateTime = DateTime.Now.AddMonths(-1) },
                new Customer { Email = "mail5@mail.com", CreatedDateTime = DateTime.Now.AddMonths(-2) },
                new Customer { Email = "mail6@mail.com", CreatedDateTime = DateTime.Now.AddDays(-5) }
            };
        }

        public static List<Order> ListOrders()
        {
            return new List<Order>
            {
                new Order { CustomerEmail = "hasnaatsultan@gmail.com", OrderDatetime = DateTime.Now.AddMonths(-6) },
                new Order { CustomerEmail = "mail5@mail.com", OrderDatetime = DateTime.Now.AddMonths(-2) },
                new Order { CustomerEmail = "mail6@mail.com", OrderDatetime = DateTime.Now.AddDays(-2) }
            };
        }
    }
}
