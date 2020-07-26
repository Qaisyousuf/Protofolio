using System;
using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.Models
{
    public class ContactDetails:EntityBase
    {
        public string Title { get; set; }

        public string HomeAddress { get; set; }

        public string Moible { get; set; }

        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime WorkingTime { get; set; }

    }
}
