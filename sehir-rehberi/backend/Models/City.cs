using System.Collections.Generic;

namespace SehirRehberi.Models
{
    public class City
    {
        public City()
        {
            Photos = new List<Photo>(); // Array'ler referans tip olduğu için newlememiz lazım. Aksi taktirde NullReferenceException hatası alırız.
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Photo> Photos { get; set; } // Her şehrin fotoğrafları var.
        public User User { get; set; } // Şehri ekleyen bir kullanıcı vardır.

    }
}