using CRMebyas.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace CRMebyas.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private ICustomerRepository customerRepository = null;

        public CustomersController() : this(new CustomerRepository())
        {

        }

        public CustomersController(ICustomerRepository customerRepo)
        {
            customerRepository = customerRepo;
        }

        // GET: Customers
        public ActionResult Index()
        {
            IEnumerable<Customer> customers = customerRepository.GetAllCustomers();
            return View("Index", customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = customerRepository.GetCustomerById((int)id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            
            return View("Details", customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Company,Email,Address,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerRepository.AddCustomer(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = customerRepository.GetCustomerById((int)id);
            
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View("Edit", customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Company,Email,Address,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerRepository.UpdateCustomer(customer);                
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = customerRepository.GetCustomerById((int)id);
            
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View("Delete", customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customerRepository.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

        // GET: Customers/AddNote
        public ActionResult AddNote()
        {
            return View("AddNote");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNote(int? id, [Bind(Include = "Body")] Note note)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                note.CustomerID = (int)id;
                note.DateEntered = DateTime.Now;

                if (User != null)
                {
                    note.UserId = User.Identity.GetUserId();
                }
                
                customerRepository.AddNote(note);
            }

            return RedirectToAction("Index");
        }
    }
}
