﻿using Business.Abstract;
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
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;

        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file,[FromForm] CarImage carImage)
        {
            var result = _carImageService.add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpGet("getbycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {



        }
    }
}
