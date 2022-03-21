using AppCore.Entity;
using Netflix.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NETFLIX.DAL.Entities
{
    public class Kullanici : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Paymentİnformation { get; set; }
        public bool IsDeleted {get; set;}
        public ICollection<KullaniciDizi> KullaniciDizis { get; set; }
        public ICollection<KullaniciFilm> KullaniciFilms { get; set; }
    }
}
