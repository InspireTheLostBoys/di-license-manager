using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DILicenseManagerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        public LoginController(DataAccess.Context.LicensingDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        //1) public async Task<Models.System.DTO.AdminUserDTO> Login(string username, string password)
        //2) public Models.System.DTO.AdminUserDTO Login(string username, string password)
        public ActionResult Login(string username, string password)
        {
            log.Debug("Inside login request");

            Models.System.DTO.BaseResponse.BaseResponseDTO retVal = new Models.System.DTO.BaseResponse.BaseResponseDTO();
            try
            {
                var user = _context.AdminUser.Where(m => m.EmailAddress.ToUpper() == username.ToUpper() && m.Password == password).FirstOrDefault();

                if (user == null)
                {
                    //retVal.Success = false;
                    //retVal.ErrorHint = "Failed to find user with those credentials";
                    //retVal.FullException = "Database returned no result";
                    //return Ok(retVal);
                    return BadRequest("No user exists with those credentals");
                }
                else
                {
                    user.Password = "";
                    return Ok(user);
                }

            }
            catch (Exception exc)
            {
                log.Error("fail to process login request", exc);
                return BadRequest("Failed to log in using the credentials applied");
            }
        }


    }
}
