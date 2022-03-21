using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NETFLIX.DAL.Entities
{
    public class FilmKategori : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeleted {get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
