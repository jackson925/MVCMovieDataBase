﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMovieDB.Models;
using System.Data.Entity;
using MVCMovieDB.ViewModels;


namespace MVCMovieDB.Controllers
{
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
            var customers = _context.Customers.Include(v => v.MembershipType).ToList();

            return View(customers);
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
                MembershipTypes = membershipTypes
        };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
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
        public ActionResult Edit(Customer customer)
        {
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