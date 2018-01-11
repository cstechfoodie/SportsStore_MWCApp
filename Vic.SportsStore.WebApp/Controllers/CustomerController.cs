using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository repo;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.repo = customerRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }
    }
}