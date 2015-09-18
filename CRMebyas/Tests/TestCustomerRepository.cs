using CRMebyas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMebyas.Tests
{
    public class TestCustomerRepository : ICustomerRepository
    {
        private List<Customer> db = null;

        public TestCustomerRepository(List<Customer> customers)
        {
            db = customers;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return db.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer =  db.Find(d => d.ID == id);
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            db.Add(customer);
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = db.Find(d => d.ID == id);
            db.Remove(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            int ID = customer.ID;
            Customer customerToUpdate = db.Find(d => d.ID == ID);
            db.Remove(customerToUpdate);            
            db.Add(customer);
        }

        public void AddNote(Note note)
        {
            int ID = note.CustomerID;
            Customer customer = db.Find(d => d.ID == ID);
            customer.Notes.Add(note);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}