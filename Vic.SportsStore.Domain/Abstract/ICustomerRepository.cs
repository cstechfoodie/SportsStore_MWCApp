using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.Domain.Abstract
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
    }
}
