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
    }
}
