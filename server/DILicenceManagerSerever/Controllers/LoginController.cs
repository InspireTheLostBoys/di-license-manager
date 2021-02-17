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
    public class LoginController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;

        public LoginController(DataAccess.Context.LicensingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Login(string username, string password)
        {

            log.Debug("Inside login request");
            Models.System.DTO.BaseResponse.BaseResponseDTO retval = new Models.System.DTO.BaseResponse.BaseResponseDTO();
            try
            {
                var user = _context.AdminUser.Where(m => m.EmailAddress == username && m.Password ==
                password).FirstOrDefault();
                
                if (user == null)
                {
                    retval.Success = false;
                    retval.ErrorHint = "Failed to find a user with those credentials";
                    retval.FullException = "DataBase returned no result";

                    return Ok(retval);
                }
                else
                {
                    user.Password = "";
                    return Ok(user);
                }
               
            }
            catch(Exception exc)
            {
                log.Error("Failed to process login request", exc);
                return BadRequest("Failed to login using the credentials supplied");
            }
        }
       
        
    }
}
