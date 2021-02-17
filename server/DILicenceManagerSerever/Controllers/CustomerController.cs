using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;

namespace DILicenseManagerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(DataAccess.Context.LicensingDbContext context, IMapper mapper)        //ctor ->tab, tab
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult GetAllCustomers()
        {

            try
            {
                var DBList = _context.Customer.ToList();
                //List<Models.Sysem.Customer> dbList = _context.Customer.ToList();
                return Ok(DBList);      //200 OK status code with the result from the database
            }
            catch (Exception exc)
            {
                log.Error("fail to get all customers", exc);
                return BadRequest("fail to get all customers" + exc.Message);
            }

        }



        [HttpGet]
        [Route("Single")]

        public ActionResult GetSingleCustomer(int CustomerID)
        {

            try
            {
                var DBItem = _context.Customer.Find(CustomerID);
                if (DBItem == null)
                {
                    return BadRequest("There is no Customer found by that id: " + CustomerID);
                }

                var retVal = _mapper.Map<Models.System.DTO.CustomerDTO>(DBItem);

                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("fail to get customer by id: " + CustomerID, exc);
                return BadRequest("fail to get customer by id" + exc.Message);
            }

        }



        [HttpPost]
        public ActionResult CreateCustomer([FromBody] Models.System.DTO.CustomerDTO requestDTO)       //FromBody means ((if youre using postman))
        {
            try
            {
                var request = _mapper.Map<Models.System.Customer>(requestDTO);       //add[FromBody} and saveChanges

                _context.Customer.Add(request);
                _context.SaveChanges();

                if (request == null)
                {
                    return BadRequest("Failed to create customer, database returned null");
                }

                return Ok(_mapper.Map<Models.System.DTO.CustomerDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to return customer.", exc);
                return BadRequest("Failed to return customer." + exc.Message);
            }
        }



        [HttpPut]
        public ActionResult UpdateCustomer([FromBody] Models.System.DTO.CustomerDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Customer>(requestDTO);

                _context.Update(request);
                _context.SaveChanges();

                if (request == null)
                {
                    return BadRequest("Failed to update the AdminUser : Database returned null");
                }
                return Ok(_mapper.Map<Models.System.DTO.CustomerDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("fail to delete customer ", exc);
                return BadRequest("fail to delete customer" + exc.Message);
            }
        }



        [HttpDelete]

        public ActionResult DeleteCustomer(int ID)
        {
            try
            {
                var dbItem = _context.Customer.Find(ID);

                var success = _context.Entry(dbItem).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delete Customer", exc);
                return BadRequest("Failed to delete Customer. " + exc.Message);
            }
        }

    }

}
