﻿using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Netflix.DAL.Dto.KullaniciDizi
{
    public class AddKullaniciDiziDto : IDto
    {
        public int KullaniciId { get; set; }
        public int DiziId { get; set; }

    }
}
