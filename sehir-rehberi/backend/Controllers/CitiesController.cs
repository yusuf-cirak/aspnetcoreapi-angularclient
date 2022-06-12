using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SehirRehberi.Business.Abstract;
using SehirRehberi.Models;
using SehirRehberi.Models.DTOs;

namespace SehirRehberi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepositoryService _appRepositoryService;
        private IMapper _mapper;

        public CitiesController(IAppRepositoryService appRepositoryService, IMapper mapper)
        {
            _appRepositoryService = appRepositoryService;
            _mapper = mapper;
        }

        [HttpGet("getcities")]
        public ActionResult GetCities()
        {
            var cities = _appRepositoryService.GetCities();
            var citiesMapped = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiesMapped);
        }

        [HttpPost("add")]
        public ActionResult Add([FromBody]City city)
        {
            _appRepositoryService.Add(city);
            _appRepositoryService.SaveAll();
            return Ok(city);
        }

        [HttpGet("getcitybyid/{cityId}")]
        public ActionResult GetCityById(int cityId)
        {
            var city = _appRepositoryService.GetCityById(cityId);
            var cityMapped = _mapper.Map<CityForDetailDto>(city);
            return Ok(cityMapped);
        }

        [HttpGet("getphotosbycityid/{cityId}")]
        public ActionResult GetPhotosByCity(int cityId)
        {
            var photos = _appRepositoryService.GetPhotosByCity(cityId);
            return Ok(photos);
        }
    }
}
