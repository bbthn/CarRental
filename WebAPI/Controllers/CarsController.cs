using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carservice;
        
        public CarsController(ICarService carservice)
        {
            _carservice = carservice;
            

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarsbrandid")]
        public IActionResult GetById(int brandId)
        {
            var result = _carservice.GetCarsBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("addcar")]
        public IActionResult Add(Car car)
        {
            var result = _carservice.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
