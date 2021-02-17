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
    public class LicenseController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;


        public LicenseController(DataAccess.Context.LicensingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllLicenses()
        {
            try
            {
                List<Models.System.License> dbList = _context.Licenses.ToList();
                return Ok(dbList);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get all Licenses", exc);
                return BadRequest("Failed to get all Licenses : " + exc.Message);
            }


        }

        [HttpGet("{ID:int}")]
        public ActionResult GetSingleLicense(int ID)
        {
            try
            {
                var dbItem = _context.Licenses.Find(ID);
                if (dbItem == null)
                {
                    return BadRequest("There is no License found by that id: " + ID);
                }



                var retVal = _mapper.Map<Models.System.DTO.LicenseDTO>(dbItem);



                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get single License with ID : " + ID, exc);
                return BadRequest("Failed to get single License : " + exc.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateCustomer([FromBody] Models.System.DTO.LicenseDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.License>(requestDTO);



                _context.Licenses.Add(request);
                _context.SaveChanges();



                if (request == null)
                {
                    return BadRequest("Failed to create License, database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.LicenseDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to create License.", exc);
                return BadRequest("Failed to create License : " + exc.Message);
            }

        }
        [HttpPut]
        public ActionResult UpdateLicense([FromBody] Models.System.License requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.License>(requestDTO);
                _context.Update(request);
                _context.SaveChanges();
                if (request == null)
                {
                    return BadRequest("Failed to update the License : Database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.LicenseDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to update the License", exc);
                return BadRequest("Failed to update the License : " + exc.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteLicense(int LicenseID)
        {
            try
            {
                var dbExists = _context.Licenses.Find(LicenseID);
                if (dbExists == null)
                {
                    return BadRequest(": " + LicenseID);
                }

                _context.Remove(dbExists);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delte License", exc);
                return BadRequest("Failed to delete License" + exc.Message);
            }
        }

        //[HttpGet]
        //[Route("SendExpiring")]
        //public ActionResult GetExpiringAndSend()
        //{
        //    try
        //    {
        //        Email.LicenseEmailer licenseEmailer = new email.LicenseEmailer();
        //        licenseEmailer.Run(_context, _configuration.GetConnectionString("DefaultConnection"));



        //        return Ok();
        //    }
        //    catch (Exception exc)
        //    {
        //        return BadRequest("Failed : " + exc.Message);
        //    }
        //}
    }
}