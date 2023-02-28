using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ef_code_first_tutorial;
using ef_code_first_tutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_code_first_tutorial.Controllers
{
    public class CustomersController
    {
        private readonly SalesDbContext _customersContext; // using an underscore in property / field names is a 
                                                           // convention to show that it's private and belongs
                                                           // to the class
        public CustomersController()
        {
            _customersContext = new SalesDbContext();
        }

        public async Task<ICollection<Customer>> GetCustomers()
        {
            return await _customersContext.Customers.ToListAsync();
                                
        }

        public async Task<Customer?> GetCustomer(int id)
        {
            return await _customersContext.Customers.FindAsync(id);
        }

        public async Task<Customer?> GetCustomerWithOrders(int id)
        {
            return await _customersContext.Customers
                                          .Include(customer => customer.Orders)
                                          .ThenInclude(order => order.OrderLines)
                                          .ThenInclude(orderline => orderline.Item)
                                          .SingleOrDefaultAsync(customer => customer.Id == id);
        }

        public async Task<Customer> InsertCustomer(Customer custInst)
        {
            _customersContext.Customers.Add(custInst);
            int changes = await _customersContext.SaveChangesAsync();
            if (changes != 1)
            {
                throw new Exception("Insert failed");
            }
            return custInst;
        }

        public async Task UpdateCustomer(int id, Customer custInst)
        {
            if(id != custInst.Id)
            {
                throw new Exception("Customer id doesn't match!");
            }
            _customersContext.Entry(custInst).State = EntityState.Modified;
            int changes = await _customersContext.SaveChangesAsync();
            if(changes != 1)
            {
                throw new Exception("Update failed!");
            }
        }

        public async Task DeleteCustomer(int id)
        {
            Customer? custToDelete = await GetCustomer(id);
            if (custToDelete is null)
            {
                throw new Exception("Not found!");
            }
            _customersContext.Customers.Remove(custToDelete);
            int changes = await _customersContext.SaveChangesAsync();
            if (changes != 1)
            {
                throw new Exception("Delete falied.");
            }
        }
    }
}
