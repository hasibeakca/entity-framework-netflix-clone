using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Netflix.DAL.Dto.KullaniciFilm
{
    public class GetKullaniciFilmDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public int Time { get; set; }
        public int AgeRange { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Paymentİnformation { get; set; }
    }
}
