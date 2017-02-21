﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }

        //disposoble object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose( );    
        }

        public ActionResult New()
        {
            return View();
        }


        // GET: Customers, from dbset from database , 
        public ViewResult Index()
        {
            // var customers = GetCustomers();
            // deferred excecution,
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id) {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            return View(customer);

        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //       new Customer { Id= 1, Name = "Smith John"  },
        //       new Customer { Id= 2, Name = "Mary Williams "  }

        //    };
        //}

    }
}