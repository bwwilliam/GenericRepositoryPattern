using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.GenericAPI.DAL;
using MyCompany.GenericAPI.DAL.Models;

namespace MyCompany.GenericAPI.Demo.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
    
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _customerRepository.GetAll().Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
