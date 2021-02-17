using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;

namespace DIEmailManagerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;



        public EmailController(DataAccess.Context.LicensingDbContext context, IMapper mapper)        //ctor ->tab, tab
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult GetAllEmails()
        {

            try
            {
                var DBList = _context.EmailSettings.ToList();
                //List<Models.Sysem.EmailSettings> dbList = _context.EmailSettings.ToList();
                return Ok(DBList);      //200 OK status code with the result from the database
            }
            catch (Exception exc)
            {
                log.Error("fail to get all emails", exc);
                return BadRequest("fail to get all emails" + exc.Message);
            }

        }



        [HttpGet]
        [Route("Single")]
        public ActionResult GetSingleEmail(int EmailID)
        {

            try
            {
                var dbItem = _context.EmailSettings.Find(EmailID);
                if (dbItem == null)
                {
                    return BadRequest("There is no Email found by that id: " + EmailID);

                }

                var mappedItem = _mapper.Map<Models.System.DTO.EmailSettingsDTO>(dbItem);
                return Ok(mappedItem);
            }
            catch (Exception exc)
            {
                log.Error("fail to get email by id: " + EmailID, exc);
                return BadRequest("fail to get email by id" + exc.Message);


            }
        }





        [HttpPost]
        public ActionResult CreateEmail([FromBody] Models.System.DTO.EmailSettingsDTO requestDTO)       //FromBody => ((if youre using postman))
        {
            try
            {
                var request = _mapper.Map<Models.System.EmailSettings>(requestDTO);

                _context.EmailSettings.Add(request);       //add[FromBody} and saveChanges
                _context.SaveChanges();

                if (request == null)
                {
                    return BadRequest("Failed to create email, database returned null");
                }

                return Ok(_mapper.Map<Models.System.DTO.EmailSettingsDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to return email.", exc);
                return BadRequest("Failed to return email." + exc.Message);
            }
        }



        [HttpPut]
        public ActionResult UpdateEmail([FromBody] Models.System.DTO.EmailSettingsDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.EmailSettings>(requestDTO);

                _context.Update(request);
                _context.SaveChanges();
                if (request == null)
                {
                    return BadRequest("Email could not be updated. ");
                }
                return Ok(_mapper.Map<Models.System.DTO.EmailSettingsDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("fail to update email. ", exc);
                return BadRequest("fail to update email. " + exc.Message);
            }
        }


        [HttpDelete]
        public ActionResult DeleteEmail(int ID)
        {
            try
            {
                var dbItem = _context.EmailSettings.Find(ID);
                var success = _context.Entry(dbItem).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("fail to delete email by id: " + ID, exc);
                return BadRequest("fail to delete email. " + exc.Message);
            }
        }

    }

}
