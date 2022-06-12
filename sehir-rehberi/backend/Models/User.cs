using System.Collections.Generic;

namespace SehirRehberi.Models
{
    public class User
    {
        public User()
        {
            Cities = new List<City>(); // Array'ler referans tip olduğu için newlememiz lazım. Aksi taktirde NullReferenceException hatası alırız.
        }

        public int Id { get; set; } // hocam nesnelerin sırasını databasedeki gibi mi yapsak? ondan olabilri miondan değildir ama eklemeyi yapmıyor.
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<City> Cities { get; set; } // Kullanıcının eklediği şehirler vardır.

    }
}