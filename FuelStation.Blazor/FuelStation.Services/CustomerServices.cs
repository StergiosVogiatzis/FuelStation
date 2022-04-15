using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Model;

namespace FuelStation.Services
{
    public class CustomerService
    {
        public CustomerService()
        {

        }
        public async Task<Customer> CheckCardNumber(List<Customer> customers, string cardNumber)
        {
            foreach (var customer in customers)
            {
                if (customer.CardNumber == cardNumber)
                {
                    return customer;
                }
            }
            var newCustomer = new Customer() { CardNumber = cardNumber };
            return newCustomer;
        }
    }
}
