using AppCore.Entity;
using NETFLIX.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.DAL.Entities
{
    public class KullaniciDizi : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici KullaniciFK { get; set; }
        public int DiziId { get; set; }
        public Dizi DiziFK { get; set; }
        public bool IsDeleted { get; set; }
    }
}
