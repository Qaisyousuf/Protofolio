﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    public class Menu:EntityBase
    {
        public Menu()
        {
            SubMenu = new List<Menu>();
        }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        [InverseProperty("SubMenu")]
        public int? ParentId { get; set; }

        public Menu Parent { get; set; }

        [ForeignKey("ParentId")]
        public List<Menu> SubMenu { get; set; }
    }
}
