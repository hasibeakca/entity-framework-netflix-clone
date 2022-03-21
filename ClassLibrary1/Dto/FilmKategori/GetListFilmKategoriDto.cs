using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.DAL.Dto.FilmKategori
{
   public class GetListFilmKategoriDto : IDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string CategoryName { get; set; }
    }
}
