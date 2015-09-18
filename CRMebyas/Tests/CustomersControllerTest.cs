using CRMebyas;
using CRMebyas.Controllers;
using CRMebyas.Models;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRMebyas.Tests
{
    [TestFixture]
    public class CustomersControllerTest
    {
        private CustomersController controller;
        private TestCustomerRepository repo;

        public CustomersControllerTest()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { ID = 1, FirstName = "Harold", LastName = "Remus", Company = "Abraxas Petroleum Corporation", Email = "harold_remus@abrp.com", Address = "18803 Meisner Drive, San Antonio, Texas 78258", Phone = 2104904788, Notes = new List<Note>() });
            customers.Add(new Customer { ID = 2, FirstName = "Susan", LastName = "Harrell", Company = "Abraxas Petroleum Corporation", Email = "susan_harrell@abrp.com", Address = "18803 Meisner Drive, San Antonio, Texas 78258", Phone = 2104904784, Notes = new List<Note>() });
            customers.Add(new Customer { ID = 3, FirstName = "Gerald", LastName = "Thomas", Company = "Abraxas Petroleum Corporation", Email = "gerald_thomas@abrp.com", Address = "18803 Meisner Drive, San Antonio, Texas 78258", Phone = 2104904785, Notes = new List<Note>() });
            customers.Add(new Customer { ID = 4, FirstName = "Timothy", LastName = "O'Brien", Company = "Gulfport Energy Corporation", Email = "tobrien@gulfen.com", Address = "14313 North May, Suite 100, Oklahoma City, OK 73134", Phone = 4058488807, Notes = new List<Note>() });
            customers.Add(new Customer { ID = 5, FirstName = "Julie", LastName = "Slack", Company = "Gulfport Energy Corporation", Email = "jslack@gulfen.com", Address = "14313 North May, Suite 100, Oklahoma City, OK 73134", Phone = 4058488806, Notes = new List<Note>() });
            customers.Add(new Customer { ID = 6, FirstName = "Glenn", LastName = "Preston", Company = "JP Oil Holdings, LLC", Email = "gpreston@jpoil.com", Address = "1604 W Pinhook Rd. Ste 300, Lafayette, LA 70508", Phone = 3372341170, Notes = new List<Note>() });
            customers.Add(new Customer { ID = 7, FirstName = "Becky", LastName = "Huston", Company = "JP Oil Holdings, LLC", Email = "bhuston@jpoil.com", Address = "1604 W Pinhook Rd. Ste 300, Lafayette, LA 70508", Phone = 3372341171, Notes = new List<Note>() });

            repo = new TestCustomerRepository(customers);
            controller = new CustomersController(repo);
        }

        [Test]
        public void IndexActionReturnsIndexView()
        {
            string expected = "Index";
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void IndexActionReturnsAllCustomers()
        {
            int expected = repo.GetAllCustomers().Count();
            var result = controller.Index() as ViewResult;
            IEnumerable<Customer> customers = result.Model as IEnumerable<Customer>;
            Assert.AreEqual(expected, customers.Count());
        }

        [Test]
        public void DetailsActionReturnsDetailsView()
        {
            string expected = "Details";
            var result = controller.Details(1) as ViewResult;
            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void DetailsActionReturnsCustomer()
        {
            Customer expected = repo.GetCustomerById(1);
            var result = controller.Details(1) as ViewResult;
            Customer customer = result.Model as Customer;
            Assert.AreEqual(expected, customer);
        }

        [Test]
        public void CreateActionReturnsCreateView()
        {
            string expected = "Create";
            var result = controller.Create() as ViewResult;
            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void CreateActionAddsCustomer()
        {
            Customer customer = new Customer { ID = 8, FirstName = "John", LastName = "Doe", Company = "JP Oil Holdings, LLC", Email = "jdoe@jpoil.com", Address = "1604 W Pinhook Rd. Ste 300, Lafayette, LA 70508", Phone = 3372341171 };
            controller.Create(customer);
            IEnumerable<Customer> customers = repo.GetAllCustomers();
            CollectionAssert.Contains(customers, customer);
        }

        [Test]
        public void EditActionReturnsEditView()
        {
            string expected = "Edit";
            var result = controller.Edit(3) as ViewResult;
            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void EditActionEditsCustomer()
        {
            Customer customer = new Customer { ID = 3, FirstName = "Geraldo", LastName = "Thomas", Company = "Abraxas Petroleum Corporation", Email = "geraldo_thomas@abrp.com", Address = "18803 Meisner Drive, San Antonio, Texas 78258", Phone = 2104904785 };
            controller.Edit(customer);
            IEnumerable<Customer> customers = repo.GetAllCustomers();
            CollectionAssert.Contains(customers, customer);
        }

        [Test]
        public void DeleteActionReturnsDeleteView()
        {
            string expected = "Delete";
            var result = controller.Delete(1) as ViewResult;
            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void DeleteActionDeletesCustomer()
        {
            Customer customer = repo.GetCustomerById(4);
            controller.DeleteConfirmed(4);
            IEnumerable<Customer> customers = repo.GetAllCustomers();
            CollectionAssert.DoesNotContain(customers, customer);
        }

        [Test]
        public void AddNoteActionReturnsAddNoteView()
        {
            string expected = "AddNote";
            var result = controller.AddNote() as ViewResult;
            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void AddNoteActionAddsNoteToCustomer()
        {
            Note note = new Note { ID = 1, Body = "Test Note" };
            controller.AddNote(1, note);
            Customer customer = repo.GetCustomerById(1);
            CollectionAssert.Contains(customer.Notes, note);
        }
    }
}