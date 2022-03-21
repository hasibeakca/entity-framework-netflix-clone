using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Netflix.DAL.Dto.KullaniciDizi
{
    public class GetKullaniciDiziDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int EpisodeNumber { get; set; }
        public int SeasonNumber { get; set; }
        public int Imdb { get; set; }
        public int AgeRange { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Paymentİnformation { get; set; }
    }
}
