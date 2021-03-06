﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.DTO
{
    public class UserTariffDTO
    {
        public Guid Id { get; set; }
        public TariffDTO Tariff { get; set; }
        public string Tariff_Id { get; set; }
        public AccountDTO Account { get; set; }
        public Guid Account_Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
