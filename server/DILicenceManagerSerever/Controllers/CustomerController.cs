using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DILicenceManagerSerever.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;


        public CustomerController(DataAccess.Context.LicensingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllCustomers()
        {
            try
            {
                List<Models.System.Customer> dbList = _context.Customers.ToList();
                return Ok(dbList);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get all customers", exc);
                return BadRequest("Failed to get all customers : " + exc.Message);
            }


        }

        [HttpGet("{ID:int}")]
        public ActionResult GetSingleCustomer(int ID)
        {
            try
            {
                var dbItem = _context.Customers.Find(ID);
                if (dbItem == null)
                {
                    return BadRequest("There is no Customer found by that id: " + ID);
                }



                var retVal = _mapper.Map<Models.System.DTO.CustomerDTO>(dbItem);



                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get single Customer with ID : " + ID, exc);
                return BadRequest("Failed to get single Customer : " + exc.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateCustomer([FromBody] Models.System.DTO.CustomerDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Customer>(requestDTO);



                _context.Customers.Add(request);
                _context.SaveChanges();



                if (request == null)
                {
                    return BadRequest("Failed to create Customer, database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.CustomerDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to create Customer.", exc);
                return BadRequest("Failed to create Customer : " + exc.Message);
            }

        }

        [HttpPut]
        public ActionResult UpdateCustomer([FromBody] Models.System.Customer requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Customer>(requestDTO);
                _context.Update(request);
                _context.SaveChanges();
                if (request == null)
                {
                    return BadRequest("Failed to update the Customer : Database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.CustomerDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to update the Customer", exc);
                return BadRequest("Failed to update the Customer : " + exc.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteCustomer(int customerID)
        {
            try
            {
                var dbExists = _context.Customers.Find(customerID);
                if (dbExists == null)
                {
                    return BadRequest(": " + customerID);
                }

                _context.Remove(dbExists);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delte customer", exc);
                return BadRequest("Failed to delete customer" + exc.Message);
            }
        }
    }
}

