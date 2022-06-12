using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.Models.DTOs
{
    public class PhotoForCreationDto
    {
        public PhotoForCreationDto()
        {
            DataAdded = DateTime.Now;
        }
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DataAdded { get; set; }
        public string PublicId { get; set; }
    }
}
