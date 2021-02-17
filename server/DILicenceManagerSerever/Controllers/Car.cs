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
    public class CarController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;



        public CarController(DataAccess.Context.LicensingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult GetAllCars()
        {
            try
            {
                var dbList = _context.Cars.ToList();
                return Ok(dbList); // 200 ok status code, with the result from the database
            }
            catch (Exception exc)
            {
                log.Error("Failed to get all Cars", exc);
                return BadRequest("Failed to get all Cars : " + exc.Message);
            }
        }



        [HttpGet("{ID:int}")]
        public ActionResult GetSingleCar(int ID)
        {
            try
            {
                var dbItem = _context.Cars.Find(ID);
                if (dbItem == null)
                {
                    return BadRequest("There is no Car found by that id: " + ID);
                }



                var retVal = _mapper.Map<Models.System.DTO.CarDTO>(dbItem);



                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get single Car with ID : " + ID, exc);
                return BadRequest("Failed to get single Car : " + exc.Message);
            }
        }



        [HttpPost]
        public ActionResult CreateCar([FromBody] Models.System.DTO.CarDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Car>(requestDTO);



                _context.Cars.Add(request);
                _context.SaveChanges();



                if (request == null)
                {
                    return BadRequest("Failed to create Car, database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.CarDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to create Car.", exc);
                return BadRequest("Failed to create Car : " + exc.Message);
            }
        }



        [HttpPut]
        public ActionResult UpdateCar([FromBody] Models.System.DTO.CarDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Car>(requestDTO);
                _context.Update(request);
                _context.SaveChanges();
                if (request == null)
                {
                    return BadRequest("Failed to update the Car : Database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.CarDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to update the Car", exc);
                return BadRequest("Failed to update the Car : " + exc.Message);
            }
        }



        [HttpDelete]
        public ActionResult DeleteCar(int CarID)
        {
            try
            {
                var dbExists = _context.Cars.Find(CarID);
                if (dbExists == null)
                {
                    return BadRequest("Failed to find Car with the given id for delete : " + CarID);
                }



                _context.Remove(dbExists);
                _context.SaveChanges();



                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delete Car", exc);
                return BadRequest("Failed to delete Car : " + exc.Message);
            }
        }
    }
}
