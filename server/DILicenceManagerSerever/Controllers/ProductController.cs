using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;

namespace DIProductManagerServer.Controllers
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
                var dbList = _context.Product.ToList();
                return Ok(dbList); // 200 ok status code, with the result from the database
            }
            catch (Exception exc)
            {
                log.Error("Failed to get all Products", exc);
                return BadRequest("Failed to get all Products : " + exc.Message);
            }
        }



        [HttpGet]
        [Route("Single")]
        public ActionResult GetSingleProduct(int ProductID)
        {
            try
            {
                var dbItem = _context.Product.Find(ProductID);
                if (dbItem == null)
                {
                    return BadRequest("There is no product found by that id: " + ProductID);
                }

                var retVal = _mapper.Map<Models.System.DTO.ProductDTO>(dbItem);
                return Ok(retVal);
            }
            catch (Exception exc)
            {
                log.Error("Failed to get single Product with ID : " + ProductID, exc);
                return BadRequest("Failed to get single Product : " + exc.Message);
            }
        }



        [HttpPost]
        public ActionResult CreateProduct([FromBody] Models.System.DTO.ProductDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Models.System.Product>(requestDTO);

                _context.Product.Add(request);
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
        public ActionResult UpdateProduct([FromBody] Models.System.DTO.ProductDTO requestDTO)
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
                log.Error("Failed to update the Product ", exc);
                return BadRequest("Failed to update the Product " + exc.Message);
            }
        }



        [HttpDelete]

        public ActionResult DeleteProduct(int ID)
        {
            try
            {
                var dbItem = _context.Product.Find(ID);

                var success = _context.Entry(dbItem).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception exc)
            {
                log.Error("Failed to delete Product", exc);
                return BadRequest("Failed to delete Product : " + exc.Message);
            }
        }
    }


}
