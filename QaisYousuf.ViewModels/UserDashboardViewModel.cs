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
    public class UserDashboardViewModel:BaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        [Display(Name ="Authenticated User")]
        public string AuthenticatedUser { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Project Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime ProjectStartDate { get; set; }

        [Required]
        [Display(Name = "Project Finish Date")]
        [DataType(DataType.DateTime)]
        public DateTime ProjectFinishDate { get; set; }

        [Required]
        [Display(Name = "Project Type")]
        
        public string ProjectType { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }
    }
}
