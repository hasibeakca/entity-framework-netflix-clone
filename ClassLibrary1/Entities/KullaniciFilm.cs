using AppCore.Entity;
using NETFLIX.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.DAL.Entities
{
    public class KullaniciFilm : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici KullaniciFK { get; set; }
        public int FilmId  { get; set; }
        public Film FilmFK { get; set; }
        public bool IsDeleted { get; set; }
    }
}
