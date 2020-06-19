﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QaisYousuf.Services.Security
{
    [Serializable]
    public class CustomPricipalSerialize
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string[] Roles { get; set; }
    }
}