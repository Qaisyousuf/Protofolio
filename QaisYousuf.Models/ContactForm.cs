using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.Models
{
     public class ContactForm:EntityBase
    {

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Moible { get; set; }

        public string Message { get; set; }


    }
}
