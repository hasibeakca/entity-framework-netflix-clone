using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Netflix.DAL.Dto.Kullanici
{
    public class  AddKullaniciDto : IDto
    {
        
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Paymentİnformation { get; set; }
    }
}
