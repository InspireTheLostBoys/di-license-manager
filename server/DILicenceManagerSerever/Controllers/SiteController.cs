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
    public class SiteController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;


        public SiteController(DataAccess.Context.LicensingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllSites()
        {
            try
            {
                List<Models.System.Site> dbList = _context.Site.ToList();
                return Ok(dbList);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get all Site", exc);
                return BadRequest("Failed to get all Site : " + exc.Message);
            }


        }

        [HttpGet("{ID:int}")]
        public ActionResult GetSingleSite(int ID)
        {
            try
            {
                var dbItem = _context.Site.Find(ID);
                if (dbItem == null)
                {
                    return BadRequest("There is no Site found by that id: " + ID);
                }



                var retVal = _mapper.Map<Models.System.DTO.SiteDTO>(dbItem);



                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get single Site with ID : " + ID, exc);
                return BadRequest("Failed to get single Site : " + exc.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateCustomer([FromBody] Models.System.DTO.SiteDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Site>(requestDTO);
                _context.Site.Add(request);
                _context.SaveChanges();



                if (request == null)
                {
                    return BadRequest("Failed to create Site, database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.SiteDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to create Site.", exc);
                return BadRequest("Failed to create Site : " + exc.Message);
            }

        }
        [HttpPut]
        public ActionResult UpdateSite([FromBody] Models.System.Site requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Site>(requestDTO);
                _context.Update(request);
                _context.SaveChanges();
                if (request == null)
                {
                    return BadRequest("Failed to update the Site : Database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.SiteDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to update the Site", exc);
                return BadRequest("Failed to update the Site : " + exc.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteSite(int SiteID)
        {
            try
            {
                var dbExists = _context.Site.Find(SiteID);
                if (dbExists == null)
                {
                    return BadRequest(": " + SiteID);
                }

                _context.Remove(dbExists);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delte Site", exc);
                return BadRequest("Failed to delete Site" + exc.Message);
            }
        }
    }
}
