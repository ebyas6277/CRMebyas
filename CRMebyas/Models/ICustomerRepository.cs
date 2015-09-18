using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMebyas.Models
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer customer);
        void AddNote(Note note);

        int SaveChanges();
    }
}
