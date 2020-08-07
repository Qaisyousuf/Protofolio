using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class ProjectStatusViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Development Process")]
        public string ProjectStatusProcess { get; set; }
    }
}
