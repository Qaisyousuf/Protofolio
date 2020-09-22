using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    [Table("Contact")]
     public class ContactForm:EntityBase
    {

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Moible { get; set; }

        public string Message { get; set; }

        public string IpAddress { get; set; }


    }
}
