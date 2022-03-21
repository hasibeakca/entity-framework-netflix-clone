using AppCore.Entity;
using Netflix.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETFLIX.DAL.Entities
{
    public class Dizi : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int EpisodeNumber { get; set; }
        public int SeasonNumber { get; set; }
        public int Imdb { get; set; }
        public int AgeRange { get; set; }
        public bool IsDeleted { get ; set ; }
        public ICollection<KullaniciDizi> KullaniciDizis { get; set; }
        public int DiziKategoriId { get; set; }
        public DiziKategori DiziKategoriFK { get; set; }

    }
}
