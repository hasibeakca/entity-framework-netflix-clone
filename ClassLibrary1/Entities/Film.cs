using AppCore.Entity;
using Netflix.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NETFLIX.DAL.Entities
{
    public class Film : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; } 
        public int Time { get; set; }
        public int AgeRange { get; set; }
        public bool IsDeleted { get; set;}
        public ICollection<KullaniciFilm> KullaniciFilms { get; set; }
        public int FilmKategoriId { get; set; }
        public FilmKategori FilmKategoriFK { get; set; }
    }
}
