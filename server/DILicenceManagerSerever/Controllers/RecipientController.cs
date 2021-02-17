using log4net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace DIRecipientManagerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipientController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;

        public RecipientController(DataAccess.Context.LicensingDbContext context, IMapper mapper)        //ctor ->tab, tab
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult GetAllRecipients()
        {

            try
            {
                var DBList = _context.Recipient.ToList();

                return Ok(DBList);
            }
            catch (Exception exc)
            {
                log.Error("fail to get all recipients", exc);
                return BadRequest("fail to get all recipients" + exc.Message);
            }

        }


        [HttpGet]
        [Route("GetRecipientsBySiteID")]
        public ActionResult GetAllRecipientsBySiteID(int SiteID)
        {

            try
            {
                var DBList = _context.Recipient.Where(m => m.SiteID == SiteID).ToList();

                return Ok(_mapper.Map<List<Models.System.DTO.RecipientDTO>>(DBList));
            }
            catch (Exception exc)
            {
                log.Error("fail to get all recipients by siteID. ", exc);
                return BadRequest("fail to get all sites by siteID. " + exc.Message);
            }

        }





        [HttpGet]
        [Route("Single")]

        public ActionResult GetSingleRecipient(int RecipientID)
        {

            try
            {
                var DBItem = _context.Recipient.Find(RecipientID);
                if (DBItem == null)
                {
                    return BadRequest("There is no recipient found by that id: " + RecipientID);
                }

                var retVal = _mapper.Map<Models.System.DTO.RecipientDTO>(DBItem);

                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("fail to get recipient by id: " + RecipientID, exc);
                return BadRequest("fail to get recipient by id" + exc.Message);

            }
        }



        [HttpPost]
        public ActionResult CreateRecipient([FromBody] Models.System.DTO.RecipientDTO requestDTO)       //FromBody means ((if youre using postman))
        {
            try
            {
                var request = _mapper.Map<Models.System.Recipient>(requestDTO);       //add[FromBody} and saveChanges

                _context.Recipient.Add(request);
                _context.SaveChanges();

                if (request == null)
                {
                    return BadRequest("Failed to create recipient, database returned null");
                }

                return Ok(_mapper.Map<Models.System.DTO.RecipientDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to return recipient.", exc);
                return BadRequest("Failed to return recipient." + exc.Message);
            }
        }



        [HttpPut]
        public ActionResult UpdateRecipient([FromBody] Models.System.DTO.RecipientDTO requestDTO)
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
                log.Error("fail to delete recipient by id: ", exc);
                return BadRequest("fail to delete recipient by id" + exc.Message);
            }
        }



        [HttpDelete]
        public ActionResult DeleteRecipient(int ID)
        {
            try
            {
                var dbItem = _context.Recipient.Find(ID);

                var success = _context.Entry(dbItem).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delete Recipient", exc);
                return BadRequest("Failed to delete Recipient : " + exc.Message);
            }
        }

    }

}
