using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMovieDB.Models;
using System.Data.Entity;
using MVCMovieDB.ViewModels;


namespace MVCMovieDB.Controllers
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        
        public ActionResult CustomerIndex()
        {
            //var customers = _context.Customers.Include(v => v.MembershipType).ToList();

            return View();
        }
        public ActionResult CustomerDetails(Customer customer)
        {
           

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
                if (customer.Id == 0)
                    _context.Customers.Add(customer);
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                    customerInDb.Name = customer.Name;
                    customerInDb.Birthdate = customer.Birthdate;
                    customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                    customerInDb.MembershipType = customer.MembershipType;
                    
                    
                }
                _context.SaveChanges();

                return View("CustomerIndex", "Customers");
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("CustomerIndex", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("CustomerForm", viewModel);
        }
        
    }
}