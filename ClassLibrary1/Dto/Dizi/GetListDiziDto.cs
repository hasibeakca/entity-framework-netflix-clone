using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.DAL.Dto.Dizi
{
    public class GetListDiziDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int EpisodeNumber { get; set; }
        public int SeasonNumber { get; set; }
        public int Imdb { get; set; }
        public int AgeRange { get; set; }
        public int DiziKategoriId { get; set; }
        public string DiziKategoriName { get; set; }

    }
}
