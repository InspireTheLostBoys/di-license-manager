using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DILicenseManagerServer.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SiteController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;


        public SiteController(DataAccess.Context.LicensingDbContext context, IMapper mapper)        //ctor ->tab, tab
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllSites()
        {

            try
            {
                var DBList = _context.Site.ToList();
                //List<Models.Sysem.Site> dbList = _context.Site.ToList();
                return Ok(DBList);      //200 OK status code with the result from the database
            }
            catch (Exception exc)
            {
                log.Error("fail to get all sites", exc);
                return BadRequest("fail to get all sites" + exc.Message);
            }

        }


        [HttpGet]
        [Route("GetSitesByCustomerID")]
        public ActionResult GetAllSitesByCustomerID(int CustomerID)
        {

            try
            {
                var DBList = _context.Site.Where(m => m.CustomerID == CustomerID).ToList();
                //List<Models.Sysem.Site> dbList = _context.Site.ToList();
                return Ok(_mapper.Map<List<Models.System.DTO.SiteDTO>>(DBList));      //200 OK status code with the result from the database
            }
            catch (Exception exc)
            {
                log.Error("fail to get all sites by customerID. ", exc);
                return BadRequest("fail to get all sites by customerID. " + exc.Message);
            }

        }



        [HttpGet]
        [Route("Single")]

        public ActionResult GetSingleSite(int SiteID)
        {
            try
            {
                var dbItem = _context.Site.Find(SiteID);
                if (dbItem == null)
                {
                    return BadRequest("There is no site found by that id: " + SiteID);
                }

                var retVal = _mapper.Map<Models.System.DTO.SiteDTO>(dbItem);
                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get single site with ID : " + SiteID, exc);
                return BadRequest("Failed to get single Site : " + exc.Message);
            }
        }




        [HttpPost]
        public ActionResult CreateSite([FromBody] Models.System.DTO.SiteDTO requestDTO)       //FromBody means ((if youre using postman))
        {
            try
            {
                var request = _mapper.Map<Models.System.Site>(requestDTO);       //add[FromBody} and saveChanges

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
                log.Error("Failed to create site.", exc);
                return BadRequest("Failed to create site." + exc.Message);
            }
        }



        [HttpPut]
        public ActionResult UpdateSite([FromBody] Models.System.DTO.SiteDTO requestDTO)
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
                log.Error("fail to update site. ", exc);
                return BadRequest("fail to update site. " + exc.Message);
            }
        }



        [HttpDelete]
        public ActionResult DeleteSite(int ID)
        {
            try
            {
                var dbItem = _context.Site.Find(ID);

                var success = _context.Entry(dbItem).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delete site ", exc);
                return BadRequest("Failed to delete Site: " + exc.Message);
            }
        }

    }

}
