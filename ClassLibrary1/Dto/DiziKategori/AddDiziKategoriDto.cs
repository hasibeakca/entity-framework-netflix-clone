using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.DAL.Dto.DiziKategoriDto
{
    public class AddDiziKategoriDto : IDto
    {

        public string CategoryName { get; set; }
        public string Type { get; set; }
    }
}
