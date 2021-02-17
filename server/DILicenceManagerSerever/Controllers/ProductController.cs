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
    public class ProductController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataAccess.Context.LicensingDbContext _context;
        private readonly IMapper _mapper;


        public ProductController(DataAccess.Context.LicensingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            try
            {
                List<Models.System.Product> dbList = _context.Products.ToList();
                return Ok(dbList);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get all Products", exc);
                return BadRequest("Failed to get all Products : " + exc.Message);
            }


        }

        [HttpGet("{ID:int}")]
        public ActionResult GetSingleProduct(int ID)
        {
            try
            {
                var dbItem = _context.Products.Find(ID);
                if (dbItem == null)
                {
                    return BadRequest("There is no Product found by that id: " + ID);
                }



                var retVal = _mapper.Map<Models.System.DTO.ProductDTO>(dbItem);



                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get single Product with ID : " + ID, exc);
                return BadRequest("Failed to get single Product : " + exc.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateCustomer([FromBody] Models.System.DTO.ProductDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Product>(requestDTO);



                _context.Products.Add(request);
                _context.SaveChanges();



                if (request == null)
                {
                    return BadRequest("Failed to create Product, database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.ProductDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to create Product.", exc);
                return BadRequest("Failed to create Product : " + exc.Message);
            }

        }
        [HttpPut]
        public ActionResult UpdateProduct([FromBody] Models.System.Product requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Product>(requestDTO);
                _context.Update(request);
                _context.SaveChanges();
                if (request == null)
                {
                    return BadRequest("Failed to update the Product : Database returned null");
                }



                return Ok(_mapper.Map<Models.System.DTO.ProductDTO>(request));
            }
            catch (Exception exc)
            {
                log.Error("Failed to update the Product", exc);
                return BadRequest("Failed to update the Product : " + exc.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int ProductID)
        {
            try
            {
                var dbExists = _context.Products.Find(ProductID);
                if (dbExists == null)
                {
                    return BadRequest(": " + ProductID);
                }

                _context.Remove(dbExists);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delte Product", exc);
                return BadRequest("Failed to delete Product" + exc.Message);
            }
        }
    }
}
