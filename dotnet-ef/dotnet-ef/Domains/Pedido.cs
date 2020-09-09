﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ef.Domains
{
    public class Pedido : BaseDomain
    {
        [Key]
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
