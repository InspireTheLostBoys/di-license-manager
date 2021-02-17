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
    public class AdminUserController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;



        public AdminUserController(DataAccess.Context.LicensingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult GetAllAdminUsers()
        {
            try
            {
                var dbList = _context.AdminUser.ToList();
                return Ok(dbList); // 200 ok status code, with the result from the database
            }
            catch (Exception exc)
            {
                log.Error("Failed to get all AdminUser", exc);
                return BadRequest("Failed to get all AdminUser : " + exc.Message);
            }
        }



        [HttpGet("/{ID:int}")]
        public ActionResult GetSingleAdminUser(int ID)
        {
            try
            {
                var dbItem = _context.AdminUser.Find(ID);
                if (dbItem == null)
                {
                    return BadRequest("There is no AdminUser found by that id: " + ID);
                }



                var retVal = _mapper.Map<Models.System.DTO.AdminUserDTO>(dbItem);



                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get single AdminUser with ID : " + ID, exc);
                return BadRequest("Failed to get single AdminUser : " + exc.Message);
            }
        }



        [HttpPost]
        public ActionResult CreateCustomer([FromBody] Models.System.DTO.AdminUserDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.AdminUser>(requestDTO);



                _context.AdminUser.Add(request);
                _context.SaveChanges();



                if (request == null)
                {
                    return BadRequest("Failed to create AdminUser, database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.AdminUserDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to create AdminUser.", exc);
                return BadRequest("Failed to create AdminUser : " + exc.Message);
           }
        }



        [HttpPut]
        public ActionResult UpdateAdminUser([FromBody] Models.System.DTO.AdminUserDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.AdminUser>(requestDTO);
                _context.Update(request);
                _context.SaveChanges();
                if (request == null)
                {
                    return BadRequest("Failed to update the AdminUser : Database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.AdminUserDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to update the AdminUser", exc);
                return BadRequest("Failed to update the AdminUser : " + exc.Message);
            }
        }



        [HttpDelete]
        public ActionResult DeleteAdminUser(int AdminUserID)
        {
            try
            {
                var dbExists = _context.AdminUser.Find(AdminUserID);
                if (dbExists == null)
                {
                    return BadRequest("Failed to find AdminUser with the given id for delete : " + AdminUserID);
                }



                _context.Remove(dbExists);
                _context.SaveChanges();



                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delete AdminUser", exc);
                return BadRequest("Failed to delete AdminUser : " + exc.Message);
            }
        }
    }
}
