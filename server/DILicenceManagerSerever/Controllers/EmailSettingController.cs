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
    public class EmailSettingController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;


        public EmailSettingController(DataAccess.Context.LicensingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllEmailSettings()
        {
            try
            {
                List<Models.System.EmailSetting> dbList = _context.EmailSettings.ToList();
                return Ok(dbList);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get all EmailSettings", exc);
                return BadRequest("Failed to get all EmailSettings : " + exc.Message);
            }


        }

        [HttpGet("{ID:int}")]
        public ActionResult GetSingleEmailSetting(int ID)
        {
            try
            {
                var dbItem = _context.EmailSettings.Find(ID);
                if (dbItem == null)
                {
                    return BadRequest("There is no Email found by that id: " + ID);
                }



                var retVal = _mapper.Map<Models.System.DTO.EmailSettingsDTO>(dbItem);



                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get single Email with ID : " + ID, exc);
                return BadRequest("Failed to get single Email : " + exc.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateCustomer([FromBody] Models.System.DTO.EmailSettingsDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.EmailSetting>(requestDTO);



                _context.EmailSettings.Add(request);
                _context.SaveChanges();



                if (request == null)
                {
                    return BadRequest("Failed to create Email, database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.EmailSettingsDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to create Email.", exc);
                return BadRequest("Failed to create Email : " + exc.Message);
            }

        }
        [HttpPut]
        public ActionResult UpdateEmailSetting([FromBody] Models.System.EmailSetting requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.EmailSetting>(requestDTO);
                _context.Update(request);
                _context.SaveChanges();
                if (request == null)
                {
                    return BadRequest("Failed to update the Email : Database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.EmailSettingsDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to update the Email", exc);
                return BadRequest("Failed to update the Email : " + exc.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteEmailSetting(int EmailSettingID)
        {
            try
            {
                var dbExists = _context.EmailSettings.Find(EmailSettingID);
                if (dbExists == null)
                {
                    return BadRequest(": " + EmailSettingID);
                }

                _context.Remove(dbExists);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delte EmailSetting", exc);
                return BadRequest("Failed to delete EmailSetting" + exc.Message);
            }
        }
    }
}
