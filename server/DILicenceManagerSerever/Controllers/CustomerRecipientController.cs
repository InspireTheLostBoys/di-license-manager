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
    public class CustomerRecipientController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;


        public CustomerRecipientController(DataAccess.Context.LicensingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult GetAllCustomerRecipients()
        {
            try
            {
                List<Models.System.Recipient> dbList = _context.Recipient.ToList();
                return Ok(dbList);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get all CustomerRecipients", exc);
                return BadRequest("Failed to get all CustomerRecipients : " + exc.Message);
            }


        }

        [HttpGet("{ID:int}")]
        public ActionResult GetSingleCustomerRecipient(int ID)
        {
            try
            {
                var dbItem = _context.Recipient.Find(ID);
                if (dbItem == null)
                {
                    return BadRequest("There is no CustomerRecipient found by that id: " + ID);
                }



                var retVal = _mapper.Map<Models.System.DTO.RecipientDTO>(dbItem);



                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get single CustomerRecipient with ID : " + ID, exc);
                return BadRequest("Failed to get single CustomerRecipient : " + exc.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateCustomer([FromBody] Models.System.DTO.RecipientDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Recipient>(requestDTO);



                _context.Recipient.Add(request);
                _context.SaveChanges();



                if (request == null)
                {
                    return BadRequest("Failed to create Recipient, database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.RecipientDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to create Recipient.", exc);
                return BadRequest("Failed to create Recipient : " + exc.Message);
            }

        }
        [HttpPut]
        public ActionResult UpdateCustomerRecipient([FromBody] Models.System.Recipient requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Recipient>(requestDTO);
                _context.Update(request);
                _context.SaveChanges();
                if (request == null)
                {
                    return BadRequest("Failed to update the Recipient : Database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.RecipientDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to update the Recipient", exc);
                return BadRequest("Failed to update the Recipient : " + exc.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteCustomerRecipient(int CustomerRecipientID)
        {
            try
            {
                var dbExists = _context.Recipient.Find(CustomerRecipientID);
                if (dbExists == null)
                {
                    return BadRequest(": " + CustomerRecipientID);
                }

                _context.Remove(dbExists);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delte CustomerRecipient", exc);
                return BadRequest("Failed to delete CustomerRecipient" + exc.Message);
            }
        }
    }
}
