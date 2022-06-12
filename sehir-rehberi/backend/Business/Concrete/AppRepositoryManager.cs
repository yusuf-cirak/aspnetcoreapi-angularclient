using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SehirRehberi.Business.Abstract;
using SehirRehberi.DataAccess;
using SehirRehberi.Models;

namespace SehirRehberi.Business.Concrete
{
    public class AppRepositoryManager : IAppRepositoryService
    {
        private DataContext _context;

        public AppRepositoryManager(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<City> GetCities()
        {
            var cities = _context.Cities.Include(c=>
                c.Photos).ToList();
            return cities;
        }

        public City GetCityById(int cityId)
        { // FirstOrDefault tek bir city döndürmeye yarıyor.
            var city = _context.Cities.Include(c =>
                c.Photos).FirstOrDefault(c =>
                c.Id == cityId);
            return city;
        }

        public Photo GetPhoto(int photoId)
        { // FirstOrDefault tek bir photo döndürmeye yarıyor.
            var photo = _context.Photos.FirstOrDefault(p =>
                p.Id == photoId);
            return photo;
        }

        public List<Photo> GetPhotosByCity(int cityId)
        {
            var photos = _context.Photos.Where(p =>
                p.CityId == cityId).ToList();
            return photos;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0; 
            // Bir şey değiştirildiğinde değişiklik sayısı 0'dan büyük olur ve değişiklik kaydedilir.
        }

        public void Update<T>(T entity) where T : class
        { 
            _context.Update(entity);
        }
    }
}
