using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.DAL.Dto.FilmDto
{
    public class GetFilmDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public int Time { get; set; }
        public int AgeRange { get; set; }
        public int FilmKategoriId { get; set; }
        public string FilmKategoriName { get; set; }
    }
}
