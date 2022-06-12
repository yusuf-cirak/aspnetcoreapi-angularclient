using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SehirRehberi.Models;
using SehirRehberi.Models.DTOs;

namespace SehirRehberi.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityForListDto>() // İsmi eşleşen tüm veriler map edildi.
// İsmi uyuşmayanları ise biz şimdi map edeceğiz.
                .ForMember(dest =>
                    dest.PhotoUrl, opt =>
                    opt.MapFrom(src =>
                        src.Photos.FirstOrDefault(p =>
                            p.IsMain).Url)); // PhotoUrl ve Url farklı olduğu için map edilmedi, manuel olarak ettik. İsimlerin aynı olması çok önemli.


            CreateMap<City, CityForDetailDto>(); //GetCityById için map işlemi

            CreateMap<Photo, PhotoForCreationDto>();
            CreateMap<PhotoForReturnDto, Photo>();
        }
    }
}
