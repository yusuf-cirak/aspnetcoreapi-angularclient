using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SehirRehberi.Business.Abstract;
using SehirRehberi.Helpers;
using SehirRehberi.Models;
using SehirRehberi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SehirRehberi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private IAppRepositoryService _appRepositoryService;
        private IMapper _mapper;
        private IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotosController(IAppRepositoryService appRepositoryService, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _appRepositoryService = appRepositoryService;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;

            Account account = new Account(_cloudinaryConfig.Value.CloudName,
            _cloudinaryConfig.Value.ApiKey,
            _cloudinaryConfig.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }


        [HttpPost]
        public ActionResult AddPhotoForCity(int cityId,[FromBody]PhotoForCreationDto photoForCreationDto)
        {

            var city = _appRepositoryService.GetCityById(cityId);
            if (city==null)
            {
                return BadRequest("Could'nt find the city");
            }
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId!=city.UserId)
            {
                return Unauthorized();
            }
            var file = photoForCreationDto.File;
            var uploadResult = new ImageUploadResult();
            if (file.Length>0)
            {
                using (var stream=file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams {
                        File = new FileDescription(file.Name,stream) };

                    uploadResult = _cloudinary.Upload(uploadParams);

                }
            }
            photoForCreationDto.Url = uploadResult.Url.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoForCreationDto);
            photo.City = city;
            if (!city.Photos.Any(p=>p.IsMain))
            {
                photo.IsMain = true;
            }

            city.Photos.Add(photo);

            if (_appRepositoryService.SaveAll())
            {
                var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);
                return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoToReturn);
            }
            return BadRequest("Could'nt add the photo");
        }

        [HttpGet("getphotobyid/{photoId}")]
        public ActionResult GetPhoto(int photoId)
        {
            var photoFromDb = _appRepositoryService.GetPhoto(photoId);
            var photo = _mapper.Map<PhotoForReturnDto>(photoFromDb);
            return Ok(photo);
        }
        

        
    }
}
