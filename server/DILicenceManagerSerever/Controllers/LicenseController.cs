using log4net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using Models.System.DTO;
//using SendGrid;
//using SendGrid.Helpers.Mail;

namespace DILicenseManagerServer.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LicenseController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LicenseController(DataAccess.Context.LicensingDbContext context, IMapper mapper, IConfiguration configuration)        //ctor ->tab, tab
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }







        [HttpGet]
        public ActionResult GetAllLicenses()
        {

            //List<Models.System.DTO.LicenseDTO> isRetval = new List<Models.System.DTO.LicenseDTO>();

            try
            {

                var connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var results = connection.Query<LicenseDTO>(@"SELECT L.ID, L.SiteID, L.ProductID, L.AdminUserID, L.ExpiryDate, L.Notes, S.SiteName AS SiteName, C.CustomerName AS CustomerName, P.ProductName AS ProductName, AU.FirstName + ' ' + AU.LastName AS AdminUserName
                                                                    FROM License AS L

	                                                                INNER JOIN
                                                                    Site AS S
                                                                    ON L.SiteID = S.ID

                                                                    INNER JOIN 
                                                                    Customer AS C 
                                                                    ON C.ID = S.CustomerID

                                                                    INNER JOIN
                                                                    Product AS P
                                                                    ON L.ProductID = P.ID

                                                                    INNER JOIN
                                                                    AdminUser AS AU
                                                                    ON L.AdminUserID = AU.ID").ToList();

                    return Ok(results);
                }

            }
            catch (Exception exc)
            {
                log.Error("fail to get all licenses", exc);
                return BadRequest("fail to get all licenses" + exc.Message);
            }
        }






        [HttpGet]
        [Route("Single")]

        public ActionResult GetSingleLicense(int LicenseID)
        {
            try
            {
                var DBItem = _context.License.Find(LicenseID);
                if (DBItem == null)
                {
                    return BadRequest("There is no license found by that id: " + LicenseID);
                }

                var retVal = _mapper.Map<Models.System.DTO.LicenseDTO>(DBItem);

                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("fail to get license by id: " + LicenseID, exc);
                return BadRequest("fail to get license by id" + exc.Message);

            }
        }






        //[HttpGet]
        //[Route("SendExpiring")]
        //public ActionResult GetExpiringAndSend()
        //{
        //    try
        //    {
        //        Email.LicenseEmailer licenseEmailer = new Email.LicenseEmailer();
        //        licenseEmailer.Run(_context, _configuration.GetConnectionString("DefaultConnection"));

        //        return Ok();
        //    }
        //    catch (Exception exc)
        //    {
        //        return BadRequest("Failed : " + exc.Message);
        //    }
        //}









        [HttpPost]
        public ActionResult CreateLicense([FromBody] Models.System.DTO.LicenseDTO requestDTO)       //FromBody means ((if youre using postman))
        {
            try
            {

                var request = _mapper.Map<Models.System.License>(requestDTO);
                request.ExpiryDate = DateTime.Now;
                request.Notes = "";
                //request.ExpiryDate = DateTime.Now;


                _context.License.Add(request);       //add[FromBody} and saveChanges
                _context.SaveChanges();

                if (request == null)
                {
                    return BadRequest("Failed to create license, database returned null");
                }

                return Ok(_mapper.Map<Models.System.DTO.LicenseDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to return license.", exc);
                return BadRequest("Failed to return license." + exc.Message);
            }
        }






        [HttpPut]
        public ActionResult UpdateLicense([FromBody] Models.System.DTO.LicenseDTO requestDTO)
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
                log.Error("fail to update the license ", exc);
                return BadRequest("fail to update the license " + exc.Message);
            }
        }






        [HttpDelete]
        public ActionResult DeleteLicense(int ID)
        {
            try
            {
                var dbItem = _context.License.Find(ID);

                var success = _context.Entry(dbItem).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delete License", exc);
                return BadRequest("Failed to delete License : " + exc.Message);
            }
        }

    }

}
