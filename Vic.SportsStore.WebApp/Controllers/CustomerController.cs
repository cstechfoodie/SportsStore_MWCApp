using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Models;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository repo;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.repo = customerRepository;
        }

        [HttpGet]
        public ViewResult LogIn()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(CustomerLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string email = model.Email.Trim();
                string pwd = model.Pwd.Trim();
                Customer customer = repo.Customers.FirstOrDefault(m => m.Email == email && m.Password.Trim() == pwd);
                if (customer != null)
                {
                    Session["customerId"] = customer.CustomerId;
                    Session["name"] = customer.FirstName;
                    return RedirectToAction("List", "Product");
                }
                else
                {
                    ModelState.AddModelError("loginFailed", "Incorrect email and password!");
                    return View();
                    //return RedirectToAction("List", "Product");
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                
                Customer customer = repo.Customers.FirstOrDefault(x => x.Email == model.Email);
                if(customer == null)
                {
                    customer = new Customer();
                    customer.FirstName = model.FirstName;
                    customer.LastName = model.LastName;
                    customer.Email = model.Email;
                    customer.Password = model.Password;
                    customer.Cell = model.Cell;

                    customer.CustomerId = 0;
                    repo.SaveCustomer(customer);
                    //could send a confirmation email
                    return RedirectToAction("LogIn","Customer");
                }
                else
                {
                    ModelState.AddModelError("registerFailed", "The email has been used. Please change to another one");
                    return View();
                }

            }
            else{
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session["name"] = null;
            Session["Cart"] = null;
            return RedirectToAction("List","Product");
        }

        public ActionResult Myprofile()
        {
            Customer customer = repo.Customers.FirstOrDefault(x => x.CustomerId == (int)Session["CustomerId"]);
            if(customer != null)
            {
                return View(customer);
            }
            return RedirectToAction("LogIn", "Customer");
        }

    }
}