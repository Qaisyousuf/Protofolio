using QaisYousuf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        public MenuViewModel()
        {
            SubMenu = new List<Menu>();
        }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        [InverseProperty("SubMenu")]
        [Display(Name ="SubMenu")]
        public int? ParentId { get; set; }

        public Menu Parent { get; set; }

        [ForeignKey("ParentId")]
        public List<Menu> SubMenu { get; set; }
    }
}
