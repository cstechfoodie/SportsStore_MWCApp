using System;
using System.Collections.Generic;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.Domain.Concrete
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public void SaveCustomer(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                context.Customers.Add(customer);
            }
            else
            {
                Customer dbEntry = context.Customers.Find(customer.CustomerId);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = customer.FirstName;
                    dbEntry.LastName = customer.LastName;
                    dbEntry.Email = customer.Email;
                    dbEntry.Password = customer.Password;
                    dbEntry.Cell = customer.Cell;

                }
            }
            context.SaveChanges();  //update database automatically

        }

        public Customer DeleteCustomer(int customerId)
        {
            Customer dbEntry = context.Customers.Find(customerId);
            if (dbEntry != null)
            {
                context.Customers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
